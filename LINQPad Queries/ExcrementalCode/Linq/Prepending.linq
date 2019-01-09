<Query Kind="Program" />

void Main()
{
		string[] fields = new string[4]{"Meat", "Breath", "Day", "Breakfast" };

		Console.WriteLine("Join array items ------");
		string foolFields = String.Join(",", fields);
		Console.WriteLine(foolFields);
		
		Console.WriteLine("prepend with foreach ---------");
		string prefix = "Dog.";
		foreach( var field in fields ) {
			field.Insert(0, prefix);
			Console.WriteLine(field.Insert(0, prefix));
		}
		
		Console.WriteLine("Use .Select to prepend ---------");
		// using System.Linq; Select is an extension method
		string[] fields2 = fields.Select( x => x.Insert(0, prefix) ).ToArray();
		Console.WriteLine( String.Join(",", fields2));

		Console.WriteLine("Use Extension methods to prepend ---------");
		Console.WriteLine( "Tail".Prefix("Dog."));
		
		string[] fields3 = fields.Prefix("Dog.");
		Console.WriteLine( String.Join(",", fields3));	
}

// Define other methods and classes here
	public static class ETiExtensions
	{
		public static string Prefix( this string str, string prefix ) 
		{
			return str.Insert(0, prefix);
		}
		public static string[] Prefix( this string[] strArray, string prefix ) 
		{
			return strArray.Select( x => x.Insert(0, prefix) ).ToArray();
		}
	}