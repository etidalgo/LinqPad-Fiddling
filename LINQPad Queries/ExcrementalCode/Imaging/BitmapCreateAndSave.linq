<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
</Query>

// [c# - Create Bitmap from a byte array of pixel data - Stack Overflow](https://stackoverflow.com/questions/6782489/create-bitmap-from-a-byte-array-of-pixel-data)
    Bitmap flag = new Bitmap(200, 100);
    Graphics flagGraphics = Graphics.FromImage(flag);
    int red = 0;
    int white = 11;
    while (white <= 100) {
        flagGraphics.FillRectangle(Brushes.Red, 0, red, 200,10);
        flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
        red += 20;
        white += 20;
    }
	flag.Save(@"c:\temp\test.bmp", ImageFormat.Bmp);
