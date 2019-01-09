<Query Kind="Program" />

/*
[Abstract and Sealed Classes and Class Members - C# Programming Guide | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)
[How to: Define Abstract Properties - C# Programming Guide | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-define-abstract-properties)
*/

void Main()
{
	(new SomeActualClass()).DoSomething();
	(new AnotherActualClass()).DoSomething();
	(new YetAnotherActualClass()).DoSomething();
	
	Console.WriteLine("Trying var whatClass = new YetAnotherActualClass() as BaseAbstractClass;");
	var whatClass = new YetAnotherActualClass() as BaseAbstractClass;
	whatClass.DoSomething();
}

// Define other methods and classes here
public interface ISomeInterface {
	void DoSomething();
	void DoSomethingElse();
	void DoStillSomethingElse();
}

public abstract class BaseAbstractClass : ISomeInterface {
	public void DoSomething() => Console.WriteLine("This is BaseAbstractClass Doing something");
	abstract public void DoSomethingElse(); // abstract means "It is not implemented. Inheritors MUST implement."
	public void DoStillSomethingElse() => Console.WriteLine("This is BaseAbstractClass Doing still something else");
	virtual public void DoSomethingCompletelyDifferent() => Console.WriteLine("This is BaseAbstractClass Doing something completely different"); // use the implementation inherent to the running class
}

public class SomeActualClass : BaseAbstractClass {
	override public void DoSomethingElse() => Console.WriteLine("This is SomeActualClass Doing something else");
}

public class AnotherActualClass : BaseAbstractClass {
	new public void DoSomething() => Console.WriteLine("This is AnotherActualClass new-ing over DoSomething");
	override public void DoSomethingElse() => Console.WriteLine("This is AnotherActualClass overriding Doing something else");
}

public class YetAnotherActualClass : BaseAbstractClass {
	new public void DoSomething() { 
		Console.WriteLine("This is YetAnotherActualClass new-ing over DoSomething and calling Base"); 
		base.DoSomething();
		}
	override public void DoSomethingElse() => Console.WriteLine("This is YetAnotherActualClass overriding Doing something else");
}

