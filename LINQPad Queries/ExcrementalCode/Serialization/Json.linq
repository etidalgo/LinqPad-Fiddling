<Query Kind="Program">
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\newtonsoft.json\9.0.1\lib\net45\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
	var span = new TimeSpan();
	var serializedTimeSpan = JsonConvert.ToString(span);
	serializedTimeSpan.Dump();
	
	var response = new Response(new TimeSpan(13, 14, 59));
	var serializedResponse = JsonConvert.SerializeObject(response);
	serializedResponse.Dump();
}

// Define other methods and classes here
class Response {
	public TimeSpan Start { get; set; }

	public Response(TimeSpan start) {
		Start = start;
	}
}