<Query Kind="Program">
  <Reference Relative="..\..\..\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\ascend.api.dll">D:\Dev\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\ascend.api.dll</Reference>
  <Reference Relative="..\..\..\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\soe.core.dll">D:\Dev\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\soe.core.dll</Reference>
  <Namespace>Soe</Namespace>
</Query>

	// Requires LinqPad 6 as it uses .Net Core

void Main()
{
	var dateTimeStrings = new[]{ "2020-03-15 21:00:00", "2020-03-15 21:30:00" };
	dateTimeStrings.ToList().ForEach(dt => RenderUtcAndLocal(dt));
}

// Define other methods, classes and namespaces here
void RenderUtcAndLocal(string dateTimeString){
	dateTimeString.Dump("text");
	var timezone = new IanaTimeZone("Australia/ACT");
	var utcDateTime = DateTime.Parse(dateTimeString);
	utcDateTime.Dump("Utc");
	
	var localDateTimme = timezone.UtcToLocal(utcDateTime);
	localDateTimme.Dump("Local");
}