<Query Kind="Program" />

void Main()
{
	foreach( var (setA, setB) in TestCases() ) {
		Console.WriteLine("A: {0}      B: {1}", string.Join(", ", setA.Select(i => i.ToString())), string.Join(", ", setB.Select(i => i.ToString())));
		Console.WriteLine("Unordered SequenceEqual: {0}", setA.SequenceEqual(setB));
		var except = setA.Except(setB).Select(ix => ix.ToString());
		Console.WriteLine("setA except setB contains: {0}", string.Join(", ", except));
		Console.WriteLine("!setA.Except(setB).Any(): {0}", !setA.Except(setB).Any());
		Console.WriteLine("Ordered SequenceEqual: {0}", setA.OrderBy(i => i).SequenceEqual(setB.OrderBy(i => i)));
	}	
}

// Define other methods and classes here
IEnumerable<(IEnumerable<int> setA, IEnumerable<int> setB)> TestCases() {
	yield return (new int[]{1, 3, 2 }, new int[]{3, 1, 2 });
	yield return (new int[]{1, 3, 2, 4 }, new int[]{3, 1, 2 });
	yield return (new int[]{1, 3, 2 }, new int[]{3, 1, 2, 4 });
	yield return (new int[]{1, 3, 2, 5 }, new int[]{3, 1, 2, 7 });
}