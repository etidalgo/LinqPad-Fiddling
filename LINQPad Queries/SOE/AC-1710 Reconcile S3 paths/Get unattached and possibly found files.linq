<Query Kind="Program" />

void Main()
{
	// this has out-of-memory exceptions with Linqpad5 x86
	// There should be 1:1 relationship between s3 and db
	var actualS3Paths = File.ReadLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\ExistingS3Paths.txt").OrderBy(p => p, StringComparer.OrdinalIgnoreCase);
	var dbS3Paths = File.ReadLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\ExpectedS3Paths.txt").OrderBy(p => p, StringComparer.OrdinalIgnoreCase);
	
	var s3Only = actualS3Paths.Except(dbS3Paths);
	var dbOnly = dbS3Paths.Except(actualS3Paths);
	
	File.WriteAllLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\S3Only1.txt", s3Only);
	File.WriteAllLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\DbOnly1.txt", dbOnly);
	
	Console.WriteLine($"S3 Only Count {s3Only.Count()}");
	Console.WriteLine($"Db Only Count {dbOnly.Count()}");
}