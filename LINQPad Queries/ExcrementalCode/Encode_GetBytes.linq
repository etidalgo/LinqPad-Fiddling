<Query Kind="Program" />

void Main()
{
	System.Byte[] someBytes = null;
	System.Byte[] otherBytes = Encoding.Default.GetBytes(@"А б в г д е ё ж з и й к");
	System.String someString = Encoding.Default.GetString(otherBytes);
	Console.WriteLine(someString);
	
}

// Define other methods and classes here
