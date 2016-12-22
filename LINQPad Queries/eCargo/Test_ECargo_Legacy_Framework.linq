<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Common Files\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Delphi.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Legacy\Framework\bin\Release\ECargo.Legacy.Framework.dll">D:\dev\eCargo\eCargo.CSharp\Legacy\Framework\bin\Release\ECargo.Legacy.Framework.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.Net\Shared\ComImports\Interop.MSXML2.dll">D:\dev\eCargo\eCargo.Net\Shared\ComImports\Interop.MSXML2.dll</Reference>
  <Namespace>uConverts.Units</Namespace>
</Query>

double doubleValue = 49.04501206;
var stringValue = uConverts.Units.uConverts.Convert(doubleValue);
Console.WriteLine($"stringValue: {stringValue}");