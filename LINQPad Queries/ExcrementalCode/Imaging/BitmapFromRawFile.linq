<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
</Query>

void Main()
{
	var files = new[]{
		@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-383 DI Tool to convert images from Mediasuite (D4W) to ExaminePro\RF_00000282.cmi",
		@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-383 DI Tool to convert images from Mediasuite (D4W) to ExaminePro\RF_00014008.cmi",
		@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-383 DI Tool to convert images from Mediasuite (D4W) to ExaminePro\RF_00014013.cmi",
		@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-383 DI Tool to convert images from Mediasuite (D4W) to ExaminePro\RF_00050316.cmi"};
	
	files.ToList().ForEach(ConvertToBitmap);
}

// Define other methods and classes here
void ConvertToBitmap(string inputFilename){
	// load raw data from file
	byte[] fileBytes = File.ReadAllBytes(inputFilename);
	var byteLength = fileBytes.Length; 
	byteLength.Dump("Length");
	byteLength = byteLength/3 ;
	byteLength.Dump("Length");
	
	// determine initial dimensions, use square root rounded down, if standard dimensions are known use these
	// render as different pixel depths, adjust dimensions accordingly
	var roughDimension = Math.Floor(Math.Sqrt(byteLength));
	var dimension = roughDimension - (roughDimension % 100);
	dimension.Dump("Dimension");
	
	// start with ... some pixel depth
	var bitmap = new Bitmap(Convert.ToInt32(dimension), Convert.ToInt32(dimension), PixelFormat.Format24bppRgb);
	
	System.Drawing.Imaging.BitmapData bmpData =
	    bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
	
	bitmap.Width.Dump("bitmap.Width");
	bitmap.Height.Dump("bitmap.Height");
	// Get the address of the first line.
	IntPtr ptr = bmpData.Scan0;
	bmpData.Stride.Dump("bmpData.Stride");
	int numberOfBytes = Math.Abs(bmpData.Stride) * bitmap.Height;
	numberOfBytes.Dump("numberOfBytes");
	
	// Copy the RGB values back to the bitmap
	System.Runtime.InteropServices.Marshal.Copy(fileBytes, 0, ptr, numberOfBytes);

	var fileName = Path.GetFileName(inputFilename);
	var targetFile = Path.Combine(@"c:\temp", fileName + ".bmp");
	bitmap.Save(targetFile, ImageFormat.Bmp);
	targetFile.Dump("targetFile");
}