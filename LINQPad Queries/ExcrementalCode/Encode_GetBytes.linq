<Query Kind="Program" />

void Main()
{
	System.Byte[] nullBytes = null;
	System.Byte[] emptyBytes = new System.Byte[0];
	// Array.Clear(emptyBytes, 0, 0); - not needed
	System.Byte[] otherBytes = Encoding.Default.GetBytes(@"А б в г д е ё ж з и й к");
	System.String someString = Encoding.Default.GetString(emptyBytes);
	Console.WriteLine("\"{0}\" Length: {1}", someString, someString.Length);
	
}

// Define other methods and classes here
