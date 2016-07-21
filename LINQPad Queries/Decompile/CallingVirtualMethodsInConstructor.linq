<Query Kind="Program" />

void Main()
{
	// var simple1 = new SimpleThing();
	var simple2 = new LessSimpleThing();
	var simple3 = new OtherLessSimpleThing();
	
	SimpleThing[] simples = { simple2, simple3};
	foreach( var simple in simples ) {
		Console.WriteLine( "{0}: {1} {2}", simple.GetType().Name, simple.HierarchyTrackerOne, simple.HierarchyTrackerTwo);
	}
	
}

// Define other methods and classes here
abstract class SimpleThing {
	public string HierarchyTrackerOne { get; protected set; }
	public string HierarchyTrackerTwo { get; protected set; }
	public string TextMember { get; protected set; }
	public SimpleThing() {
		TextMember = "Some random letters";
		Setup();
	}
	
	protected abstract void Setup();
	
	virtual protected void SetupRunAfterMainConstructorBody() {
		HierarchyTrackerTwo = "SimpleThing";
	}
}

class LessSimpleThing : SimpleThing {
	public LessSimpleThing()
		:base()
	{
		SetupRunAfterMainConstructorBody();
	}
	
	override protected void Setup() {
		HierarchyTrackerOne = "LessSimpleThing";
	}

	override protected void SetupRunAfterMainConstructorBody() {
		HierarchyTrackerTwo = "LessSimpleThing";
	}
}

class OtherLessSimpleThing : SimpleThing {
	public OtherLessSimpleThing()
		:base()
	{
		SetupRunAfterMainConstructorBody();
	}
	
	override protected void Setup() {
		HierarchyTrackerOne = "OtherLessSimpleThing";
	}
}