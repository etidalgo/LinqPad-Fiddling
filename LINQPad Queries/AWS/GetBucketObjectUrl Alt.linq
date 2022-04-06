<Query Kind="Program">
  <Reference>&lt;NuGet&gt;\awssdk.core\3.7.2.6\lib\netcoreapp3.1\AWSSDK.Core.dll</Reference>
  <Reference>&lt;NuGet&gt;\awssdk.s3\3.7.0.26\lib\netcoreapp3.1\AWSSDK.S3.dll</Reference>
  <Reference>&lt;NuGet&gt;\awssdk.securitytoken\3.7.1.44\lib\netcoreapp3.1\AWSSDK.SecurityToken.dll</Reference>
  <Reference>&lt;NuGet&gt;\microsoft.netcore.app.ref\3.0.0\ref\netcoreapp3.0\System.ComponentModel.dll</Reference>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.Runtime</Namespace>
  <Namespace>Amazon.S3</Namespace>
  <Namespace>Amazon.S3.Model</Namespace>
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
    var configurationRegion = "ap-southeast-2"; // I am not sure this makes a difference, even 'bogus' returns an objectUrl
    var region = RegionEndpoint.GetBySystemName(configurationRegion);
    // RegionEndpoint region = null;

    var amazonS3Config = new AmazonS3Config();
    if (region != null)
        amazonS3Config.RegionEndpoint = region;

    var credentials = FallbackCredentialsFactory.GetCredentials();
	credentials.Dump();
	// Dump object with code
	foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(credentials))
	{
	    string name = descriptor.Name;
	    object value = descriptor.GetValue(credentials);
	    Console.WriteLine("{0}={1}", name, value);
	}

	var s3Client = new AmazonS3Client(credentials, amazonS3Config);
	var guid = Guid.NewGuid();	
	var objectUrl = GetObjectUrl(s3Client, "documents", guid.ToString());
	objectUrl.Dump();
}

// You can define other methods, fields, classes and namespaces here
public string GetObjectUrl(AmazonS3Client s3Client, string bucketName, string objectKey)
{
    var request = new GetPreSignedUrlRequest
    {
        BucketName = bucketName,
        Key = objectKey,
        Verb = HttpVerb.PUT,
        Expires = DateTime.Now.AddHours(1)
    };

    var url = s3Client.GetPreSignedURL(request);
    return url;
}
