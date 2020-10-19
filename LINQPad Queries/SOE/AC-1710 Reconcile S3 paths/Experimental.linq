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
	System.IO.Path.Combine("alpha", "Beta").Dump();
	
	var baseDirectory = @"C:\Users\ernest.tidalgo\SOE\Tasks\AC-1710 Verify S3 documents against database";
	var s3Listing = File.ReadLines(Path.Combine(baseDirectory, "All Au Prod documents-20200916.txt"));
	
	var actualS3Paths = s3Listing.Select(s3 => s3.Substring(31));
	s3Listing.Take(5).Dump();
	actualS3Paths.Take(5).Dump();

    using (var reader = new StreamReader(Path.Combine(baseDirectory, "S3 Paths for Documents 20200916.csv")))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        var anonymousTypeDefinition = new
        {
			OrganizationId = string.Empty,
			OrganizationGUID = string.Empty,
			S3ID = string.Empty,
			IsThumbnail = string.Empty,
			Path = string.Empty,
			CreatedBy = string.Empty
        };
		var records = csv.GetRecords(anonymousTypeDefinition);
		records.Take(5).Dump();
	}		

	IEnumerable<SimpleS3Document> s3Documents;
    using (var reader = new StreamReader(Path.Combine(baseDirectory, "S3 Paths for Documents 20200916.csv")))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
		s3Documents = csv.GetRecords<SimpleS3Document>();// .ToList();
		s3Documents.Take(5).Dump();
	}		
	s3Documents.Take(5).Dump();
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
