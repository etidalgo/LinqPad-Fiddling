<Query Kind="Program" />

void Main()
{
	var daysAgo = -400;
	var maxSessions = 2000; // approx right for 400 days to ensure reasonable density of messages over time
	var start = DateTime.Now.AddDays(daysAgo); 
	var team = GetTeams().Skip(2).Take(1).First();
	team.Dump();

	var conversationHistory = GenerateHistory(team, start).Take(maxSessions).Where(ch => (ch.Last()).timestamp < DateTime.Now).ToList();
	var totalMessages = conversationHistory.Aggregate(0, (total, session) => total + session.Count());
	conversationHistory.Count().Dump();
	totalMessages.Dump();
	// conversationHistory.ForEach(ch => Console.WriteLine(ch.First().timestamp));
	conversationHistory.Skip(conversationHistory.Count()-5).Dump();
	
	var team2 = GetTeams().Skip(3).Take(1).First();
	var conversationHistory2 = GenerateHistory(team2, start).Take(maxSessions).Where(ch => (ch.Last()).timestamp < DateTime.Now).ToList();
	var totalMessages2 = conversationHistory2.Aggregate(0, (total, session) => total + session.Count());
	conversationHistory2.Count().Dump();
	totalMessages2.Dump();
	conversationHistory2.Skip(conversationHistory2.Count()-5).Dump();	
}

// Define other methods and classes here
public IEnumerable<IEnumerable<string>> GetTeams(){
	var teams = new[]{ 
		new[]{"iouri", "metodi"}.ToList(), 
		new[]{"iouri", "guy"}.ToList(), 
		new[]{"metodi", "sylvain"}.ToList(), 
		new[]{"sylvain", "iouri"}.ToList(), 
		new[]{"sylvain", "ernest"}.ToList() }.ToList();
	return teams;
}

public IEnumerable<IEnumerable<(string sender, string message, DateTime timestamp)>> GenerateHistory(IEnumerable<string> users, DateTime start){
	var sessionStart = start;
	while(true){
		var conversation = GenerateSession(users, sessionStart);
		yield return conversation;
		var sessionEnd = (conversation.Last()).timestamp;
		sessionStart = sessionEnd.AddMinutes(Randomizer.Random.Next(37, 701));
	}
}

public IEnumerable<(string sender, string message, DateTime timestamp)> GenerateSession(IEnumerable<string> users, DateTime start){
	var sessionCount = Randomizer.Random.Next(3, 17);
	var sessionMessages = GenerateMessage().Take(sessionCount).ToList(); // yes you need ToList to materialize the series
	var sessionTimestamps = GenerateTimeStamps(start).Take(sessionCount).ToList();
	
	var conversationSession = sessionMessages.Zip(sessionTimestamps, (message, timestamp) => (users.Random(), message, timestamp));
	return conversationSession;
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

public static class Randomizer {
	public static Random Random = new Random();
}

public static class Extensions {
	public static T Random<T>(this IEnumerable<T>list){
		var ix = Randomizer.Random.Next(list.Count());
		return list.ElementAt(ix);
	}
}