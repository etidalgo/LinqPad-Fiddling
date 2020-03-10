<Query Kind="Statements" />

var listOne = new List<string>{ "Patient Picture", "schwartz", "kirby", "lee", "infantino", "fox" };
var listTwoWithCaseVariations = new List<string>{ "SCHWARTZ", "INFANTINO", "broome", "giella" };

listOne.Contains("patieNT picTURE").Dump("Should be true");
listOne.Contains("patieNT picTURE", StringComparer.OrdinalIgnoreCase).Dump("Should be true");
listOne.Contains("kirby", StringComparer.OrdinalIgnoreCase).Dump("Should be true");
listOne.Contains("KIRBY", StringComparer.OrdinalIgnoreCase).Dump("Should be true");
var listOneMinusTwo = listOne.Except(listTwoWithCaseVariations, StringComparer.OrdinalIgnoreCase);

var matching =
	from m in listOne
	where listTwoWithCaseVariations.Contains(m)
	select m;

matching.Dump();

var matching2 =
	from m in listOne
	where listTwoWithCaseVariations.Contains(m, StringComparer.OrdinalIgnoreCase)
	select m;

matching2.Dump();