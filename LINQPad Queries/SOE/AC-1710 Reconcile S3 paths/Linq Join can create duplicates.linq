<Query Kind="Program" />

void Main()
{
	var alpha = new[] { "bogus" };
	var beta = new[] { "bogus", "bogus" };

	var gamma = 
		from a in alpha 
		join b in beta on a equals b into bs 
		from b in bs.DefaultIfEmpty()
		
		select new {
			IsSilly = b != null,
			Item = a
		};
	
	gamma.Dump(); // # alpha * # beta
}

// Define other methods and classes here
