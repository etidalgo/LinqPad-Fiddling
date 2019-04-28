<Query Kind="Program">
  <Reference Relative="..\..\..\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\Autofac.dll">D:\Dev\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\Autofac.dll</Reference>
  <Reference Relative="..\..\..\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\Dicom.Core.dll">D:\Dev\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\Dicom.Core.dll</Reference>
  <Reference Relative="..\..\..\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\HSOAscendClientUploader.exe">D:\Dev\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\HSOAscendClientUploader.exe</Reference>
  <Reference Relative="..\..\..\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\log4net.dll">D:\Dev\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\log4net.dll</Reference>
  <Reference Relative="..\..\..\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\Newtonsoft.Json.dll">D:\Dev\ascend-s3uploader\HSOAscendClientUploader\bin\Debug\Newtonsoft.Json.dll</Reference>
  <Namespace>Dicom</Namespace>
  <Namespace>Dicom.Imaging</Namespace>
  <Namespace>Dicom.Imaging.Algorithms</Namespace>
  <Namespace>Dicom.Imaging.Codec</Namespace>
  <Namespace>Dicom.Imaging.Codec.Jpeg</Namespace>
  <Namespace>Dicom.Imaging.LUT</Namespace>
  <Namespace>Dicom.Imaging.Mathematics</Namespace>
  <Namespace>Dicom.Imaging.Render</Namespace>
  <Namespace>Dicom.IO</Namespace>
  <Namespace>Dicom.IO.Buffer</Namespace>
  <Namespace>Dicom.IO.Reader</Namespace>
  <Namespace>Dicom.IO.Writer</Namespace>
  <Namespace>Dicom.Log</Namespace>
  <Namespace>Dicom.Media</Namespace>
  <Namespace>Dicom.Network</Namespace>
  <Namespace>Dicom.Printing</Namespace>
  <Namespace>Dicom.Serialization</Namespace>
  <Namespace>Dicom.StructuredReport</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Text</Namespace>
</Query>

void Main()
{


var fileName = @"C:\ExPro\Patients\1011\4075957713040759576680maurice ralph-readable.raw.dic";
var uniqueImagePath = @"C:\ExPro\Patients\1011\4075957713040759576680maurice ralph-readable.raw1.png";

var (ImgSuccess, ImgWidth, ImgHeight, ImgHash) = Dicom.ConvertDICOMImageToPNG(fileName, uniqueImagePath);
	
}

// Define other methods and classes here

    public class Dicom
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(typeof(Dicom));

        public static (bool ImgSuccess, int ImgWidth, int ImgHeight, string ImgHash) ConvertDICOMImageToPNG(string inputFileName, string outputFileName)
        {
            if (string.IsNullOrWhiteSpace(inputFileName) || string.IsNullOrWhiteSpace(outputFileName))
            {
                Debug.Assert(false, "Wrong IO specified");
                log.Error("Wrong IO specified");
                return (false, 0, 0, string.Empty);
            }

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(outputFileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFileName));
                }
                var img = new DicomImage(inputFileName);
                using (var renderedImage = img.RenderImage())
                using (var bitmap = new Bitmap((Image)renderedImage.AsClonedBitmap()))
                {
                    bitmap.Save(outputFileName, System.Drawing.Imaging.ImageFormat.Png);
                    var hashString = string.Empty;
                    using (MD5 hasher = MD5.Create())
                    {
                        var hash = hasher.ComputeHash(File.OpenRead(outputFileName));
                        hashString = Convert.ToBase64String(hash);
                    }
                    return (true, bitmap.Width, bitmap.Height, hashString);
                }
            }
            catch (DicomImagingException diEx)
            {
                Debug.Assert(false, "Failed to convert the DICOM image", diEx.Message);
                log.Error("Failed to convert the DICOM image", diEx);
				Console.WriteLine("Failed to convert the DICOM image", diEx);
                return (false, 0, 0, string.Empty);
            }
            catch (Exception ex)
            {
                //Debug.Assert(false, "Failed to convert the DICOM image, general Exception", ex.Message);
                log.Error("Failed to convert the DICOM image, general Exception", ex);
				Console.WriteLine("Failed to convert the DICOM image, general Exception {0}", ex);
                return (false, 0, 0, string.Empty);
            }
        }

        public static (bool Tmbsuccess, int TmbWidth, int TmbHeight) GenerateImageThumbnail(string uniqueImagePath, string uniqueThumbnailPath)
        {
            if (string.IsNullOrWhiteSpace(uniqueImagePath) || string.IsNullOrWhiteSpace(uniqueThumbnailPath))
            {
                Debug.Assert(false, "Wrong IO specified");
                log.Error("Wrong IO specified");
                Console.WriteLine("Wrong IO specified");
                return (false, 0, 0);
            }

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(uniqueThumbnailPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(uniqueThumbnailPath));
                }

                Image image = Image.FromFile(uniqueImagePath);
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                thumb.Save(uniqueThumbnailPath, System.Drawing.Imaging.ImageFormat.Png);

                return (true, thumb.Width, thumb.Height);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, "Failed to generate Thumbnail, general Exception", ex.Message);
                log.Error("Failed to generate Thumbnail, general Exception", ex);
                Console.WriteLine("Failed to generate Thumbnail, general Exception", ex);
                return (false, 0, 0);
            }

        }

        private static string GetMd5Hash(Image img)
        {
            return GetMd5Hash(ImageToByte(img));
        }

        private static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static string GetMd5Hash(byte[] buffer)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(buffer);

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
