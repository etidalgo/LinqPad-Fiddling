<Query Kind="Statements">
  <Reference Relative="..\..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.2.2.0\lib\net45\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.2.2.0\lib\net45\NodaTime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>NodaTime</Namespace>
  <Namespace>NodaTime.Extensions</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

// Requires NodaTime
// Noda Time: What's wrong with DateTime anyway? <https://blog.nodatime.org/2011/08/what-wrong-with-datetime-anyway.html>

var arrivedAt = new LocalDateTime(2017, 04, 01, 16, 20);
var textA = string.Format(CultureInfo.InvariantCulture, "Arrived at: {0}", arrivedAt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
var textB = string.Format(CultureInfo.InvariantCulture, "Arrived at: {0:G}", arrivedAt);
var textC = string.Format(CultureInfo.InvariantCulture, "Arrived at: {0:yyyy-MM-dd HH:mm:ss}", arrivedAt);

var dateTimeOffset = DateTimeOffset.Now;
Console.WriteLine($"DateTimeOffset with implicit ToString {dateTimeOffset}");
Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "DateTimeOffset with {{0:O}} {0:O}", dateTimeOffset));
Console.WriteLine($"DateTimeOffset with ToString(\"O\") {dateTimeOffset.ToString("O")}");

Console.WriteLine(textA);
Console.WriteLine(textB);
Console.WriteLine(textC);
