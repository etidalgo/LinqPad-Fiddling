<Query Kind="Statements">
  <Reference Relative="..\..\..\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\Dicom.Core.dll">D:\Dev\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\Dicom.Core.dll</Reference>
  <Reference Relative="..\..\..\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\Dicom.Native64.dll">D:\Dev\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\Dicom.Native64.dll</Reference>
  <Reference Relative="..\..\..\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\DICOM_Converter.dll">D:\Dev\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\DICOM_Converter.dll</Reference>
  <Reference Relative="..\..\..\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\log4net.dll">D:\Dev\soeconversions\trunk\APAC_Tools\ConvTool\External Data Mappers\DICOM_Converter\bin\x64\Release\log4net.dll</Reference>
</Query>

//var fileName = @"D:\Conversions\RCI_Fanta_Devonport\Fanta Devonport_Mediadent\Fanta Devonport Mediadent Patients\000001\40759576680maurice ralph.DIC";
//var uniqueImagePath = @"D:\Conversions\RCI_Fanta_Devonport\Sqls\ORG_ID\Images\40759576680maurice ralph.png";

var fileName = @"C:\ExPro\Patients\1011\4075957713040759576680maurice ralph-readable.raw.dic";
var uniqueImagePath = @"C:\ExPro\Patients\1011\4075957713040759576680maurice ralph-readable.raw.png";
var ( ImgSuccess,  ImgWidth,  ImgHeight,  ImgHash) = DICOM_Converter.Dicom.ConvertDICOMImageToPNG(fileName, uniqueImagePath);