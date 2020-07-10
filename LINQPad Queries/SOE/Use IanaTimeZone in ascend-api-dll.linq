<Query Kind="Program">
  <Reference Relative="..\..\..\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\ascend.api.dll">D:\Dev\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\ascend.api.dll</Reference>
  <Reference Relative="..\..\..\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\soe.core.dll">D:\Dev\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\soe.core.dll</Reference>
  <Namespace>Soe</Namespace>
</Query>

// Requires LinqPad 6 as it uses .Net Core
// [[AC-1270] Fix the GET /schedule API to apply offset on the time when retrieving schedules - SoE JIRA] (https://soeidental.atlassian.net/browse/AC-1270)
// [[AC-1030] As an Ascend customer, I need an API to get a provider's availability for a day (excluding the booked appointments) so that I can know the actual availability of a provider for booking appointments - SoE JIRA] (https://soeidental.atlassian.net/browse/AC-1030#icft=AC-1030)

void Main()
{
	var dateTimeStrings = new[]{ "2020-03-15 21:00:00", "2020-03-15 21:30:00", "2020-04-15 21:00:00", "2020-04-15 21:30:00" };
	Console.WriteLine($"{"UTC".PadRight(23)}{"Local with offset".PadRight(23)}{"Local without offset".PadRight(23)}");
	dateTimeStrings.ToList().ForEach(dt => RenderUtcAndLocal(dt));
}

// Define other methods, classes and namespaces here
void RenderUtcAndLocal(string dateTimeString){
//	var timezone = new IanaTimeZone("Australia/ACT");
	var timezone = new IanaTimeZone("Australia/Sydney");
	var utcDateTime = DateTime.Parse(dateTimeString);
	var localDateTimeNoOffset = timezone.UtcToLocal(utcDateTime, false);
	var localDateTimeWithOffset = timezone.UtcToLocal(utcDateTime, true);
	Console.WriteLine("{0,-23:G}{1,-23:G}{2,-23:G}", utcDateTime, localDateTimeNoOffset, localDateTimeWithOffset);
}
