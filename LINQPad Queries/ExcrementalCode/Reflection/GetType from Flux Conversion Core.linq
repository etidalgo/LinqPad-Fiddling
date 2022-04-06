<Query Kind="Statements" />

// Run in LinqPad6 , .Net Core capable version
try
{
	var api = Assembly.LoadFrom(@"D:\Dev\flux.apac\flux.apac\Flux.Runner\bin\Release\net5.0\Flux.Conversion.Core.dll");
	//Assembly.LoadFile(@"D:\Dev\ascend-api\ascend.api\bin\ReleaseR339uk\netcoreapp2.1\publish\soe.core.dll");
	//Assembly.LoadFile(@"D:\Dev\ascend-api\ascend.api\bin\ReleaseR339uk\netcoreapp2.1\publish\linq2db.dll");
    //The code that causes the error goes here.
	var type = api.GetType("Flux.Conversion.Core.Models.ConvPatient");
	if(type != null) {
		type.Name.Dump(); 
	} else {
		"Null".Dump();
	}

	api.GetTypes().Dump();

//	type.Name.Dump();
}
catch (ReflectionTypeLoadException ex)
{
	"Reflection exception".Dump();
	
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