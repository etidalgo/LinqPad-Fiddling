<Query Kind="Program" />

void Main()
{
	var phrases = new[]{"make people awesome", "make safety a prerequisite", "experiment and learn rapidly", "delivery value continuously", "respect and appreciate people", "apply lean ux", 
	"charter your work", "leverage lean startup", "make it safe to fail", "conduct blameless retrospectives", "evolve solutions", 
	"collaborate and integrate frequently", "deploy and release continuously", "test and refactor", "form product communities", 
	"focus on flow"};
	
	Enumerable.Range(1,3).ToList().ForEach(a => Console.WriteLine(a) );
	phrases.ToList().Random().Dump();
	var rnd = new Random();
	rnd.Next(7, 13).Dump();	
	
	var sessionCount = Randomizer.Random.Next(3, 17);
	sessionCount.Dump();
	var sessionMessages = GenerateMessage().Take(sessionCount).ToList(); // materialize
	sessionMessages.Count().Dump();
	sessionMessages.Dump();
	sessionMessages.Dump(); // prove the sequence is materialized
	
	var sessionTimestamps = GenerateTimeStamps(DateTime.Now.AddDays(-10)).Take(sessionCount).ToList(); // materialize
	sessionTimestamps.Dump();
	sessionTimestamps.Dump(); // prove the sequence is materialized
}

// Define other methods and classes here
public (string,string)[] GetTeams(){
	var teams = new[]{ 
		("iouri", "metodi"), 
		("iouri", "guy"), 
		("metodi", "sylvain"), 
		("sylvain", "iouri"), 
		("sylvain", "ernest") };
	return teams;
}

public IEnumerable<string> GenerateMessage(){
	var phrases = new[]{"make people awesome", "make safety a prerequisite", "experiment and learn rapidly", "delivery value continuously", "respect and appreciate people", "apply lean ux", 
	"charter your work", "leverage lean startup", "make it safe to fail", "conduct blameless retrospectives", "evolve solutions", 
	"collaborate and integrate frequently", "deploy and release continuously", "test and refactor", "form product communities", 
	"focus on flow"}.ToList();
	
	while(true){
		yield return phrases.Random();
	}
}

public IEnumerable<DateTime> GenerateTimeStamps(DateTime start){
	yield return start;
	
	var next = start;
	while(true){
		next = next.AddSeconds(Randomizer.Random.Next(3, 120));
		yield return next;
	}
}

public void GenerateConversationHistory(){
}

public static class Randomizer {
	public static Random Random = new Random();
}

public static class Extensions {
	public static T Random<T>(this IEnumerable<T>list){
		var ix = Randomizer.Random.Next(list.Count());
		return list.ElementAt(ix);
	}
}
