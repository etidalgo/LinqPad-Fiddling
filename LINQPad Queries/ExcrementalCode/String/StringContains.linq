<Query Kind="Statements" />

List<string> bunchOfStrings = new List<string>(new[]{"alpha", (string)null, "vinyl", "lp", "tape", "pulp", "alps", "ALPS" });

bunchOfStrings.ForEach(str => Console.WriteLine($"Value: {str}"));
bunchOfStrings.ForEach(str => Console.WriteLine($"{str} {str?.Contains("lp")}"));