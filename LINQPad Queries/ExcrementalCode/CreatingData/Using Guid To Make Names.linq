<Query Kind="Statements" />

var guid = Guid.NewGuid();
var first = guid.ToString().Substring(0, 13);
var last =  guid.ToString().Substring(14);
guid.Dump();
Console.WriteLine($"{first} {last}");