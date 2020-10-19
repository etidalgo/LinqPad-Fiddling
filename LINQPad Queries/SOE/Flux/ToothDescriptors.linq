<Query Kind="Program">
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.D4W.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Conversion.D4W.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Framework.Core.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\Flux.Framework.Core.dll</Reference>
  <Reference Relative="..\..\..\..\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\soe.linq.dll">D:\Dev\soeconversions-gl\trunk\src\Flux.Runner\bin\Release\netcoreapp3.1\soe.linq.dll</Reference>
  <Namespace>Flux.Conversion.Core.Models</Namespace>
  <Namespace>Flux.Conversion.D4W.DataProviders</Namespace>
</Query>

void Main()
{
	var toothDescriptors = ToothDescriptor.Values;
	short beta = 1;
	beta.PermanentToothPalmerCode().Dump();
	Convert.ToInt16(beta).Dump();
	Enumerable.Range(1,32).ToList().ForEach(sh => (Convert.ToInt16(sh)).PermanentToothPalmerCode().Dump($"D4W ToothNumber: {sh} to Palmer"));
}