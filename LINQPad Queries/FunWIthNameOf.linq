<Query Kind="Program" />

void Main()
{
	Nebulous[] bunch = { new Nebulous(), new Vague(), new IllDefined() };
	foreach( var @object in bunch ) {
		@object.ReportError("\"No Error\" error");
	}
}

// Define other methods and classes here...and don't give them adjectival names, use "Nebulous" instead of "NebulousClass"
class Nebulous {
	public string PublicBaseMember = "";
	protected string ProtectedBaseMember = "";
	public Nebulous() {
	}
	
	public virtual void DoAction( Nebulous nebulous ) {
	}

	public virtual void ReportError( string description ) {
		Console.WriteLine("Style 1: Object[{0}] reporting error: {1}", this.GetType().Name, description);
		// Console.WriteLine("Style 1: Object[{0}] reporting error: {1}", nameof(this), description);
	}
}

class Vague : Nebulous{
	public Vague()
		:base()
	{
	}
	
	public override void DoAction( Nebulous nebulous ) {
	}
}

class IllDefined : Nebulous{
	public IllDefined()
		:base()
	{
	}
}

// Abstract, Defined, Specific, Instance