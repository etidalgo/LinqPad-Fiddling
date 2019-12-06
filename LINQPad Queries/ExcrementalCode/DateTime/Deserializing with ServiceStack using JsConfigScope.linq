<Query Kind="Statements">
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\ServiceStack.Text.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\ServiceStack.Text.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Namespace>ServiceStack.Text</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

//JsConfig.Reset(); // JsConfig is static and the settings persist across runs!
//
//// JsConfig<DateTime>.DeSerializeFn = str => DateTime.Parse(str, CultureInfo.InvariantCulture);
//JsConfig<DateTime>.DeSerializeFn = str => DateTime.ParseExact(str, "d/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

var variousDateTimeText = new[]{
	"2012-11-28 00:00:00" // , "28/11/2012 12:00:00 AM", "6/12/2012 12:00:00 AM", "9/01/2013 12:00:00 AM"
	};


variousDateTimeText.ToList().ForEach(dt => {
	LINQPad.Extensions.Dump(dt, "Parsing: ");
	var dateTime = CsvSerializer.DeserializeFromString<DateTime>(dt);
	LINQPad.Extensions.Dump(dateTime, "Got: ");
	});

//JsConfig.Reset(); // JsConfig is static and the settings persist across runs!
