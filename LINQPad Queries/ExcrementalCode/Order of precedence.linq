<Query Kind="Statements" />

var alpha = "a"; // throws because conditional is not grouped
var result = alpha.Length >= 2 && (alpha[0] != 'a' || alpha[1] != 'b');
result.Dump();

var temp = new byte[2];
temp.Length.Dump();