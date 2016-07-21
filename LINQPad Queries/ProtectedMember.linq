<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here...and don't give them adjectival names
class Nebulous {
	// Not allowed 	
	public string PublicBaseMember;
	protected string ProtectedBaseMember;
	public Nebulous() {
	}
	
	public virtual void DoAction( Nebulous nebulous ) {
	}
}

class Vague : Nebulous{
	public Vague()
		:base()
	{

	}
	
	public override void DoAction( Nebulous nebulous ) {
		Console.WriteLine( ProtectedBaseMember ); // can access inherited member even if protected
		Console.WriteLine( nebulous.PublicBaseMember ); // can access others' Public members
		// Console.WriteLine( nebulous.ProtectedBaseMember ); // cannot access others' Protected member 
	}
}

// Abstract, Defined, Specific, Instance
