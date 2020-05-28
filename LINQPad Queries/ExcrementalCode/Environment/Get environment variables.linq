<Query Kind="Program" />

void Main()
{
	//Environment.SetEnvironmentVariable("BaseUri", "http://10.240.64.181:8080/api/");
	//Environment.SetEnvironmentVariable("OrgPassword", "password1234!"); //BUPA
	//var orgApiUrl = Environment.GetEnvironmentVariable("BaseUri");
	//var orgPassword = Environment.GetEnvironmentVariable("OrgPassword");
	
	//var orgApiUrl = Environment.GetEnvironmentVariable("WAVELENGTH_API_URL");
	//var orgPassword = Environment.GetEnvironmentVariable("WAVELENGTH_API_KEY");
	//orgApiUrl.Dump();
	//orgPassword.Dump();
	
	// gci env:windir
	// $env:windir
	// [gets different variables] get-variable
	//$Env:<variable-name> = "<new-value>"
	//$Env:path += ";c:\temp"
	
	var environmentVariables = new[]{("windir", ""), ("WAVELENGTH_API_URL", "http://plomeek:8888/api"), ("WAVELENGTH_API_KEY", "password")};
	environmentVariables.ToList().ForEach(ev => GetEnvironment(ev.Item1, ev.Item2).Dump(ev.Item1));
	
}

// Define other methods and classes here
string GetEnvironment(string variableName, string defaultValue = "") {
	return Environment.GetEnvironmentVariable(variableName) ?? defaultValue;
}