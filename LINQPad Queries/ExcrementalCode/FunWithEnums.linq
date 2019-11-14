<Query Kind="Program" />

void Main()
{
	var conditions = new[]{ArtifactCondition.Fair, ArtifactCondition.Mint };
    var conditionsCSV = conditions.Select(xlt => xlt.ToString()).Concatenate(",");
	conditionsCSV.Dump();
	

	Console.WriteLine(ArtifactCondition.Fair);
	Console.WriteLine("-------------");

	var nameColumnWidth = 15;
	var countColumnWidth = 10;
	Console.WriteLine("{0}{1}", "Formatted".PadRight(nameColumnWidth), "$".PadLeft(countColumnWidth));
	foreach (ArtifactCondition artifactCondition in Enum.GetValues(typeof(ArtifactCondition))) {
		Console.WriteLine("{0}{1}",  artifactCondition.ToString().PadRight(nameColumnWidth), String.Format($"{artifactCondition}").PadLeft(countColumnWidth));
	}
}

public static class StringExtensions {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> items) =>
            items ?? Enumerable.Empty<T>();

	public static string Concatenate(this IEnumerable<string> items, string separator) =>
        string.Join(separator, items.EmptyIfNull());
}

public enum ArtifactCondition {
	Poor,
	Fair,
	VeryFair,
	Good,
	VeryGood,
	Excellent,
	Mint,
	Pristine };

void PrintCounts(Dictionary<string,int> counts) {
	var nameColumnWidth = 15;
	var countColumnWidth = 10;
	Console.WriteLine("{0}{1}", "Name".PadRight(nameColumnWidth), "Count".PadLeft(countColumnWidth));
	foreach( var count in counts ) {
		Console.WriteLine("{0}{1}",  count.Key.PadRight(nameColumnWidth), count.Value.ToString().PadLeft(countColumnWidth));
	}
}