<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
</Query>

static string ConvertBooleanToLegacyString(bool value) => value ? "Y" : "N";

Tuple<string, string> MapToTuple(string key, string value) => new Tuple<string, string>(key, value);
Tuple<string, string> MapToTuple(string key, int value) => MapToTuple(key, value.ToString(System.Globalization.CultureInfo.InvariantCulture));
Tuple<string, string> MapToTuple(string key, bool value) => MapToTuple(key, ConvertBooleanToLegacyString(value));

void Main()
{
	var resourceId = 4;
	var resourceName = "bob";
	var resourceBool = false;
	
    List<Tuple<string, string>> sessionDataToInsert = new List<Tuple<string, string>>
    {
        MapToTuple("USERID", resourceId),
        MapToTuple("USERNAME", resourceName),
        MapToTuple("BUSINESS_RESOURCE_ID", resourceBool)
	}
}

// Define other methods and classes here
