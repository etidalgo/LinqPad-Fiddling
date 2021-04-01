<Query Kind="Program" />

void Main()
{
	var dict = new Dictionary<string, string>();
	dict.Add("alpha", "a");
	dict.Add("beta", "b");
	dict.Add("gamma", "c");
	
	GetValueOrEmpty(dict, "beta").Dump("beta");
	GetValueOrEmpty(dict, "rho").Dump("rho");
	GetValueOrEmpty(dict, "row").Dump("row");
}

string GetValueOrEmpty(Dictionary<string, string> dict, string value) =>
	dict.TryGetValue(value, out string locId) ? locId : string.Empty;
