<Query Kind="Program" />

#nullable enable

void Main()
{
	var Searchtel = "20202020";
	string Mobiletel = null;
	string Hometel = null;
	
	var shouldUse = Searchtel.IsNonBlank() && !(Searchtel == Mobiletel || Searchtel == Hometel);
	shouldUse.Dump();
}

// You can define other methods, fields, classes and namespaces here
public static class Extensions {
	public static bool IsNonBlank(this string value) => !string.IsNullOrEmpty(value);
	
    public static string? TrimEx(this string? value) =>
        value?.Trim().NullIfEmpty();

    public static string? NullIfEmpty(this string? value)
    {
        value = value?.Trim();
        return value == string.Empty ? null : value;
    }	
}