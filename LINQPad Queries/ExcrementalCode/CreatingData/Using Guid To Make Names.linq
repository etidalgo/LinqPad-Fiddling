<Query Kind="Statements" />

var guid = Guid.NewGuid().ToString();
guid.Dump();
guid.Length.Dump();
var (first, last) = (guid.Substring(0, 13), guid.Substring(14));

Console.WriteLine($"Name: {first} {last}");