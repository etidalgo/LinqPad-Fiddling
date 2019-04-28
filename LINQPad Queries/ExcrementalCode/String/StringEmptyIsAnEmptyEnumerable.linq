<Query Kind="Statements" />

var emptyString = String.Empty;
var emptyStringIsIEnumerable = emptyString is System.Collections.IEnumerable;
var valueIsEmptyEnum = emptyString is System.Collections.IEnumerable enumerable && !enumerable.Cast<object>().Any();
Console.WriteLine(emptyStringIsIEnumerable );
Console.WriteLine(valueIsEmptyEnum);
