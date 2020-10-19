<Query Kind="Program" />

void Main()
{
	var conjunctions = new[]{"and", "but", "or"};
	var phrase = "when in the course of human events";
	phrase.Excludes(conjunctions).Dump();
	phrase.Excludes("alpha", "beta").Dump();
	phrase.Excludes("up", "down", "in", "out").Dump();
}

// Define other methods and classes here
public static class StringExtensions {
	public static bool Excludes(this string value, params string[] exclusions){
		return exclusions.All(ex => !value.Contains(ex));
	}
}