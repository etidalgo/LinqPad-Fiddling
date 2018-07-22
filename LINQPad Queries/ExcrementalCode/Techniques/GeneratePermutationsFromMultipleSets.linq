<Query Kind="Program" />

void Main()
{
	var ix = 0;
	var sets = new string[] { "bfg", "i", "tn", "s " };
	foreach (var permutation in GeneratePermutationsFromSets(sets)) {
		Console.WriteLine($"{++ix} {permutation}");
	}
	
}

// Define other methods and classes here
IEnumerable<string> GeneratePermutationsFromSets(IList<string> sets) {
	var firstSet = sets.First();
	if(sets.Count > 1) {
		var remainder = sets.Skip(1).ToList();
		foreach (var firstChar in firstSet) {
			foreach (var trailer in GeneratePermutationsFromSets(remainder)){
				var newPermutation = firstChar.ToString() + trailer;
				yield return newPermutation;
			}
		}
	} 
	else 
	{
		foreach (var firstChar in firstSet) {
			yield return firstChar.ToString();
		}
	}
}

IEnumerable<string> GeneratePermutationsFromCharSets(IList<IList<char>> sets) {
	yield return "";
}