<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	var counters = new CounterCollector();
	counters.TotalRecords++;
	counters.EmptyRecords++;
	Dump(counters);
}

// Define other methods and classes here
public class CounterCollectorBase{
}

public class CounterCollector : CounterCollectorBase
{
	[Description("Total number of records")]
	public int TotalRecords {get; set;}
	public int MismatchedIds {get; set;}
	public int EmptyRecords {get; set;}
}

public void Dump(CounterCollectorBase counters){
	var props = counters.GetType().GetProperties();
	foreach(var prop in props){
		Console.WriteLine($"{prop.Name}, {prop.GetCustomAttribute<DescriptionAttribute>()?.Description ?? ""}: {prop.GetMethod.Invoke(counters, null)}");
	}
}
