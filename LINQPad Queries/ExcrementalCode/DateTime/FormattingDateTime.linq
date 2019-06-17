<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>System.Globalization</Namespace>
</Query>


var dateTime = new DateTime(2017, 04, 01, 16, 20, 00);

dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).Dump();
string.Format(CultureInfo.InvariantCulture, "Arrived at: {0}", dateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)).Dump();

dateTime.ToString("s", CultureInfo.InvariantCulture).Dump(); // not good for file system names
dateTime.ToString("yyyy.MM.dd-HH.mm.ss", CultureInfo.InvariantCulture).Dump();

