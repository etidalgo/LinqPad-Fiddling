<Query Kind="Program" />

void Main()
{
			Console.WriteLine( "string: " + default(string) );
		Console.WriteLine("Hello World");
		ClauseBuilder cb = new ClauseBuilder( "world is flat" );
		Console.WriteLine( " cb: " + cb );
		cb.And("sky is falling");
		Console.WriteLine( " cb: " + cb );
		cb.Or("pigs are flying");
		Console.WriteLine( " cb: " + cb );
		
		ClauseBuilder cb1 = new ClauseBuilder( "oceans are boiling" );
		ClauseBuilder cb2 = new ClauseBuilder( "dogs and cats are raining" );
		cb1.And(cb2);
		Console.WriteLine( " cb1: " + cb1 );
}

// Define other methods and classes here
public class ClauseBuilder  {
		
		public string MainClause { get; protected set; }
		public bool IsAddPadding { get; protected set; } // difference between ( clause ) vs (clause)
		
		public ClauseBuilder( string clause = "" ) {
			MainClause= clause;
		}
		
		public ClauseBuilder And( string subClause) {
			Conjunct("And", subClause );
			return this;
		}

		public ClauseBuilder Or( string subClause) {
			Conjunct("Or", subClause );
			return this;
		}
		
		private void Conjunct(string conjunction, string subClause) {
			subClause.Trim();
			if ( !String.IsNullOrEmpty(subClause) ) {
				MainClause = String.Format( "( {0} ) {1} ( {2} )", MainClause, conjunction, subClause );
			}
		}			
		
		public static implicit operator string ( ClauseBuilder cb ) {
			return cb.MainClause;
		}
	}
