<Query Kind="Statements" />

"alpha".ToCharArray().Count().Dump();

var chars = "infin itive".ToCharArray().Where(ch => ch != ' ');
var text = new string(chars.ToArray());
text.Dump();
