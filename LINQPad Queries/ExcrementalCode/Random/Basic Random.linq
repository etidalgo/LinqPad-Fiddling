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
}

// Define other methods and classes here
public static class Extensions {
	public static T Random<T>(this IEnumerable<T>list){
		var ix = (new Random()).Next(list.Count());
		return list.ElementAt(ix);
	}
}