<Query Kind="Expression" />

//	var uploadTrackingService = new UploadTrackingService
//	{
//	    TrackingDirectory = Path.GetDirectoryName(Path.GetFullPath(configFileName))
//	};

namespace Soe.Ascend.Uploader.Services
{
    public class UploadTrackingService : IUploadTrackingService
    {
        public string TrackingDirectory { get; set; }
        private const string Extension = "log";

        private string GetFilePath(string recordType, string status, string optionalDescription = "")
        {
            var statusAndDescription = string.IsNullOrEmpty(optionalDescription) ? status : $"{status}-{optionalDescription}";
            return Path.Combine(this.TrackingDirectory, $"{recordType}-{statusAndDescription}.log");
        }

        public IEnumerable<string> GetPreviouslySuccessful(string recordType)
        {
            var filePath = GetFilePath(recordType, "Successful");
            if (File.Exists(filePath))
            {
                 return File.ReadAllLines(filePath).ToList().Where(li => !li.EndsWith("--------------------------")); // without markers
            }

            return new List<string>();
        }

        public void AddSuccessful(string recordType, IEnumerable<string> successfulRecords)
        {
            if (!successfulRecords.Any())
                return;

            var filePath = GetFilePath(recordType, "Successful");
            File.AppendAllLines(filePath, new []{$"Added {DateTime.Now.ToString("s")} --------------------------"});
            File.AppendAllLines(filePath, successfulRecords);
        }

        public void AddError(string recordType, string errorDescription, IEnumerable<string> errorRecords)
        {
            if (!errorRecords.Any())
                return;

            var filePath = GetFilePath(recordType, "Error", errorDescription);
            File.AppendAllLines(filePath, new[] { $"Added {DateTime.Now.ToString("s")} --------------------------" });
            File.AppendAllLines(filePath, errorRecords);
        }

        public void ResetError(string recordType, string errorDescription)
        {
            var filePath = GetFilePath(recordType, "Error", errorDescription);
            File.Delete(filePath);
        }
    }
}
