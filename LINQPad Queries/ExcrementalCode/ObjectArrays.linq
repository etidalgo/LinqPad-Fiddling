<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
</Query>

void Main()
{
	var someArray = new object[] { 10, null, null };
	DumpArray(someArray);
	someArray.SetValue(21, 1);
	DumpArray(someArray);

	foreach( var anArray in TestCases() ) {
		DumpArray(anArray);
	}
}

IEnumerable<object[]> TestCases() {
	yield return new object[] { 10, null, null };
	var someArray = new object[7];
	yield return someArray;
	someArray.SetValue(13, 1);
	yield return someArray;
	yield return Enumerable.Repeat((object)null, 7).ToArray();

}

// Define other methods and classes here
void DumpArray(object[] someArray) {
	Console.WriteLine($"Array count: {someArray.Count()}");
	foreach( var obj in someArray ) {
		Console.WriteLine( "\t{0}", obj is null ? "null" : obj.ToString() );	
	}
}