<Query Kind="Program">
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\csvhelper\15.0.5\lib\net47\CsvHelper.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\microsoft.bcl.asyncinterfaces\1.1.1\lib\net461\Microsoft.Bcl.AsyncInterfaces.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\system.threading.tasks.extensions\4.5.4\lib\net461\System.Threading.Tasks.Extensions.dll</Reference>
  <Namespace>CsvHelper</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

// 
void Main()
{
	var baseDirectory = @"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database";
	
	var s3Listing = File.ReadLines(Path.Combine(baseDirectory, "All Au Prod documents-20200916.txt"));
	var actualS3Paths = s3Listing.Select(s3 => s3.Substring(31));
	
	IEnumerable<SimpleS3Document> s3Documents;
    using (var reader = new StreamReader(Path.Combine(baseDirectory, "S3 Paths for Documents 20200916.csv")))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
		s3Documents = csv.GetRecords<SimpleS3Document>().ToList();
	}		

	// var dbS3Paths = File.ReadLines(Path.Combine(baseDirectory, "ExpectedS3Paths.txt"));

	// Identify S3/DbS3 files that match
	var matchingS3AndDb = 
		from dbS3 in s3Documents
		join s3 in actualS3Paths on dbS3.Path equals s3 into s3s
	    from s3 in s3s.DefaultIfEmpty()

		let foundInS3 = s3 != null
		select new {
			ExpectedPath = dbS3.Path,
			FoundInS3 = foundInS3
		};
	
    using (var writer = new StreamWriter(Path.Combine(baseDirectory, "Final-MatchingDbS3Files.csv")))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(matchingS3AndDb);
    }
	
	// Identify S3 files to move
	// Identify DbS3 files to upload
	var dbOnly = matchingS3AndDb.Where(db => !db.FoundInS3).Select(db => db.ExpectedPath);
	var s3Only = 
		from s3 in actualS3Paths 
		join dbS3 in s3Documents on s3 equals dbS3.Path into dbS3s
		from dbS3 in dbS3s.DefaultIfEmpty()
		where dbS3 == null
		
		select s3;
	
	var s3ByFile = s3Only.Select(s3 => new{ FileName = s3.Substring(37), Path = s3 });
	var dbByFile = dbOnly.Select(db => new{ FileName = db.Substring(37), Path = db });
	
	var dbToMoveOrUpload = 
		from db in dbByFile
        join s3 in s3ByFile on db.FileName equals s3.FileName into s3s
        from s3 in s3s.DefaultIfEmpty()

		let s3Found = s3 != null
		
		orderby db.FileName
		select new {
			ExpectedPath = db.Path,
			Filename = db.FileName,
			Action = s3Found ? "Move": "Upload",
			MoveFrom = s3Found ? s3.Path : ""
		};

    using (var writer = new StreamWriter(Path.Combine(baseDirectory, "Final-MoveOrUpload.csv")))
    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csv.WriteRecords(dbToMoveOrUpload);
    }
	// all db s3 paths are identified as matching, move from another s3 path or upload
	
	// Identify remaining S3 paths that do not have a matching db path or filename
	var s3LikelyOrphans = 
		from s3 in s3Only 
		join dbS3 in dbToMoveOrUpload.Where(db =>db.MoveFrom != "") on s3 equals dbS3.MoveFrom
		select s3;
	
	File.WriteAllLines(Path.Combine(baseDirectory, "Final-S3LikelyOrphans.txt"), s3LikelyOrphans);
}

// Define other methods and classes here
public class SimpleS3Document {
	public string OrganizationId { get; set; }
	public string OrganizationGUID { get; set; }
	public string S3ID { get; set; }
	public bool IsThumbnail { get; set; }
	public string Path { get; set; }
	public string CreatedBy { get; set; }
}
