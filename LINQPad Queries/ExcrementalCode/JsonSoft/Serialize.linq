<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
	var raw = new(string,string)[]{("alpha", "flight"), ("beta", "tester"), ("gamma", "rays"), ("delta", "wing")};
	var dictionary = raw.ToDictionary(x => x.Item1, x => x.Item2);
	JsonConvert.SerializeObject(dictionary).Dump();
}

// Define other methods and classes here
