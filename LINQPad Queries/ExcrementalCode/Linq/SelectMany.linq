<Query Kind="Statements" />

const string DicomExtLowercase = ".dic";
const string JpegExtLowercase = ".jpg";
const string PngExtLowercase = ".png";

var extensions = new List<string> { DicomExtLowercase, JpegExtLowercase, PngExtLowercase };

//var directoryName = @"D:\Conversions\AC-408_MCDental\exactDocsDataPath\2018\Oct";
var directoryName = @"D:\Conversions\AC-408_MCDental\exactDocsDataPath\2018";
var imageFiles = extensions.SelectMany(ext => Directory.GetFiles(directoryName, $"*{ext}", SearchOption.AllDirectories));
imageFiles.Dump();
