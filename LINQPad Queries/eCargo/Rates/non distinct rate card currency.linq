<Query Kind="Program">
  <Reference Relative="..\..\..\..\Tools\RatesMigrator\packages\CsvHelper.2.16.3.0\lib\net45\CsvHelper.dll">D:\dev\Tools\RatesMigrator\packages\CsvHelper.2.16.3.0\lib\net45\CsvHelper.dll</Reference>
  <Reference Relative="..\..\..\..\Tools\RatesMigrator\packages\Insight.Database.Core.5.2.8\lib\NET45\Insight.Database.dll">D:\dev\Tools\RatesMigrator\packages\Insight.Database.Core.5.2.8\lib\NET45\Insight.Database.dll</Reference>
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.2.2.3\lib\net45\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.2.2.3\lib\net45\NodaTime.dll</Reference>
  <Reference Relative="..\..\..\..\Tools\RatesMigrator\RatesMigrator\obj\Debug\RatesMigrator.exe">D:\dev\Tools\RatesMigrator\RatesMigrator\obj\Debug\RatesMigrator.exe</Reference>
  <NuGetReference>System.ValueTuple</NuGetReference>
  <Namespace>CsvHelper</Namespace>
  <Namespace>CsvHelper.Configuration</Namespace>
  <Namespace>CsvHelper.TypeConversion</Namespace>
  <Namespace>Insight.Database</Namespace>
  <Namespace>NodaTime</Namespace>
</Query>

void Main()
{
	var ownerId = 9168;

	var sql = $@"select
    rate_card.rate_card_id RateCardId,
    rate_table.rate_table_type_id RateCardTypeId,
    rate_table.charge_type_id ChargeTypeId,
    rate_table.owner_id OwnerId,
    rate_table_used.customer_id CustomerId,
    rate_table.supplier_id SupplierId,
    rate_route.from_loc_id FromZoneId,
    rate_route.to_loc_id ToZoneId,
    rate_card.rate_product_id ConsignmentRateProductId,
    rate_card.effective_date EffectiveFromInclusive,
    rate_card.expiry_date EffectiveToInclusive,
    rate_table_used.product_type_id OrderLineRateProductId,
    rate_table_used.carrier_id CarrierId,
    rate_table_used.sold_to_id SoldToPartyId
from rate_card
join rate_table on rate_table.rate_table_id = rate_card.rate_table_id
join rate_table_used on rate_table_used.rate_table_id = rate_card.rate_table_id
join rate_route on rate_card.rate_route_id = rate_route.rate_route_id
where
    rate_table.active_yn = 'Y' and
    ToBeDeleted = 0 and
    rate_table.owner_id = {ownerId}
";

	var conn = new SqlConnection(new SqlConnectionStringBuilder { InitialCatalog = "hub_200", DataSource = "primarydb", IntegratedSecurity = true}.ToString());

	var allRateCards = conn.QuerySql<NonDistinctSupplierRateCard>(sql);

	var rateCardsGroupByMostCriteria = allRateCards.GroupBy(rc => new { rc.CarrierId, rc.ChargeTypeId, rc.ConsignmentRateProductId, rc.CustomerId, rc.FromZoneId, rc.OrderLineRateProductId, rc.OwnerId, rc.RateCardTypeId, rc.SoldToPartyId, rc.ToZoneId })
	.Where(g => g.Select(h => h.SupplierId).Distinct().Count() > 1);

	var allOverlappingIds = new List<int>();
	
	foreach(var group in rateCardsGroupByMostCriteria)
	{
		var bucketedByPeriod = new Dictionary<RateCardPeriod, List<NonDistinctSupplierRateCard>>();

		foreach (var rateCard in group.OrderBy(rc=> rc.EffectiveFromInclusive))
		{
			var periodBuckets = bucketedByPeriod.Where(bucket => bucket.Key.HasOverlapWith(rateCard.Period)).Select(bucket => bucket.Key);
			if (!periodBuckets.Any())
			{
				bucketedByPeriod.Add(rateCard.Period, new List<NonDistinctSupplierRateCard> { rateCard});
			} 
			else 
			{
				foreach(var periodBucket in periodBuckets)
				{
					bucketedByPeriod[periodBucket].Add(rateCard);
				}
			}
		}
		
		foreach(var bucket in bucketedByPeriod)
		{
			if (bucket.Value.Select(rc => rc.SupplierId).Distinct().Count() > 1)
			{
				allOverlappingIds.AddRange(bucket.Value.Select(rc => rc.RateCardId));
			}
		}
	}

	ExportRates(conn, ownerId, allOverlappingIds);
}

