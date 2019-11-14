<Query Kind="Statements">
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\Autofac.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\Autofac.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\EntityFramework.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\EntityFramework.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\EntityFramework.SqlServer.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\EntityFramework.SqlServer.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\Flux.Conversion.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\Flux.Conversion.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\Flux.Conversion.R4.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\Flux.Conversion.R4.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\Flux.Framework.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\Flux.Framework.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\linq2db.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\linq2db.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\linquifier.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\linquifier.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\NLog.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\NLog.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\soe.core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\soe.core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\soe.linq.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Conversion.R4\bin\Debug\netstandard2.0\soe.linq.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\System.Data.SqlClient.dll">D:\Dev\soeconversions-gl\trunk\build\x64\debug\Flux.Runner\System.Data.SqlClient.dll</Reference>
</Query>

var sqlConnection = new SqlConnection("server=AKDERNEST;Integrated Security=SSPI;database=GRAHA045822");
sqlConnection.Open();
var r4Documents = @"D:\Conversions\R4\R4_Patient_Documents\GRAHA045822_files\PatLetters";
var documents = Flux.Conversion.R4.Adapters.Adapter.GetDocuments(r4Documents, null, sqlConnection);
documents.Count().Dump();
documents.Take(10).Dump();