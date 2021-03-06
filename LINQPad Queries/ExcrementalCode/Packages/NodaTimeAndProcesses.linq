<Query Kind="Program">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>NodaTime</Namespace>
  <Namespace>NodaTime.Text</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
    var processId = Process.GetCurrentProcess().Id;
    Console.WriteLine($"Process.GetCurrentProcess().StartTime: {Process.GetCurrentProcess().StartTime}");
    var processStartTime = Process.GetCurrentProcess().StartTime.ToInstantUsingSystemTimeZone();
    Console.WriteLine($"processStartTime: {processStartTime}");
    Console.WriteLine($"processStartTime.ToDateTimeUtc(): {processStartTime.ToDateTimeUtc()}");
    var timeAsFormatString = String.Format(CultureInfo.InvariantCulture, "{0}", processStartTime);
    Console.WriteLine($"timeAsFormatString: {timeAsFormatString}");

    if(Process.GetProcesses().Any( x => x.Id == processId && x.StartTime.ToInstantUsingSystemTimeZone() == processStartTime)) {
        Console.WriteLine("Found it again");
    } else {
        Console.WriteLine("Not found it again");
    }

    Console.WriteLine(FormatIdFromProcess( Process.GetProcesses().Where( x => x.ProcessName == "notepad++").First() ));
}

    string FormatIdFromProcess(Process process)
    {
        return string.Format(CultureInfo.CurrentCulture, "{0}|{1}|{2}", process.MachineName, process.Id, process.StartTime.ToInstantUsingSystemTimeZone());
    }

// Define other methods and classes here
    public static class DateTimeExtensions
{
        public static Instant ToInstant(this DateTime dateTime, DateTimeZone timeZone)
        {
            if (timeZone == null)
                throw new ArgumentNullException(nameof(timeZone));

            if(dateTime.Kind == DateTimeKind.Utc && !timeZone.Id.Equals("UTC", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Non UTC TimeZone provided for UTC DateTime kind", nameof(timeZone));

            var localDateTime = LocalDateTime.FromDateTime(dateTime);
            var zonedTime = localDateTime.InZoneLeniently(timeZone);
            return zonedTime.ToInstant();
        }

        public static Instant ToInstantUsingSystemTimeZone(this DateTime dateTime)
        {
            return ToInstant(dateTime, DateTimeZoneProviders.Tzdb.GetSystemDefault());
        }
}
