<Query Kind="Statements" />

var byteArray = Enumerable.Range(1,32).Select(x => (byte)0).ToArray();
byteArray.Dump();