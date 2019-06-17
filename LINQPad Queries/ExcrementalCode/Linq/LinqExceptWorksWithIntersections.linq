<Query Kind="Statements" />

var listOne = new List<string>{ "schwartz", "kirby", "lee", "infantino", "fox" };
var listTwo = new List<string>{ "schwartz", "infantino", "broome", "giella" };
var listThree = new List<string>{ "schwartz", "fox", "sekowsky" };

var listOneMinusTwo = listOne.Except(listTwo);
listOneMinusTwo.Dump("listOne minus listTwo");
listOneMinusTwo.Except(listThree).Dump("result minus listThree");

Console.WriteLine("Linq Except removes the intersection of two sets, does not error if set 1 is not a superset of set 2");