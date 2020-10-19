<Query Kind="Statements" />

// Alternatively, do a left outer then a right outer
// [c# - LINQ - Full Outer Join - Stack Overflow] (https://stackoverflow.com/questions/5489987/linq-full-outer-join)

// full outer join 
var sequenceOne = new [] { "alpha", "gamma" };
var sequenceTwo = new [] { "alpha", "beta" };

// get common sequence
var commonSequence = sequenceOne.Concat(sequenceTwo).Distinct();

// create two left joins
var merged = 
	from cs in commonSequence
	join s1 in sequenceOne on cs equals s1 into gs1
	from s1 in gs1.DefaultIfEmpty()
	join s2 in sequenceTwo on cs equals s2 into gs2
	from s2 in gs2.DefaultIfEmpty()
	
	select new {
		item = s1 ?? s2
	};
	
merged.Dump();
