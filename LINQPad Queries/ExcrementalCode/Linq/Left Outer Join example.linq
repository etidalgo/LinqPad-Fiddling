<Query Kind="Statements" />

// left join, not a full outer join

var sequenceOne = new [] { "alpha", "gamma" };
var sequenceTwo = new [] { "alpha", "beta" };

var merged = 
	from s1 in sequenceOne 
	join s2 in sequenceTwo on s1 equals s2 into gs1
	from s2 in gs1.DefaultIfEmpty()
	
	select new {
		item = s2
	};
	
merged.Dump();
