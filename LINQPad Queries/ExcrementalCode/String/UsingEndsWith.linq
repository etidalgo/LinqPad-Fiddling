<Query Kind="Program" />

void Main()
{
	new[]{ "alpha", "beta", "alpha-b", "alpha-bu", "alpha-bup", "alpha-bupa", "alpha-bupaa", "alpha-bupaadup" 
	}.ToList().ForEach(st => TrimIfFound(st));
}

// Define other methods and classes here
void TrimIfFound(string someString) {
	var trimmed = (someString.EndsWith("-Bupa", StringComparison.OrdinalIgnoreCase))
	                ? someString.Substring(0, someString.Length - 5)
	                : someString;
	trimmed.Dump();
}