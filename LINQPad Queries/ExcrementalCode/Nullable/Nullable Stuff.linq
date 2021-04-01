<Query Kind="Program" />

#nullable enable

void Main()
{
	var stringWithUnsupportedCharacters = "alpha beta"; // "alpha\t beta\t";
	stringWithUnsupportedCharacters.Dump();
	stringWithUnsupportedCharacters.RemoveUnsupportedControlCharacters();
	stringWithUnsupportedCharacters.Dump();
}

// You can define other methods, fields, classes and namespaces here
public static class Extensions {
	public static string? RemoveUnsupportedControlCharacters(this string? value)
	{
	    if (value == null)
	        return null;
	    //making sure that there are no memory allocations when a 'control' char not found
		value.Length.Dump();
		var last = value.Length;

	    for (var end = value.Length; --end >= 0;)
	    {
			value[end].Dump();
			if (value[end].IsUnsupportedControlCharacter())
	            value = value.Remove(end, 1);
	    }
	    return value.Length == 0 ? null : value;
	}
	
	public static bool IsUnsupportedControlCharacter(this char c) =>
		c switch
		{
		    '\r' or '\n' or '\t' => false,
		    var other => char.IsControl(other)
		};
}
