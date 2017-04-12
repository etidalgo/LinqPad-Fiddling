<Query Kind="Program">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>NodaTime</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
    var localTime = new LocalDateTime(2016, 9, 25, 1, 59, 00);
    DisplayAsInstant(localTime);
    DisplayAsInstant(new LocalDateTime(2016, 4, 3, 1, 59, 00));
//    DisplayAsInstant(new LocalDateTime(2016, 4, 3, 2, 30, 00));
    DisplayAsInstant(new LocalDateTime(2016, 4, 3, 3, 01, 00));
    Console.WriteLine($"Now: {SystemClock.Instance.Now}");
    var sixMinutesAgo = SystemClock.Instance.Now - Duration.FromMinutes(6);
    var nearlyFiveHoursAgo = SystemClock.Instance.Now - Duration.FromMinutes(298);
    Console.WriteLine(FormatIdFromProcessInformation("ECARGOERNESTDEV", 10101, sixMinutesAgo));
    Console.WriteLine(FormatIdFromProcessInformation("ECARGOERNESTDEV", 10101, nearlyFiveHoursAgo));

}

// Define other methods and classes here

void DisplayAsInstant(LocalDateTime localDateTime) {
    var processStartTime = LocalTimeToInstant(localDateTime);
    Console.WriteLine($"processStartTime: {processStartTime}");
}

Instant LocalTimeToInstant(LocalDateTime localDateTime) {
    var timeZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
    var zonedTime = localDateTime.InZoneStrictly(timeZone);
    return zonedTime.ToInstant();
}

        string FormatIdFromProcessInformation(string machineName, int processId, Instant processStartTime)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}|{1}|{2}", machineName, processId, processStartTime);
        }
