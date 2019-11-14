<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

public static void Main()
{
	var samples = new[]{"Warp 10", 
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
	
	var moreSamples = "Warp 10,Orient,Target ship,Alert,Hail,Shields,Serve ice cream,Transport,Fire,Smarm,Unknown,Warp,Target,target";
	var splitSamples = moreSamples.Split(',').ToList();
	splitSamples
		.Where(sa => 
		{
			Action.Keyword key;
			return Enum.TryParse(sa, false, out key);
		})
		.Select(sa => Enum.Parse(typeof(Action.Keyword), sa, false))
		.Dump();

	var unrecognizedActions = splitSamples.Where(sa => 
		{
			Action.Keyword key;
			return !Enum.TryParse(sa, false, out key);
		});
		
	var recognizedActions = splitSamples.Except(unrecognizedActions);
	String.Join(",", recognizedActions).Dump();
	
	foreach(var keyword in Enum.GetValues(typeof(Action.Keyword))){
		Console.WriteLine(keyword.ToString());
	}
//	if(unrecognizedActions.Any())
//		throw new Exception ($"Unrecognized actions: {String.Join(",", unrecognizedActions)}");
		
}

public class Action {
	public enum Keyword {
		Unknown = -1,
		Warp = 1, 
		Orient = 2,
		Target = 4,
		Alert = 16, 
		Hail = 32,
		Shields = 8,
		Transport = 64,
		Fire = 128};
 
	// Enum.TryParse(TEnum) Method (String, Boolean, TEnum) (System) <https://msdn.microsoft.com/en-us/library/dd991317(v=vs.110).aspx>
	public static int GetAction( string str ) {
		Keyword keywordValue;
		if (Enum.TryParse( str, true, out keywordValue )) {
			Debug.Assert(Enum.IsDefined(typeof(Keyword), keywordValue), "If TryParse succeeds, this is always true.");
			return (int) keywordValue;
		}
		return -1;
	}
}

