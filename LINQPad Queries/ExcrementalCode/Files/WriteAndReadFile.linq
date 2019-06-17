<Query Kind="Statements" />

// Assume each record is unique
var uniqueOriginalRecords = new[]{
	"alpha.record1", "alpha.record4", "alpha.record9",
	"beta.record1", "beta.record2", "beta.record3", "beta.record5" };

var unsortedUniqueOriginalRecords = new[]{
	"beta.record3", "beta.record2", "alpha.record9", "beta.record5",
	"beta.record1", "alpha.record1", "alpha.record4" };

var fileName = @"c:\temp\alpha\records.txt";
var directoryName = Path.GetDirectoryName(fileName);
directoryName.Dump("directoryName");

if (!Directory.Exists(directoryName))
{
    Directory.CreateDirectory(directoryName);
}

if (!File.Exists(fileName))
{
    File.Delete(fileName);
}

// save records to file - one record, one line
File.WriteAllLines(fileName, unsortedUniqueOriginalRecords);

// reload file 
var loadedRecords = File.ReadAllLines(fileName, Encoding.UTF8);

loadedRecords.Dump("Loaded reports");
var records = loadedRecords.ToList();
records.Sort();

// check if record is found
var candidates = (new[]{"BETA.record2", "gamma.record3.14", "ALPHA.record3", "alpha.record4", "DELTA.record13"}).ToList();
candidates.ForEach( ca => records.Contains(ca, StringComparer.OrdinalIgnoreCase).Dump(ca) );
var found = candidates.Where( ca => records.Contains(ca, StringComparer.OrdinalIgnoreCase) );
found.Dump("Found");
var notfound = candidates.Where( ca => !records.Contains(ca, StringComparer.OrdinalIgnoreCase) );
notfound.Dump("Not Found");
var altNotFound = candidates.Except(found);
altNotFound.Dump("Alt Not Found");

// add/remove records and update file
records.Add("gamma.record3.14");
records.Remove("alpha.record4");
File.WriteAllLines(fileName, records);

var additionalRecords = new[]{"delta.record17", "delta.record19", "delta.record13", "gamma.record9"};
File.AppendAllLines(fileName, additionalRecords);

// reload
string[] reloadedRecords = File.ReadAllLines(fileName, Encoding.UTF8);
reloadedRecords.Dump("Reloaded records");
candidates.ForEach( ca => reloadedRecords.Contains(ca, StringComparer.OrdinalIgnoreCase).Dump(ca) );
