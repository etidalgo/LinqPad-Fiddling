<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Common Files\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Delphi.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Common Files\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Vcl.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Common Files\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.VclRtl.dll</Reference>
  <Reference Relative="..\..\..\eCargo\eCargo.Net\Win32\Output\eCargoWin32.dll">D:\dev\eCargo\eCargo.Net\Win32\Output\eCargoWin32.dll</Reference>
  <Namespace>EOFields</Namespace>
  <Namespace>VortalDOM</Namespace>
</Query>

TVortalDateTime dateTime = new TVortalDateTime("<VORTAL_DATE_TIME> <DATE_VALUE>26 Sep 2016</DATE_VALUE> <TIME_ZONE>UTC@@plus;12</TIME_ZONE> </VORTAL_DATE_TIME>");
// dateTime.XML = "<VORTAL_DATE_TIME> <DATE_VALUE>26 Sep 2016</DATE_VALUE> <TIME_ZONE>UTC@@plus;12</TIME_ZONE> </VORTAL_DATE_TIME>";
Console.WriteLine(dateTime.DateTimeString);
Console.WriteLine("dateTime.XML: '{0}'", dateTime.XML);
dateTime.TimeZone.Value = "UTC@@plus;10";
Console.WriteLine("dateTime.DirtyXML: {0}", dateTime.DirtyXML);
TVortalDOM vortalDom = new TVortalDOM();
vortalDom.SetValue("Alpha", dateTime.XML);
Console.WriteLine("vortalDom.GetXML(): {0}", vortalDom.GetXML());
