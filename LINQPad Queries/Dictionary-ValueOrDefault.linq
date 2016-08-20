<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

// See also c# - Is there an IDictionary implementation that, on missing key, returns the default value instead of throwing? - Stack Overflow <http://stackoverflow.com/questions/538729/is-there-an-idictionary-implementation-that-on-missing-key-returns-the-default>
public static class DictionaryExtensions {
	public static string ValueOrDefault( this Dictionary<string, string> dictionary, string key, string defString = "<empty>" ) {
		string someValue;
		return dictionary.TryGetValue(key, out someValue ) ? someValue : defString;
	}
}

public class Program
{
	public static void Main()
	{
		string someString = "Data Source=LocalSQLServer;Initial Catalog=ThisCatalog;User ID=secretUser; Password=secretPassword;Name=bogusValue;Reference=bozopedia";
		string[] pairs = someString.Split(';');
		Dictionary<string,string> connectionValues = new Dictionary<string,string>();
		foreach( var pair in pairs ) {
			string[] assignment = pair.Split('=');
			connectionValues.Add( assignment[0].Trim(), assignment[1].Trim() );
		}

		Console.WriteLine( "Reference: {0}", connectionValues["Reference"]);
		// test for value with ContainsKey
		Console.WriteLine( "InvalidKey1: {0}", connectionValues.ContainsKey("InvalidKey1") ? connectionValues["InvalidKey1"] : "Not Found" );
		// use TryGetValue
		string someValue = "";
		Console.WriteLine( "InvalidKey2: {0}", connectionValues.TryGetValue("InvalidKey2", out someValue ) ? someValue : "<empty>");
		// use DictionaryExtensions
		Console.WriteLine( "InvalidKey3: {0}", connectionValues.ValueOrDefault("InvalidKey3", "<not found>") );
	}
}