<Query Kind="Program" />

void Main()
{
	var AuditColumns = new []{ "Created", "CreatedBy", "CreatedByHost", "LastModified", "LastModifiedBy", "LastModifiedByHost" };
	var HasAllAuditColumns = new[]{
	"Version", "GeneratedDate", "PrintedDate", "LocationID", "OrganizationID", "Created", "CreatedBy", "CreatedByHost", "LastModified", "LastModifiedBy", "LastModifiedByHost", "StatementMessage", "DueDate", "ShowCreditCardInfo", "DateFrom", "BillingStatementBatchSummaryID", "MinimumBalance", "LastNameFrom", "LastNameTo", "PaymentPlanRequirementID", "PendingCharges"};
	var HasSomeAuditColumns = new []{ "CreatedBy", "CreatedByHost", "LastModified", "LastModifiedBy", "LastModifiedByHost" };
	var HasNoAuditColumns = new []{ "Alpha", "Beta", "Gamma" };
	var HasLowerCaseAuditColumns = new []{ "created", "createdby", "createdByHost", "lastModified", "LastModifiedBy", "LastModifiedByHost" };
	
	ShowContains(HasAllAuditColumns);
	ShowContains(HasSomeAuditColumns);
	ShowContains(HasNoAuditColumns);
	ShowContains(HasLowerCaseAuditColumns); // case sensitive!
}

// Define other methods and classes here
void ShowContains(string[] tableColumns){
	var AuditColumns = new []{ "Created", "CreatedBy", "CreatedByHost", "LastModified", "LastModifiedBy", "LastModifiedByHost" };
	
//	Console.WriteLine("Columns are: ");
//	tableColumns.ToList().ForEach(col => Console.WriteLine($"\t{col}"));
	Console.WriteLine(tableColumns.ContainsAllStrings(AuditColumns));
	Console.WriteLine("Missing columns are: ");
	AuditColumns.Except(tableColumns, StringComparer.OrdinalIgnoreCase).ToList().ForEach(c => Console.WriteLine($"\t{c}"));
}

static public class EnumerableExtensions {
	static public bool ContainsAllStrings(this IEnumerable<string> possibleSuperset, IEnumerable<string> subset) => 
		!subset.Except(possibleSuperset, StringComparer.OrdinalIgnoreCase).Any();
}