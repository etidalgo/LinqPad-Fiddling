<Query Kind="Program" />

// Define other methods and classes here
void Main()
{
	foreach( var itemsAsDelimited in TestCases() ) {
		var items = !String.IsNullOrWhiteSpace(itemsAsDelimited) ? itemsAsDelimited.Split('|').Select(it => Int32.Parse(it)) : new List<int>{};
		Console.WriteLine(items);
	}	
}

// Define other methods and classes here
IEnumerable<string> TestCases() {
	yield return "393|572|097";
	yield return ""; // Causes Int32.Parse to fail
}
