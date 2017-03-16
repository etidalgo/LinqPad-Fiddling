<Query Kind="Statements">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Namespace>NodaTime</Namespace>
</Query>

var localTime = new LocalDateTime(2016, 9, 25, 1, 59, 00);
var timeZone = DateTimeZoneProviders.Tzdb.GetSystemDefault();
var zonedTime = localTime.InZoneStrictly(timeZone);
var processStartTime = zonedTime.ToInstant();
Console.WriteLine($"processStartTime: {processStartTime}");