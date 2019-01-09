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
  <Reference Relative="..\..\..\ascend-itdb-tool\AscendConversion\bin\x64\Debug\System.Data.SQLite.dll">D:\Dev\ascend-itdb-tool\AscendConversion\bin\x64\Debug\System.Data.SQLite.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Reflection.dll</Reference>
</Query>

// Not really working
var nspace = "AscendConversion.Databases.Base.Tables";
var classes = 
	from t in Assembly.GetExecutingAssembly().GetTypes() 
	where t.IsClass // && t.Namespace == nspace 
	select t;
classes.ToList().ForEach(t => Console.WriteLine(t.Name));

var classesAcrossAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(t => t.GetTypes())
                       .Where(t => t.IsClass && t.Namespace == nspace);
classesAcrossAssemblies.ToList().ForEach(t => Console.WriteLine(t.Name));

// Type type = typeof(AscendConversion.Databases.Base.Tables.OrganizationProcedure);