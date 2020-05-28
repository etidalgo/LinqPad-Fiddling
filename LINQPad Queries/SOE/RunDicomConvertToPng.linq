<Query Kind="Statements">
  <Reference>D:\demo166\ConvToolDicomConverter\Dicom.Core.dll</Reference>
  <Reference>D:\demo166\ConvToolDicomConverter\Dicom.Native64.dll</Reference>
  <Reference>D:\demo166\ConvToolDicomConverter\DICOM_Converter.dll</Reference>
  <Reference>D:\demo166\ConvToolDicomConverter\log4net.dll</Reference>
</Query>

//var fileName = @"D:\Conversions\RCI_Fanta_Devonport\Fanta Devonport_Mediadent\Fanta Devonport Mediadent Patients\000001\40759576680maurice ralph.DIC";
//var uniqueImagePath = @"D:\Conversions\RCI_Fanta_Devonport\Sqls\ORG_ID\Images\40759576680maurice ralph.png";

var fileName = @"D:\Conversions\Oasis Exact Ascend\Schick_Original\020003\39048000000IO000001.dic";
var uniqueImagePath = @"D:\Conversions\Oasis Exact Ascend\Schick_Original\020003\39048000000IO000001.dic.png";
var ( ImgSuccess,  ImgWidth,  ImgHeight,  ImgHash) = DICOM_Converter.Dicom.ConvertDICOMImageToPNG(fileName, uniqueImagePath);