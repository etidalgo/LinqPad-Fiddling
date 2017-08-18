<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Expression, match.Success, matchAlternate.Success");
	foreach( var text in TestCases() ) {
		var match = Regex.Match(text, @"\[(\d+,?)+\]", RegexOptions.Compiled);
		var matchAlternate = Regex.Match(text, @"\[(?:(\d+),?)+\]", RegexOptions.Compiled);
		Console.WriteLine("\"{0}\", {1}, {2}", text, match.Success, matchAlternate.Success);
	}	
}

// Define other methods and classes here
IEnumerable<string> TestCases() {
	yield return "[1234,4321]";
	yield return "[1234,1234,4321]";
	yield return "[1234]";
	yield return "1234";
	yield return "1234,4321";
}