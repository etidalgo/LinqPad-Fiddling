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
	var nameColumnWidth = 15;
	var countColumnWidth = 10;
	Console.WriteLine("{0}{1}", "Name".PadRight(nameColumnWidth), "Count".PadLeft(countColumnWidth));
	foreach( var count in counts ) {
		Console.WriteLine("{0}{1}",  count.Key.PadRight(nameColumnWidth), count.Value.ToString().PadLeft(countColumnWidth));
	}
}