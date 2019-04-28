<Query Kind="Program" />

void Main()
{
	var fileNames = new List<string>(new[]{
		@"C:\Users\ernest.tidalgo\Downloads\TortoiseGit-2.8.0.0-64bit.msi",
		@"C:\Users\ernest.tidalgo\Downloads\TortoiseGit-2.8.0.0-64bit.msi.rsa.asc",
		@"C:\Users\ernest.tidalgo\Downloads\Towards a Principle-based.pdf",
		@"C:\Users\ernest.tidalgo\Downloads\Untitled.png",
		@"C:\Users\ernest.tidalgo\Downloads\upbt-20080212-1330-Hans_Theessink-048.mp3",
		@"C:\Users\ernest.tidalgo\Downloads\VisualThinkingWP.pdf",
		@"C:\Users\ernest.tidalgo\Downloads\vs_professional__205811875.1545169406.exe",
		@"C:\Users\ernest.tidalgo\Downloads\Working at home, degradation of social skills.png",
		@"C:\Users\ernest.tidalgo\Downloads\xkcd-earth_temperature_timeline.png"
	});

	fileNames.ForEach(fn => Console.WriteLine($"{fn} {IsImage(fn)}"));
}

// Define other methods and classes here
bool IsImage(string fileName) {
	var extension = Path.GetExtension(fileName);
	var imageExtensions = new List<string>(new[]{".JPG", ".JPEG", ".GIF", ".PNG", ".TIFF"});
	return imageExtensions.Contains(extension.ToUpper());
}

