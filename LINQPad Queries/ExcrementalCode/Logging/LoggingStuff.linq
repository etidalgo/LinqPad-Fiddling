<Query Kind="Program" />

void Main()
{
	var timeStamp = DateTime.Now.ToString("MMdd_hhmm");
	var fileName = @$"c:\temp\records_{timeStamp}.txt";
	var root = Path.GetDirectoryName(fileName);
	if (!Directory.Exists(root))
	{
	    Directory.CreateDirectory(root);
	}
	 
	if (!File.Exists(fileName))
	{
	    File.Delete(fileName);
	}

}

// You can define other methods, fields, classes and namespaces here
