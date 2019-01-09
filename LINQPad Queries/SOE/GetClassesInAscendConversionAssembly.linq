<Query Kind="Statements">
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\AscendConversion.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\AscendConversion.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\AWSSDK.Core.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\AWSSDK.Core.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\AWSSDK.SimpleSystemsManagement.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\AWSSDK.SimpleSystemsManagement.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Controls.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Controls.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Microsoft.SQL.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Microsoft.SQL.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Siebel.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Siebel.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Util.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.Util.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.XRef.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\BusOps.XRef.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\itextsharp.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\itextsharp.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\log4net.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\log4net.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\NodaTime.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\NodaTime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.DataSetExtensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\System.Data.SQLite.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\System.Data.SQLite.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Management.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.XML.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Linq.dll</Reference>
</Query>

// problems loading AscendConversion, abandoning this attempt except to leave this record as a warning to others.
var asm = Assembly.Load("AscendConversion");
var nameSpace = "AscendConversion.Databases.Base.Tables";

var classes = asm.GetTypes().Where(p =>
     p.Namespace == nameSpace
).ToList();
classes.ForEach(t => Console.WriteLine(t.Name));