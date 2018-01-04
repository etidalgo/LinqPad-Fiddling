<Query Kind="Program" />

void Main()
{
	Console.WriteLine(ArtifactCondition.Fair);

	var nameColumnWidth = 15;
	var countColumnWidth = 10;
	Console.WriteLine("{0}{1}", "Formatted".PadRight(nameColumnWidth), "$".PadLeft(countColumnWidth));
	foreach (ArtifactCondition artifactCondition in Enum.GetValues(typeof(ArtifactCondition))) {
		Console.WriteLine("{0}{1}",  artifactCondition.ToString().PadRight(nameColumnWidth), String.Format($"{artifactCondition}").PadLeft(countColumnWidth));
	}
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