<Query Kind="Program" />

void Main()
{
	var alpha = new[]{"a", "b", "c"};
	var largeGroup = 
		from a in alpha
		group a by a into agroup
		select agroup;

	largeGroup.Select((a, i) => $"{a} {i}").Dump();
}

// Define other methods and classes here
