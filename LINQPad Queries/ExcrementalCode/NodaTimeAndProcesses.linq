<Query Kind="Program">
  <Reference Relative="..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Namespace>NodaTime</Namespace>
  <Namespace>NodaTime.Text</Namespace>
</Query>

void Main()
{
    var processId = Process.GetCurrentProcess().Id;
    Console.WriteLine($"Process.GetCurrentProcess().StartTime: {Process.GetCurrentProcess().StartTime}");
    var processStartTime = Process.GetCurrentProcess().StartTime.ToInstantUsingSystemTimeZone();
    Console.WriteLine($"processStartTime: {processStartTime}");
    Console.WriteLine($"processStartTime.ToDateTimeUtc(): {processStartTime.ToDateTimeUtc()}");

    if(Process.GetProcesses().Any( x => x.Id == processId && x.StartTime.ToInstantUsingSystemTimeZone() == processStartTime)) {
        Console.WriteLine("Found it again");
    } else {
        Console.WriteLine("Not found it again");
    }
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
