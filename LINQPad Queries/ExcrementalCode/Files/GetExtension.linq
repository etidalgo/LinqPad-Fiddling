<Query Kind="Statements" />


var fileNames = new[] { "", "normal.txt", "normal.jpg", "acceptable.jpg.txt", "bogus", ".git" };
foreach( var fileName in fileNames){
	var extension = Path.GetExtension(fileName);
	if(!string.IsNullOrEmpty(extension)){
		extension.Substring(1).Dump(fileName);
	} else {
		$"Empty extension [{fileName}]".Dump();
	}
}

Console.WriteLine(Path.GetExtension(""));
