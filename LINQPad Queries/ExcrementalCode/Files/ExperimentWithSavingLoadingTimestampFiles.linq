<Query Kind="Program" />

void Main()
{
	var directory = @"c:\temp";
	var baseName = "TestLog";
	var extension = "log";

	// save timestamped files "basename timestamp"
//	var filePath = TimestampFileHelpers.Create(directory, baseName, extension);
//	filePath.Dump();
	
	// load most recent based on filename timestamp
	var mostRecentFile = TimestampFileHelpers.GetMostRecentTimestampedFile(directory, baseName, extension);
	mostRecentFile.Dump();
}

// Define other methods and classes here
public class TimestampFileHelpers {
	public static string GetDateTimeInFilenameFriendlyFormat() => DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss");
	
	public static string GetMostRecentTimestampedFile(string directory, string baseName, string extension = "txt") {
		var filePattern = $"{baseName}*.{extension}";
		var files = Directory.GetFiles(directory, filePattern, SearchOption.TopDirectoryOnly).ToList();
		files.Sort();
		files.Reverse();
		return files.FirstOrDefault();
	}
	
	public static string GetName(string directory, string baseName, string extension = "txt") {
		var timeStamp = GetDateTimeInFilenameFriendlyFormat();
		return Path.Combine(directory, $"{baseName}-{timeStamp}.{extension}");
	}
	
	public static string Create(string directory, string baseName, string extension = "txt") {
		var fileName = GetFileName(directory, baseName, extension);
		File.Create(fileName);
		return fileName;
	}
}
