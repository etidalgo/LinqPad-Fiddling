<Query Kind="Statements">
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.D4W.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.D4W.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Framework.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Framework.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\soe.linq.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\soe.linq.dll</Reference>
  <Namespace>Flux.Conversion.Core.Models</Namespace>
  <Namespace>Flux.Conversion.D4W.DataProviders</Namespace>
  <Namespace>Flux.Conversion.D4W.DataProviders.PatientTreatments.ToothCodes</Namespace>
</Query>

ToothLookup.Fdi["18"].Dump();
((Int16)2).PermanentToothPalmerCode().Dump($"D4W ToothNumber: 1 to Palmer");
Enumerable.Range(1,32).Select(ix => ix.ToString()).ToList().ForEach(tooth => ToothLookup.Fdi[tooth].Dump());
