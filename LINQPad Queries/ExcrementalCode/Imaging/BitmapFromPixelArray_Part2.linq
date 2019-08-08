<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
</Query>

var bitmap = new Bitmap(1701, 1701);

System.Drawing.Imaging.BitmapData bmpData =
    bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);

// Get the address of the first line.
IntPtr ptr = bmpData.Scan0;

// Declare an array to hold the bytes of the bitmap.
int bytes  = Math.Abs(bmpData.Stride) * bitmap.Height;
byte[] rgbValues = Enumerable.Repeat((byte)0, bytes).ToArray();

// Copy the RGB values into the array.
System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

// Set every second value to 255. A 24bpp bitmap will look red.  
for (int counter = 2; counter < rgbValues.Length; counter += 3)
    rgbValues[counter] = 255;

// Copy the RGB values back to the bitmap
System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

bitmap.Save(@"c:\temp\FromPixelArrayPart2.bmp", ImageFormat.Bmp);
