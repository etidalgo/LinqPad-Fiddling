<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	var externalIds = (new[]{"1", "4", "21", "6", "99"}).ToList();
	var internalIds = await Lookup(externalIds);
// 	var internalIds = externalIds.Select(ex => ex.ToInternalId());
	externalIds.Dump();
	internalIds.Dump();
}

public Task<IEnumerable<string>> Lookup(IEnumerable<string>externalIds) =>
	Task.FromResult(externalIds.Select(ex => ex.ToInternalId()));
	
// You can define other methods, fields, classes and namespaces here
public static class Extensions{
	public static string ToInternalId(this string externalId) =>
		externalId switch {
			"1" => "3000000000001",
			"2" => "3000000000002",
			"3" => "3000000000003",
			"4" => "3000000000004",
			"5" => "3000000000005",
			"6" => "3000000000006",
			"7" => "3000000000007",
			"8" => "3000000000008",
			"9" => "3000000000009",
			"10" => "3000000000010",
			"11" => "3000000000011",
			"31" => "3000000000012",
			"99" => "3000000000013",
			_ => "3000000000006"
		};
}