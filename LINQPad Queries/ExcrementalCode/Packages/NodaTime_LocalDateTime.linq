<Query Kind="Statements">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Namespace>NodaTime</Namespace>
</Query>

var localDate = new LocalDate(2017, 04, 01);
var localTime = new LocalTime(16, 20);
LocalTime? nullableLocalTime = null;



var localDateTime = localDate + localTime;
Console.WriteLine(localDateTime.ToDateTimeUnspecified());
Console.WriteLine(localDateTime);

