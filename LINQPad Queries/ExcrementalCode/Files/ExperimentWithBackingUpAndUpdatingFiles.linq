<Query Kind="Statements" />

var logFileDirectory = @"c:\temp";
var recordsFilename = "recordsSource.txt";
var recordsToFindFilename = "recordsToFind.txt";

var recordsOriginal = "recordsOriginal.txt";
var recordsOriginalFile = Path.Combine(logFileDirectory, recordsOriginal);
var recordsFile = Path.Combine(logFileDirectory, recordsFilename);
var recordsToFindFile = Path.Combine(logFileDirectory, recordsToFindFilename);

// restore records to original state
File.Copy(recordsOriginalFile, recordsFile, overwrite: true);

// Create snapshot directory and backup files
var dateTime = DateTime.Now;
var snapshotDirectory = Path.Combine(logFileDirectory, dateTime.ToString("yyyy.MM.dd HH.mm.ss"));
if (!Directory.Exists(snapshotDirectory))
{
    Directory.CreateDirectory(snapshotDirectory);
}

File.Copy(recordsFile, Path.Combine(snapshotDirectory, recordsFilename));
File.Copy(recordsToFindFile, Path.Combine(snapshotDirectory, recordsToFindFilename));

// process records and update resources source file
var loadedRecords = File.ReadAllLines(recordsFile, Encoding.UTF8);
loadedRecords.Count().Dump("Number of loaded records");
var recordsToFind = File.ReadAllLines(recordsToFindFile, Encoding.UTF8);
recordsToFind.Count().Dump("Number of records to find");

var exceptedRecords = loadedRecords.Except(recordsToFind);

File.WriteAllLines(recordsFile, exceptedRecords);
"Done".Dump();
