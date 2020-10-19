<Query Kind="Program">
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\csvhelper\15.0.5\lib\net47\CsvHelper.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\microsoft.bcl.asyncinterfaces\1.1.1\lib\net461\Microsoft.Bcl.AsyncInterfaces.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\system.threading.tasks.extensions\4.5.4\lib\net461\System.Threading.Tasks.Extensions.dll</Reference>
  <Namespace>CsvHelper</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	var s3Only = File.ReadLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\S3Only1.txt").OrderBy(p => p, StringComparer.OrdinalIgnoreCase);
	var dbOnly = File.ReadLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\DbOnly1.txt").OrderBy(p => p, StringComparer.OrdinalIgnoreCase);

	dbOnly.Count().Dump("Db files not found");
	// s3Only.Take(5).Select(s3 => s3.Substring(37)).Dump();
	var s3ByFile = s3Only.Select(s3 => new{ FileName = s3.Substring(37), Path = s3 });
	var dbByFile = dbOnly.Select(db => new{ FileName = db.Substring(37), Path = db });
	
	var dbToMoveOrUpload = 
		from db in dbByFile
        join s3 in s3ByFile on db.FileName equals s3.FileName into s3s
        from s3 in s3s.DefaultIfEmpty()

		let s3Found = s3 != null
		select new {
			ExpectedPath = db.Path,
			Filename = db.FileName,
			ShouldMove = s3Found,
			MoveFrom = s3Found ? s3.Path : ""
		};

	// if dbonly exists in s3Only, then db is misplaced and needs to be moved
	// else db needs to be uploaded - this means there is a problem with the uploader
	// Any files still left in s3Only should be deleted
	
	dbToMoveOrUpload.Where(db => db.ShouldMove).Count().Dump("S3 to move to db paths");
	dbToMoveOrUpload.Take(5).Dump();
    using (var writer = new StreamWriter(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\MoveOrDelete.csv"))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(dbToMoveOrUpload);
    }	
	var s3Categorized = dbToMoveOrUpload.Where(db => db.ShouldMove).Select(db => db.MoveFrom);
	var s3Unaccounted = s3Only.Except(s3Categorized);
	s3Unaccounted.Count().Dump("S3 unaccounted");
	s3Unaccounted.Take(5).Dump();

	var dbS3Paths = File.ReadLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\ExpectedS3Paths.txt").OrderBy(p => p, StringComparer.OrdinalIgnoreCase);
	var dbS3ByFile = dbS3Paths.Select(db => new{ FileName = db.Substring(37), Path = db });
	var s3UnaccountedByFile = s3Unaccounted.Select(s3 => new{ FileName = s3.Substring(37), Path = s3 });
	
	var s3UploadedByUnknown = 
		from s3 in s3UnaccountedByFile
        join db in dbS3ByFile on s3.FileName equals db.FileName into dbs
        from db in dbs.DefaultIfEmpty()
		where db == null
		select s3;
		
	s3UploadedByUnknown.Count().Dump("S3 Uploaded but not in db at all");
	var s3ToInvestigate = s3UploadedByUnknown.Select(s3 => s3.Path);
	File.WriteAllLines(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database\s3ToInvestigate.txt", s3ToInvestigate);
		
}