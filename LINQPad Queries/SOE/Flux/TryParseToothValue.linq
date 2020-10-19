<Query Kind="Statements">
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.D4W.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.D4W.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Framework.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Framework.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\soe.linq.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\soe.linq.dll</Reference>
  <Namespace>Flux.Conversion.Core.Models</Namespace>
  <Namespace>Flux.Conversion.D4W.DataProviders</Namespace>
  <Namespace>Flux.Conversion.D4W.DataProviders.PatientTreatments.ToothCodes</Namespace>
</Query>

ToothLookup.Fdi["34"].Dump();

// D4W.ChartMissing.ToothN
short toothCode = 23;
toothCode.PermanentToothPalmerCode().Dump();

// D4W.Treatment.Tooth
"85".TryParseToothValue().Dump();