static IEnumerable<string> BuildTempTableInsteadOfUsingTableValuedParameter(IEnumerable<int> rateCardIds)
{
	yield return "declare @specificRateCardIds table (RateCardId int)";

	if (!rateCardIds.Any())
		yield break;

	for (var group = 0; group <= rateCardIds.Count() / 1000; group++) // you cannot have more than 1000 items in an insert statement
	{
		var thisGroupsOfRateCardIds = rateCardIds.Skip(group * 1000).Take(1000);

		yield return "insert into @specificRateCardIds (RateCardId) values " + string.Join(", ", thisGroupsOfRateCardIds.Select(rateCardId => $"({rateCardId})"));
	}
}

void ExportRates(IDbConnection conn, int ratesOwnerId, IEnumerable<int> rateCardIds)
{
	var sql = @";with RateTableEntries as (
                        select rt.rate_table_type_id as RateCardType,
                            charge_type.description as ChargeTypeName,
                            customer.name as CustomerName,
                            supplier.name as SupplierName,
                            from_zone.location_name as FromZoneName,
                            to_zone.location_name as ToZoneName,
                            consignment_rate_product.product_name as ConsignmentRateProductName,
                            rca.effective_date as EffectiveFromInclusive,
                            rca.expiry_date as EffectiveToInclusive,
                            rca.rate_card_id as RateCardId,
                            rco.min_val as TierFromInclusive,
                            rco.max_val as TierUpToExclusive,
                            re.entry_charge as Rate,
                            rco.charge_per as ChargePerQuantity,
                            uom_code as UnitOfMeasureCode,
                            coalesce(re.entry_currency, 'NZD') as CurrencyCode,
                            order_line_rate_product.product_name as OrderLineRateProductName,
                            carrier.name as CarrierName,
                            sold_to.name as SoldToName,
                            rt.rate_table_name as RateTableName
                        from rate_table_used rtu
                            join rate_table rt on rt.rate_table_id = rtu.rate_table_id
                            join rate_card rca  on rt.rate_table_id = rca.rate_table_id
                            join Rate_Column rco on rt.rate_table_id = rco.rate_table_id
                            join rate_entry re on (rco.rate_col_id = re.rate_col_id and rca.rate_card_id = re.rate_card_id)
                            join rate_route rr on rca.rate_route_id = rr.rate_route_id

                        cross apply
                            (select product_name from Rate_Product where rate_product_id = rca.rate_product_id) consignment_rate_product
                        outer apply
                            (select product_name from Rate_Product where rate_product_id = rtu.product_type_id) order_line_rate_product
                        cross apply
                            (select rtrim(Code1) uom_code from Units_of_Measure where Id = rco.uom_id) uom
                        cross apply
                            (select location_name from Location where location_id = rr.from_loc_id) from_zone
                        cross apply
                            (select location_name from Location where location_id = rr.to_loc_id) to_zone
                        cross apply
                            (select name from ""resource"" where resource_id = rtu.customer_id) customer
                        cross apply
                            (select name from ""resource"" where resource_id = rt.supplier_id) supplier
                        outer apply
                            (select name from ""resource"" where resource_id = rtu.carrier_id) carrier
                        outer apply
                            (select name from ""resource"" where resource_id = rtu.sold_to_id) sold_to
                        cross apply
                            (select ""description"" from object_type where rt.charge_type_id = object_type.object_type_id) charge_type

                        where
                            rt.active_yn = 'Y'
                            and rt.owner_id = @ratesOwnerId
                            and rca.ToBeDeleted = 0
                            and rca.rate_card_id in (select RateCardId from @specificRateCardIds)
                    )

                    select distinct entries.*
                    from RateTableEntries entries
                    order by
                        RateCardType,
                        CustomerName,
                        CarrierName,
                        ChargeTypeName,
                        FromZoneName,
                        ToZoneName,
                        ConsignmentRateProductName,
                        EffectiveFromInclusive,
                        EffectiveToInclusive,
                        UnitOfMeasureCode,
                        TierFromInclusive,
                        TierUpToExclusive,
                        ChargePerQuantity,
                        Rate,
                        CurrencyCode,
                        SoldToName,
                        OrderLineRateProductName,
                        RateCardId,
                        SupplierName";

	var tempTableSql = string.Join("\r\n", BuildTempTableInsteadOfUsingTableValuedParameter(rateCardIds));

	var rateCards = conn.QuerySql<RateCardCsvRow>(tempTableSql + sql, new { ratesOwnerId }, commandTimeout: 3600);
	
	var writer = new CsvWriter(File.CreateText($@"d:\OverlappingRateCardsWithNonDistinctSuppliers-{ratesOwnerId}.csv"));
	
	writer.Configuration.RegisterClassMap(new RateCardCsvRowMap());
	writer.WriteRecords(rateCards);
}

    public class RateCardCsvRow
    {
        public int RateCardId { get; set; }
        public RateCardType RateCardType { get; set; }
        public string ChargeTypeName { get; set; }
        public string CustomerName { get; set; }
        public string SupplierName { get; set; }
        public string FromZoneName { get; set; }
        public string ToZoneName { get; set; }
        public string ConsignmentRateProductName { get; set; }
        public DateTime EffectiveFromInclusive { get; set; }
        public DateTime? EffectiveToInclusive { get; set; }
        public decimal? TierFromInclusive { get; set; }
        public decimal? TierUpToExclusive { get; set; }
        public decimal Rate { get; set; }
        public decimal? Minimum { get; set; }
        public decimal? Maximum { get; set; }
        public int ChargePerQuantity { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public string CurrencyCode { get; set; }
        public string OrderLineRateProductName { get; set; }
        public string CarrierName { get; set; }
        public string SoldToName { get; set; }
        public string RateTableName { get; set; }
    }

public enum RateCardType
{
	None = 0,
	Supplier = 91,
	Customer = 92
}

class NonDistinctSupplierRateCard
{
	public int RateCardTypeId { get; set; }
	public int ChargeTypeId { get; set; }
	public int OwnerId { get; set; }
	public int CustomerId { get; set; }
	public int SupplierId { get; set; }
	public int FromZoneId { get; set; }
	public int ToZoneId { get; set; }
	public int ConsignmentRateProductId { get; set; }
	public DateTime EffectiveFromInclusive { get; set; }
	public DateTime? EffectiveToInclusive { get; set; }
	public int? OrderLineRateProductId { get; set; }
	public int? CarrierId { get; set; }
	public int? SoldToPartyId { get; set; }
	public int RateCardId { get; set; }
	public RateCardPeriod Period =>
		new RateCardPeriod(EffectiveFromInclusive, EffectiveToInclusive);
}

class RateCardPeriod
{
	public DateTime EffectiveFromInclusive { get; }
	public DateTime? EffectiveToInclusive { get; }

	public bool HasEnd => EffectiveToInclusive.HasValue;

	public RateCardPeriod(DateTime effectiveFromInclusive, DateTime? effectiveToInclusive)
	{
		EffectiveFromInclusive = effectiveFromInclusive;
		EffectiveToInclusive = effectiveToInclusive;
	}

	public static bool PeriodsOverlap(RateCardPeriod first, RateCardPeriod second)
	{
		if (first == null) throw new ArgumentNullException(nameof(first));
		if (second == null) throw new ArgumentNullException(nameof(second));

		// two endless periods always overlap regardless of when they commence
		if (!first.HasEnd && !second.HasEnd)
			return true;

		if (!first.HasEnd || !second.HasEnd)
		{
			//one endless period versus one not; simply compare the 'from' of the endless period with the 'to' of the other period
                var theEndlessPeriod = first.HasEnd ? second : first;
                var theOtherPeriod = first.HasEnd ? first : second;

                return theEndlessPeriod.EffectiveFromInclusive <= theOtherPeriod.EffectiveToInclusive.Value;
            }

            // both periods have ends
            var periodsDontOverlap = first.EffectiveFromInclusive > second.EffectiveToInclusive.Value || first.EffectiveToInclusive.Value < second.EffectiveFromInclusive;
            return !periodsDontOverlap;
        }

        public bool HasOverlapWith(RateCardPeriod otherPeriod)
        {
            if (otherPeriod == null) throw new ArgumentNullException(nameof(otherPeriod));

            return PeriodsOverlap(this, otherPeriod);
        }

        public override string ToString()
        {
            return HasEnd
                ? FormattableString.Invariant($"{EffectiveFromInclusive} - {EffectiveToInclusive.Value}")
				: FormattableString.Invariant($"{EffectiveFromInclusive} - forever");
}

public static bool AreEqual(RateCardPeriod first, RateCardPeriod second)
{
	if (first == null) throw new ArgumentNullException(nameof(first));
	if (second == null) throw new ArgumentNullException(nameof(second));

	return first.EffectiveFromInclusive == second.EffectiveFromInclusive &&
		   first.EffectiveToInclusive == second.EffectiveToInclusive;
}
}

class RateCardCsvRowMap : CsvClassMap<RateCardCsvRow>
{
	static void SetupMap(CsvClassMap<RateCardCsvRow> map)
	{
		map.Map(m => m.RateCardId).Name("Rate card id");
		map.Map(m => m.RateCardType).Name("Rate card type");
		map.Map(m => m.CustomerName).Name("Customer");
		map.Map(m => m.CarrierName).Name("Carrier");
		map.Map(m => m.SupplierName).Name("Supplier");
		map.Map(m => m.ChargeTypeName).Name("Charge type");
		map.Map(m => m.FromZoneName).Name("From zone");
		map.Map(m => m.ToZoneName).Name("To zone");
		map.Map(m => m.ConsignmentRateProductName).Name("Rate product");
		map.Map(m => m.UnitOfMeasureCode).Name("Unit of measure");
		map.Map(m => m.ChargePerQuantity).Name("Charge per");
		map.Map(m => m.TierFromInclusive).Name("Tier from (including)");
		map.Map(m => m.TierUpToExclusive).Name("Tier up to (not including)");
		map.Map(m => m.EffectiveFromInclusive).Name("Effective from date (including)").TypeConverter(new DateTimeCsvTypeConverter());
		map.Map(m => m.EffectiveToInclusive).Name("Effective to date (including)").TypeConverter(new DateTimeCsvTypeConverter());
		map.Map(m => m.Rate).Name("Rate");
		map.Map(m => m.CurrencyCode).Name("Currency");
		map.Map(m => m.Minimum).Name("Minimum");
		map.Map(m => m.Maximum).Name("Maximum");
		map.Map(m => m.SoldToName).Name("Sold to");
		map.Map(m => m.OrderLineRateProductName).Name("Order line rate product");
		map.Map(m => m.RateTableName).Name("Rate table name");
	}

	public RateCardCsvRowMap()
	{
		SetupMap(this);
	}
}

class DateTimeCsvTypeConverter : ITypeConverter
{
	public string ConvertToString(TypeConverterOptions options, object value)
	{
		if (value == null) return "";

		return ((DateTime)value).ToString("d/M/yyyy");
	}

	public object ConvertFromString(TypeConverterOptions options, string text)
	{
		throw new NotSupportedException();
	}

	public bool CanConvertFrom(Type type) => true;

	public bool CanConvertTo(Type type) => true;
}