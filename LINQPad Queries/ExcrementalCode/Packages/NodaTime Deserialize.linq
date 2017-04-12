<Query Kind="Program">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Namespace>NodaTime</Namespace>
  <Namespace>NodaTime.Text</Namespace>
</Query>

void Main()
{
    DisplayAsLocalDateTime("2016-04-02T13:59:00Z");// 2:59 am
    DisplayAsLocalDateTime("2016-04-02T14:01:00Z");// 2:01 am

}

        public static Instant CreateInstantFromLocalDateTimeString(string dateTime)
        {
            return ZonedDateTimePattern.CreateWithInvariantCulture("yyyy'-'MM'-'dd HH':'mm':'ss z", DateTimeZoneProviders.Tzdb).Parse(dateTime + " Pacific/Auckland").Value.ToInstant();
        }

// Define other methods and classes here
void ToInstant(string isoString) {
    var instantResult = InstantPattern.GeneralPattern.Parse(isoString).Value;
    Console.WriteLine($"instantResult: {instantResult}");
}

void DisplayAsLocalDateTime(string isoString)
{
    var instantResult = InstantPattern.GeneralPattern.Parse(isoString).Value;
    var timeZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
    var zonedDateTime = instantResult.InZone(timeZone);
    Console.WriteLine($"LocalDateTime: {zonedDateTime.LocalDateTime}");
}
