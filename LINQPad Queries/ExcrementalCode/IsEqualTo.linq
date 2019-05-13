<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
var thisDateTime = "2019-02-21 13:00".AsDateTime();
var thatDateTime = "2019-02-21 03:00".AsDateTime();

	Console.WriteLine(Equals(thisDateTime, thatDateTime));

	Console.WriteLine(Equals(thisDateTime.Date, thatDateTime.Date));
	
}


// Define other methods and classes here
public static class Utilities {
        private class JsonValueHolder<TValue>
        {
            public TValue Value { get; set; }
        }

        public static DateTime AsDateTime(this string dateTime) =>
            JsonConvert.DeserializeObject<JsonValueHolder<DateTime>>($"{{ {nameof(JsonValueHolder<int>.Value)}: \"{dateTime}\" }}").Value;
}