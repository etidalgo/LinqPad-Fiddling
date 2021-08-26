<Query Kind="Program" />

void Main()
{
	string someString = "alpha\0\0";
	someString.Length.Dump($"String length for [{someString}]");
	
	someString.Trim().Dump();
	var moreWhiteSpace = "beta \t\n\r\f\v ";
	moreWhiteSpace.Dump();
	moreWhiteSpace.Length.Dump();
	var trimmed = moreWhiteSpace.Trim();
	trimmed.Dump();
	trimmed.Length.Dump();
	string notherString = "boll\0ocks";
	notherString.Dump();
}

// You can define other methods, fields, classes and namespaces here
