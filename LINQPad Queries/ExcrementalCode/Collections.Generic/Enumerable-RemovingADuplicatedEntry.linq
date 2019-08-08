<Query Kind="Statements" />

var records = new List<string>{
	"beta.record3", "beta.record3", "beta.record2", "alpha.record9", "beta.record5", "beta.record2", 
	"alpha.record1", "beta.record1", "alpha.record1", "alpha.record4" };

records.Dump();
records.Sort();
records.Dump();

records.Remove("beta.record2");
records.Dump();

// Try using custom object
records = new List<string>{
	"beta.record3", "beta.record3", "beta.record2", "alpha.record9", "beta.record5", "beta.record2", 
	"alpha.record1", "beta.record1", "alpha.record1", "alpha.record4" };
var candidates = new List<string>{
	"gamma.record1", "beta.record16", 
	"beta.record3", "beta.record3", // two candidates to match the two in records
	"alpha.record1", // one candidate vs two in records, one remains in records
	"beta.record1", "beta.record1" // two candidates to match the one in records, one candidate will pass through
	};

records.Sort();
var recordsWithState = records.Select(rec => new { Entry = rec, Used = false } );
recordsWithState.Dump();
candidates.Dump();

// Using a foreach because I am unsure how to manipulate two lists at the same time with Linq
var passThroughCandidates = new List<string>();
foreach(var candidate in candidates){
	if(records.Any(rec => rec == candidate)) {
		records.Remove(candidate);
	}
	else {
		passThroughCandidates.Add(candidate);
	}
}

records.Dump("remainingRecords");
passThroughCandidates.Dump("passThroughCandidates");