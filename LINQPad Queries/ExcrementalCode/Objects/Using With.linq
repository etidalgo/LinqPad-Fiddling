<Query Kind="Program" />

void Main()
{
	var thing1 = new Thingy("one");
	var thing2 = thing1 with { Name = "bob" };
}

// You can define other methods, fields, classes and namespaces here
public class Thingy {
	public string Name {get; init; }
	
	public Thingy(string name) => this.Name = name;
}
