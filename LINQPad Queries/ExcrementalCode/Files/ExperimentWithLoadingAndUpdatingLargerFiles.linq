<Query Kind="Statements" />

var logFileDirectory = @"c:\temp";
var recordsFilename = "records1.txt";
var recordsToFindFilename = "recordsToFind.txt";

var knownFileWithRecords = @"c:\temp\records1.txt";
var knownFileWithRecordsToFind = @"c:\temp\recordsToFind.txt";

var loadedRecords = File.ReadAllLines(knownFileWithRecords, Encoding.UTF8);
loadedRecords.Count().Dump("Number of loaded records");
var recordsToFind = File.ReadAllLines(knownFileWithRecordsToFind, Encoding.UTF8);
recordsToFind.Count().Dump("Number of records to find");

var exceptedRecords = loadedRecords.Except(recordsToFind);
var fileWithExceptedRecords = @"c:\temp\exceptedRecords.txt";
if (!File.Exists(fileWithExceptedRecords))
{
    File.Delete(fileWithExceptedRecords);
}
File.WriteAllLines(fileWithExceptedRecords, exceptedRecords);
"Done".Dump();
