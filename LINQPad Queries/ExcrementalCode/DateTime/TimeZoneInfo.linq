<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.InteropServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.InteropServices.RuntimeInformation.dll</Reference>
  <Namespace>System.Runtime.InteropServices</Namespace>
</Query>

void Main()
{
	ConvertToLocal(new DateTime(2019, 06, 15, 8, 0, 0));
	ConvertToLocal(new DateTime(2019, 01, 15, 8, 0, 0));
	ConvertToLocal(new DateTime(2018, 06, 15, 8, 0, 0));
	ConvertToLocal(new DateTime(2018, 11, 15, 8, 0, 0));
}

// Define other methods and classes here

void ConvertToLocal(DateTime dateTime) {
	var ianaTimezone = "Europe/London";
	var osTimezone = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
	
	    ianaTimezone == "Europe/London" ?
	    "GMT Standard Time" :
	    throw new NotSupportedException("Only Europe/London timezone is currently supported on Windows OS") :
	
	    ianaTimezone;
	
	var IanaTimezone = ianaTimezone;
	var OSTimezone = TimeZoneInfo.FindSystemTimeZoneById(osTimezone);
	Console.WriteLine($"DateTime in UTC: {dateTime}");
	
	var local = TimeZoneInfo.ConvertTimeFromUtc(dateTime, OSTimezone);
	
	Console.WriteLine($"Local time from UTC {local}");
	if (!OSTimezone.IsDaylightSavingTime(local))
	{
		Console.WriteLine("Not in daylight savings");
	    //TODO: figure out why 1 hour has to be added
	    local = local.AddHours(1);
	}
	
	Console.WriteLine($"Local time adjusted {local}");
	Console.WriteLine("--");
}