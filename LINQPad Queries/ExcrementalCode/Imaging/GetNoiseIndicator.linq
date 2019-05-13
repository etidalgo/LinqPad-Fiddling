<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Namespace>System.Windows.Media.Imaging</Namespace>
</Query>

void Main()
{
	BitmapSource bitmapSource = LoadPng("");
	// Get average absolute difference in brightness/grayscale between adjacent row pixels (can do columns another day)	
	
}

// Define other methods and classes here
BitmapSource LoadPng(string pngFilename) {
	// Open a Stream and decode a PNG image
	Stream imageStreamSource = new FileStream("smiley.png", FileMode.Open, FileAccess.Read, FileShare.Read);
	PngBitmapDecoder decoder = new PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
	BitmapSource bitmapSource = decoder.Frames[0];
	return bitmapSource;
}
