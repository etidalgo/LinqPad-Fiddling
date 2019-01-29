<Query Kind="Program" />

void Main()
{
	/*
		[Lazy Evaluation (and in contrast, Eager Evaluation) – Eric White's Blog] (https://blogs.msdn.microsoft.com/ericwhite/2006/10/04/lazy-evaluation-and-in-contrast-eager-evaluation/)
		[IEnumerable is Lazy… And That’s Cool | Brian Reiter's Thoughtful Code] (https://brianreiter.org/2011/01/14/ienumerable-is-lazy-and-thats-cool/)
		[Dixin's Blog - LINQ to Objects (4) Deferred Execution, Lazy Evaluation and Eager Evaluation] (https://weblogs.asp.net/dixin/linq-to-objects-deferred-execution-lazy-evaluation-and-eager-evaluation)
		[Classification of Standard Query Operators by Manner of Execution (C#) | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/classification-of-standard-query-operators-by-manner-of-execution)	
	*/
	var originalSequence = Enumerable.Range(1, 5);

	var nonmaterializedSequence = originalSequence.Select(a => new ProteanObject()); // Select is lazy evaluation
	Console.WriteLine("Nonmaterialized Sequence");
	UpdateAndDumpSequence(nonmaterializedSequence);
	
	var materializedSequence = originalSequence.Select(a => new ProteanObject()).ToList(); // ToList is immediate evaluation
	Console.WriteLine("Materialized Sequence");
	UpdateAndDumpSequence(materializedSequence);
}

// Define other methods and classes here
public class ProteanObject 
{
    public int ObjectMember { get; set; }
}

public static class BelongExtensions {
    public static void Iter<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        foreach (var item in enumerable.EmptyIfNull())
        {
            action(item);
        }
    }
		
    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> items) =>
        items ?? Enumerable.Empty<T>();
}

void UpdateAndDumpSequence(IEnumerable<ProteanObject> sequence) {
	sequence.Iter(a => Console.WriteLine("\tOriginal value: " + a.ObjectMember));
	var newValue = 13;
	sequence.Iter(a => a.ObjectMember = newValue);
	sequence.Iter(a => Console.WriteLine("\tProteanObjects Updated 2: " + a.ObjectMember));
}
