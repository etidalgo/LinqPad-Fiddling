<Query Kind="Statements">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>NodaTime</Namespace>
  <Namespace>NodaTime.Text</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

var ownerAcquiredAt = SystemClock.Instance.Now; // new NodaTime.Instant(DateTime.Now.Ticks);
Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0}", ownerAcquiredAt));

Console.WriteLine($"The wrong way :new NodaTime.Instant(DateTime.Now.Ticks) : {new NodaTime.Instant(DateTime.Now.Ticks)}");
Console.WriteLine($"The right way :SystemClock.Instance.Now : {SystemClock.Instance.Now}");

var processId = Process.GetCurrentProcess().Id;
var localTime = LocalDateTime.FromDateTime(Process.GetCurrentProcess().StartTime);
var timeZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
var zonedTime = localTime.InZoneStrictly(timeZone);
var processStartTime = zonedTime.ToInstant();
Console.WriteLine($"processStartTime: {processStartTime}");

var timeAsString = processStartTime.ToString();
var instantResult = InstantPattern.GeneralPattern.Parse(timeAsString).Value;
Console.WriteLine($"instantResult: {instantResult}");


var isoString = "2014-04-08T09:30:18Z";
instantResult = InstantPattern.GeneralPattern.Parse(isoString).Value;
Console.WriteLine($"instantResult: {instantResult}");

