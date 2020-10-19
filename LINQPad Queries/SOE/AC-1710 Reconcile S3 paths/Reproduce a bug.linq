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
	const int labelWidth = -31;
	var baseDirectory = @"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database";

	var s3Listing = File.ReadLines(Path.Combine(baseDirectory, "All Au Prod documents-20200917.txt"));
	var actualS3Paths = s3Listing.Select(s3 => s3.Substring(31));

	var s3DocumentCount = actualS3Paths.Count();
	Console.WriteLine($"{"Total S3 Documents", labelWidth}: {s3DocumentCount}");

	IEnumerable<DocumentRecord> documentPaths;
	using (var reader = new StreamReader(Path.Combine(baseDirectory, "S3 Paths for Documents 20200917.csv")))
	using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
	{
		csv.Configuration.HeaderValidated = null;
		csv.Configuration.MissingFieldFound = null;
		documentPaths = csv.GetRecords<DocumentRecord>().ToList();
	}

	var documentPathCount = documentPaths.Count();
	Console.WriteLine($"{"Total Db Paths", labelWidth}: {documentPathCount}");

	var matchingS3AndDb =
		from dbS3 in documentPaths
		join s3 in actualS3Paths on dbS3.Path equals s3 into s3s
		from s3 in s3s.DefaultIfEmpty()

		let foundInS3 = s3 != null
		select new DocumentRecord
		{
			Path = dbS3.Path,
			FoundInS3 = foundInS3,
			DocumentId = dbS3.DocumentId,
			OrganizationId = dbS3.OrganizationId,
			OrganizationGUID = dbS3.OrganizationGUID,
			FileNameUUID = dbS3.FileNameUUID,
			DocumentOwnerId = dbS3.DocumentOwnerId,
			IsThumbnail = dbS3.IsThumbnail,
			CreatedBy = dbS3.CreatedBy
		};

	var qs3PathCategorized =
		from s3p in actualS3Paths
		join dbS3p in documentPaths on s3p equals dbS3p.Path into dbS3ps
		from dbS3p in dbS3ps.DefaultIfEmpty()
		let foundInS3 = dbS3p != null

		select new
		{
			FoundInS3 = foundInS3,
			S3Path = s3p
		};

	var s3PathCategorized = qs3PathCategorized.ToList();

	Console.WriteLine($"{"S3 PathCategorized",labelWidth}: {s3PathCategorized.Count()}");
	Console.WriteLine($"{"S3 matching, same as Db matching",labelWidth}: {s3PathCategorized.Where(s3 => s3.FoundInS3).Count()}");
	Console.WriteLine($"{"S3 to categorize",labelWidth}: {s3PathCategorized.Where(s3 => !s3.FoundInS3).Count()}");
	Console.WriteLine($"{"S3 to categorize - Distinct",labelWidth}: {s3PathCategorized.Where(sa => !sa.FoundInS3).Select(s3 => s3.S3Path).Distinct().Count()}");
}

// Define other methods and classes here
	public class DocumentRecord
    {
		public string DocumentId { get; set; }
		public string OrganizationId { get; set; }
		public string OrganizationGUID { get; set; }
		public string DocumentOwnerId { get; set; }
		public string FileNameUUID { get; set; } // S3ID
		public bool IsThumbnail { get; set; }
		public string Path { get; set; }
		public string CreatedBy { get; set; }
		public bool FoundInS3 { get; set; }
		public string Action { get; set; }
		public string MoveFrom { get; set; }
	}
