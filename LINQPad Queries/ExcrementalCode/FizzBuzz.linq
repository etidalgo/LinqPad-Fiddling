<Query Kind="Program" />

void Main()
{
	var number = Int();
	number.Take(1).Dump();
	number.Take(1).Dump();
	number.Take(1).Dump();
	var fizz = FizzSeries();
	fizz.Take(1).Dump();
	fizz.Take(1).Dump();
	fizz.Take(1).Dump();
	var buzz = BuzzSeries();
	var fizz1 = fizz;
	var buzz1 = buzz;
	Enumerable.Range(1,100).ToList().ForEach( ix => 
	{
		Console.WriteLine($"{ix} {fizz.Skip(ix-1).First()} {buzz.Skip(ix-1).First()}");
		Console.WriteLine($"{ix}.1 {fizz1.First()} {buzz1.First()}"); // fizz1.First() = fizz1.Take(1).First()
		fizz1 = fizz1.Skip(1);
		buzz1 = buzz1.Skip(1);
	});
}

// Define other methods and classes here
public IEnumerable<string> FizzSeries(){
	while(true){
		yield return "";
		yield return "";
		yield return "fizz";
	}
}

public IEnumerable<string> BuzzSeries(){
	while(true){
		yield return "";
		yield return "";
		yield return "";
		yield return "";
		yield return "buzz";
	}
}

public IEnumerable<int> Int(){
	var ix = 0;
	while(true){
		yield return ix++;
	}
}
