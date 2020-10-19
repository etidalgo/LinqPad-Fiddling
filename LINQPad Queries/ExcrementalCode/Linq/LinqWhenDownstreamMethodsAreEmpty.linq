<Query Kind="Statements" />

var ints = new[] { 1, 3, 5, 7 } ;
var oddSum = ints.Where(i => i % 2 == 1).Sum();
var evenSum = ints.Where(i => i % 2 == 0).Sum(); // sum on an empty ienumerable
oddSum.Dump("odd sum");
evenSum.Dump("even sum");
