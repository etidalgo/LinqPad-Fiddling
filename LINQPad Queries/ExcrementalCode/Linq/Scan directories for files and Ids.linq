<Query Kind="Program" />

void Main()
{
	var testCases = new[]{ 
		@"D:\Conversions\R4\R4_Patient_Documents\GRAHA045822_files\PatLetters\Received\01000081",
		@"D:\Conversions\R4\R4_Patient_Documents\GRAHA045822_files\PatLetters\Received\01000081\blahblah",
		@"D:\Conversions\R4\R4_Patient_Documents\GRAHA045822_files\PatLetters\Received" };
	testCases.ToList().ForEach(tc => GetIdFromDocumentPath(tc).Dump("Id"));
	var documentsFolder = @"D:\Conversions\R4\R4_Patient_Documents\GRAHA045822_files\PatLetters";
    DirectoryInfo diDocs = new DirectoryInfo(documentsFolder);
	var files = diDocs.GetFiles("*.*", SearchOption.AllDirectories);
	// files
	files.Take(100)
		.ToList().ForEach(fi => {
		var patientId = GetPatidFromFolder(fi.DirectoryName);
		var altPatientId = GetIdFromDocumentPath(fi.DirectoryName);
		Console.WriteLine($"PatientId: {patientId}\nAlternate PatientId: {altPatientId}\nDirectory: {fi.DirectoryName}\n");
		if(!patientId.Equals(altPatientId)){
			Console.WriteLine("Mismatch"); // because the path PatientId is preceded by 0
		}
		fi.FullName.GetTypeFromFileName().Dump();
	});
//    foreach (var fi in diDocs.GetFiles("*.*", SearchOption.AllDirectories))
//    {
//		var patientId = GetPatidFromFolder(fi.DirectoryName);
//		Console.WriteLine($"PatientId: {patientId}\nDirectory: {fi.DirectoryName}\n");
//	}
}

// Define other methods and classes here
// Get the deepest folder name that looks like a patient ID, Split.Reverse.Where( int.TryParse(dirName) ).First
string GetPatidFromFolder(string docfolder)
{
    int iTmp = 0;
    string[] saWorker = docfolder.Split('\\');
    for (int i = saWorker.Length - 1; i > 0; i--)
    {
        if (int.TryParse(saWorker[i], out iTmp))
        {
            return iTmp.ToString();
        }
    }
    return "";
}

string GetIdFromDocumentPath(string documentPath)
{
    var pathElements = documentPath.Split('\\').ToList();
	pathElements.Reverse();
	return pathElements.Where(pe => int.TryParse(pe, out _)).Select(pe => int.Parse(pe).ToString()).FirstOrDefault() ?? "";
}

public static class Extensions {
	public static string GetTypeFromFileName(this string fileName){
		var filetype = Path.GetExtension(fileName);
		return !string.IsNullOrEmpty(filetype) ? filetype.Substring(1): filetype;
	}
}