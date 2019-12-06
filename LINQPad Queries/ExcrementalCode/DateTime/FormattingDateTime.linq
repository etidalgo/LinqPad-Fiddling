<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>System.Globalization</Namespace>
</Query>

// datestamps
var dateTime = new DateTime(2017, 04, 01, 16, 20, 00);

dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).Dump();
string.Format(CultureInfo.InvariantCulture, "Arrived at: {0}", dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)).Dump();

dateTime.ToString("s", CultureInfo.InvariantCulture).Dump(); // not good for file system names
dateTime.ToString("yyyy.MM.dd-HH.mm.ss", CultureInfo.InvariantCulture).Dump(); // file system friendly
dateTime.ToString("yyyyMMdd_HH.mm.ss", CultureInfo.InvariantCulture).Dump(); // file system friendly

dateTime.ToString("G", CultureInfo.InvariantCulture).Dump();

string.Format($"{DateTime.MinValue}").Dump();
string.Format($"{DateTime.MaxValue}").Dump();

// sortable iso 8601
dateTime.ToString("s", CultureInfo.InvariantCulture).Dump();

// [Standard Date and Time Format Strings | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings)
