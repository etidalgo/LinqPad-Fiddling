<Query Kind="Program" />

#nullable enable
void Main()
{
	var lookup = 
	new[]{ 
		new Entry{ ID = 1, Value = "alpha" }
	}.ToLookup(ix => ix.ID, ix => ix.Value);
}

// You can define other methods, fields, classes and namespaces here
public class Entry {
	public int ID {get; init; }
	public string? Value {get; init; }
}
