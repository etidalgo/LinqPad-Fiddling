<Query Kind="Statements" />

// Attempting to detect static in an image. Looking to extend this example to a block from an image. 
var random = new Random();
var otherRandomNumbersInRange = Enumerable.Range(0, 10).ToList().Select(act => random.Next(0, 10)).ToList();
otherRandomNumbersInRange.Dump("Series");

var differences = otherRandomNumbersInRange.Skip(1).Zip(otherRandomNumbersInRange, (second, first) => Math.Abs(first - second));
differences.Dump("Differences");
differences.Sum().Dump("Sum");
differences.Dump("Differences");
differences.Count().Dump("Count");
(differences.Sum() / differences.Count()).Dump("Sum/Count truncated I think");

differences.Average().Dump("Average");
