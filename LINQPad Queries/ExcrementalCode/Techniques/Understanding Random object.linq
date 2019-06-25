<Query Kind="Statements" />

"You would think this would generate a series of different numbers, but Random is really pseudo-random.".Dump();
"It seeded at instantiation with a time-dependent value. Instances in this loop likely end up with the same seed.".Dump();
var bunchOfRandomNumbersFirstAttempt = Enumerable.Range(0, 10).ToList().Select(act => (new Random()).Next());
bunchOfRandomNumbersFirstAttempt.Dump();

"The pseudo-randomness comes from the algorithm.".Dump();
var random = new Random();
var bunchOfRandomNumbers = Enumerable.Range(0, 10).ToList().Select(act => random.Next());
bunchOfRandomNumbers.Dump();

"Linq expressions may be reevaluated.".Dump();
var otherRandomNumbersInRange = Enumerable.Range(0, 10).ToList().Select(act => random.Next(0, 10));
otherRandomNumbersInRange.Dump("otherRandomNumbersInRange - First dump");
otherRandomNumbersInRange.Dump("otherRandomNumbersInRange - Second dump may not match the first.");

var seriesAsAList = Enumerable.Range(0, 10).ToList().Select(act => random.Next(0, 10)).ToList();
seriesAsAList.Dump("seriesAsAList - First dump");
seriesAsAList.Dump("seriesAsAList - Second dump");