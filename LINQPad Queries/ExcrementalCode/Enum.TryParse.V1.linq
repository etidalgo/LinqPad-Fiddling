<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

public static void Main()
{
	string[] samples = {"Warp 10", 
						"Orient",
						"Target ship",
						"Alert", 
						"Hail",
					    "Shields",
					    "Serve ice cream",
					    "Transport",
					    "Fire",
					    "Smarm",
						"Unknown",
						"Warp",
						"Target",
						"target"};

	foreach( var term in samples ){
	 int actionValue = Action.GetAction( term );
	 if ( actionValue < 0 ) {
		 Console.WriteLine($"Not action: {term}  Returned: {actionValue}");
	 } else {
		 Console.WriteLine($"Action: {term}");
	 }
	}
}

public class Action {
	public enum Keyword {
		Unknown = -1,
		Warp = 1, 
		Orient,
		Target,
		Alert, 
		Hail,
		Shields,
		Transport,
		Fire };
 
	// Enum.TryParse(TEnum) Method (String, Boolean, TEnum) (System) <https://msdn.microsoft.com/en-us/library/dd991317(v=vs.110).aspx>
	static public int GetAction( string str ) {
		Keyword keywordValue;
		if (Enum.TryParse( str, true, out keywordValue )) {
			if (Enum.IsDefined(typeof(Keyword), keywordValue)){ // this is redundant
				return (int) keywordValue;
			}
			return -2;
		}
		return -1;
	}
}

