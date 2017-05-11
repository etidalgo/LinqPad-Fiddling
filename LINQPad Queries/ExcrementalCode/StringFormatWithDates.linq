<Query Kind="Statements">
  <Reference Relative="..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>NodaTime</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>


var arrivedAt = new LocalDateTime(2017, 04, 01, 16, 20);
var textA = string.Format(CultureInfo.InvariantCulture, "Arrived at: {0}", arrivedAt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
var textB = string.Format(CultureInfo.InvariantCulture, "Arrived at: {0:G}", arrivedAt);
var textC = string.Format(CultureInfo.InvariantCulture, "Arrived at: {0:yyyy-MM-dd HH:mm:ss}", arrivedAt);
Console.WriteLine(textA);
Console.WriteLine(textB);
Console.WriteLine(textC);
