<Query Kind="Statements" />

var records = new List<string>{
	"beta.record3", "beta.record3", "beta.record2", "alpha.record9", "beta.record5", "beta.record2", 
	"alpha.record1", "beta.record1", "alpha.record1", "alpha.record4" };

records.Dump();
records.Sort();
records.Dump();

records.Remove("beta.record2");
records.Dump();
