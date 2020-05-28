<Query Kind="Program" />

void Main()
{
	// Run in LinqPad6 , .Net Core capable version
	try
	{
		var api = Assembly.LoadFrom(@"D:\Dev\soeconversions-gl\trunk\build\x86\release\Flux.Runner\Flux.Conversion.Core.dll");
		var imModels = api.GetTypes().Where(t => t.Name.StartsWith("Conv") && !t.IsEnum && !t.IsAbstract && !t.IsInterface);
		//imModels.Dump();
		imModels.ToList().ForEach(imm => GetProperties(imm));
		
	}
	catch (ReflectionTypeLoadException ex)
	{
	    StringBuilder sb = new StringBuilder();
	    foreach (Exception exSub in ex.LoaderExceptions)
	    {
	        sb.AppendLine(exSub.Message);
	        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
	        if (exFileNotFound != null)
	        {                
	            if(!string.IsNullOrEmpty(exFileNotFound.FusionLog))
	            {
	                sb.AppendLine("Fusion Log:");
	                sb.AppendLine(exFileNotFound.FusionLog);
	            }
	        }
	        sb.AppendLine();
	    }
	    string errorMessage = sb.ToString();
	    //Display or log the error based on your application.
		errorMessage.Dump();
	}	
}

// Define other methods, classes and namespaces here
void GetProperties(Type type){
	var properties = type.GetProperties().Where(p => p.Name != "LinkField");
	// type.Dump();
	// properties.Dump();
	
	Console.WriteLine($"Model: {type.Name}");
	properties.ToList().ForEach(prop => Console.WriteLine($"\t{prop.PropertyType.Name} {prop.Name}"));
}