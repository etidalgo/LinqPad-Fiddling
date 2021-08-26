<Query Kind="Program" />

void Main()
{
	IndexFinder.FindIndexes(new[]{ "PATFLDDFE307", "PATFLDDFE305"});
	IndexFinder.FindIndexes(new string[]{});
}

// You can define other methods, fields, classes and namespaces here
public static class IndexFinder {
	private static Array userMemoLabels = (new[]{ "PATFLDDFE304", "PATFLDDFE305", "PATFLDDFE306", "PATFLDDFE307", "PATFLDDFE308", "PATFLDDFE309" }).ToArray();
	private static IEnumerable<int> allIndexes = Enumerable.Range(1, 6);

	public static void FindIndexes(string[] testCase){
		testCase.Dump();
		var foundIndexes = testCase.Select(e => Array.IndexOf(userMemoLabels, e)).Where(i => i >= 0).Select(i => i + 1).OrderBy(i => i);
		foundIndexes.Dump();
		
		var notFoundIndexes = allIndexes.Except(foundIndexes);
		notFoundIndexes.Dump();
	}
}
