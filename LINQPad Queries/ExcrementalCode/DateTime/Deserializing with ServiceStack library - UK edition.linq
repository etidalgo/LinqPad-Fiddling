<Query Kind="Statements">
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\ServiceStack.Text.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\ServiceStack.Text.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>ServiceStack.Text</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>


// JsConfig<DateTime>.DeSerializeFn = str => DateTime.Parse(str, CultureInfo.InvariantCulture);
// JsConfig<DateTime>.DeSerializeFn = str => DateTime.ParseExact(str, "d/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

// ServiceStack fails with these dates because they are UK format (dd/MM/yyyy)
var variousDateTimeText = new[]{"09/01/2013 00:00:00", "28/11/2012 00:00:00"};

variousDateTimeText.ToList().ForEach(dt => {
	LINQPad.Extensions.Dump(dt, "Parsing: ");
	var dateTime = CsvSerializer.DeserializeFromString<DateTime>(dt);
	LINQPad.Extensions.Dump(dateTime, "Got: ");
	});

JsConfig.Reset(); // JsConfig is static and the settings persist across runs!
