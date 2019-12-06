<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.InteropServices.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

throw new Exception("Use ConvertCmiToBmp project"); 
 
var rawContent = File.ReadAllBytes(@"C:\Users\ernest.tidalgo\SOE\Tasks\AC-383 DI Tool to convert images from Mediasuite (D4W) to ExaminePro\RF_00050316.cmi");

rawContent.Length.Dump();

// 

Bitmap bitmap = new Bitmap(1290, 1790);
// myPrewrittenBuff is allocated just like myReadingBuffer below (skipped for space sake)
// Now lets read back the bitmap into another format...
BitmapData myPrewrittenBuff = new BitmapData();
ushort[] buff = new ushort[(3 * bitmap.Width) * bitmap.Height]; // ;Marshal.AllocHGlobal() if you want
GCHandle handle= GCHandle.Alloc(buff, GCHandleType.Pinned);
myPrewrittenBuff.Scan0 = Marshal.UnsafeAddrOfPinnedArrayElement(buff, 0);
myPrewrittenBuff.Height = bitmap.Height;
myPrewrittenBuff.Width = bitmap.Width;
myPrewrittenBuff.PixelFormat = PixelFormat.Format24bppRgb;
myPrewrittenBuff.Stride = 6 * bitmap.Width;

// But with two differences: the buff would be byte [] (not ushort[]) and the Stride == 3 * size.Width (not 6 * ...) because we build a 24bpp not 48bpp
BitmapData writerBuff= bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.UserInputBuffer | ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb, myPrewrittenBuff);
// note here writerBuff and myPrewrittenBuff are the same reference
if (object.ReferenceEquals(writerBuff, myPrewrittenBuff)) {
    // Note: we pass here
    // and buff is filled
    // Get the address of the first line.
    IntPtr ptr = myPrewrittenBuff.Scan0;

    // Declare an array to hold the bytes of the bitmap.
    int bytes  = Math.Abs(myPrewrittenBuff.Stride) * bitmap.Height;
    byte[] rgbValues = new byte[bytes];

	// fill in rgb values
	var currentPixel = 0;
	var startingOffset = 119 + 1; // offset 119, 2nd pixel after
	var lastCmiPixelIndex = startingOffset + (1290 * 1790 * 2);
    for (int counter = startingOffset; counter < lastCmiPixelIndex; counter += 2){
    	rgbValues[currentPixel++] = rawContent[counter];
    	rgbValues[currentPixel++] = rawContent[counter];
    	rgbValues[currentPixel++] = rawContent[counter];
	}

    // Copy the RGB values back to the bitmap
    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
}

bitmap.UnlockBits(writerBuff);
// done. bitmap updated , no marshal needed to copy myPrewrittenBuff 

handle.Free();
// use buff at will...

bitmap.Save(@"c:\temp\CmiConverted.bmp", ImageFormat.Bmp);