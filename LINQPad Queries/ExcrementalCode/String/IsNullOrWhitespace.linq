<Query Kind="Program" />

void Main()
{
	var strs = new string[] { null, "", string.Empty, "   ", "alpha" } ;
	strs.ToList().ForEach(str => string.IsNullOrWhiteSpace(str).Dump() );

	strs.ToList().ForEach(str => string.IsNullOrEmpty(str).Dump() );
}

// You can define other methods, fields, classes and namespaces here