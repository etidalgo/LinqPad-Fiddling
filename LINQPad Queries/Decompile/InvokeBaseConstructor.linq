<Query Kind="Program" />



void Main()
{
	
}

// Define other methods and classes here
class SimpleThing {
	public string Designation { get; protected set; }
	public SimpleThing() {
	}
	
	public SimpleThing( string name ) {
		Designation = name;
	}
}

class LessSimpleThing : SimpleThing {
	public LessSimpleThing() {
	}
	
	public LessSimpleThing( string name ) 
		: base(name)
	{
		// invalid call
		// base(name);
	}
}