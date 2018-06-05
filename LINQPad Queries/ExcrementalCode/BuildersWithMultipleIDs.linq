<Query Kind="Program" />

void Main()
{
	var builderWithSingleId = new BuilderClassWithOneId()
		.WithId(9)
		.WithId(13); // overwrites the first call
		
	ShowIds("None", new BuilderClassWithZeroOrMoreIds());
	ShowIds("Zero", new BuilderClassWithZeroOrMoreIds().WithIds());
	ShowIds("One", new BuilderClassWithZeroOrMoreIds().WithIds(7));
	ShowIds("Several", new BuilderClassWithZeroOrMoreIds().WithIds(9, 13, 17)); // accepts all values
}

// Define other methods and classes here
public class BuilderClassWithOneId{
	public int? _singleId;

    public BuilderClassWithOneId WithId(int id) {
		_singleId = id;
		return this;
	}
}

public class BuilderClassWithZeroOrMoreIds {
	public List<int> _ids = new List<int>();

    public BuilderClassWithZeroOrMoreIds WithIds(params int[] ids)
    {
        _ids = ids.ToList();
        return this;
    }
}

void ShowIds(string desc, BuilderClassWithZeroOrMoreIds builder) {
	Console.WriteLine(desc);
	foreach(var id in builder._ids) {
		Console.WriteLine($" Id: {id}");
	}
}
