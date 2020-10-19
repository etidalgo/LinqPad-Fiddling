<Query Kind="Program" />

void Main()
{
	var reviewerCounts = new Dictionary<string,int>{
		{ "alpha", 0 },
		{ "beta", 0}
	};
	
	reviewerCounts["beta"]++;
	PrintCounts(reviewerCounts);
}

// Define other methods and classes here
void PrintCounts(Dictionary<string,int> counts) {
	const int nameColumnWidth = 15;
	const int countColumnWidth = 10;
	Console.WriteLine("{0}{1}", "Name".PadRight(nameColumnWidth), "Count".PadLeft(countColumnWidth));
	foreach( var count in counts ) {
		Console.WriteLine("{0}{1}",  count.Key.PadRight(nameColumnWidth), count.Value.ToString().PadLeft(countColumnWidth));
	}
	
	// [Formatting types in .NET | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types?view=netframework-4.7.2)
	//  The string is right-aligned in the field if the field width is a positive value, and it is left-aligned if the field width is a negative value. 
	Console.WriteLine("{0,-15}{1,-10}", "Name", "Count");
	counts.ToList().ForEach(ct => Console.WriteLine("{0,-15}{1,-10}",  ct.Key, ct.Value.ToString()));
	// ugly because of variable spacing, cannot use fixed width in Linqpad
	
	Console.WriteLine($"{"Name",-nameColumnWidth}{"Count",-countColumnWidth}");
	counts.ToList().ForEach(ct => Console.WriteLine($"{ct.Key,-countColumnWidth}{ct.Value.ToString(),-countColumnWidth}"));
}