<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Reflection.dll</Reference>
  <Namespace>System.Reflection</Namespace>
</Query>

// Run in LinqPad6 , .Net Core capable version
try
{
	var api = Assembly.LoadFrom(@"D:\Dev\ascend-api\ascend.api\bin\ReleaseR339uk\netcoreapp2.1\publish\ascend.api.dll");
	//Assembly.LoadFile(@"D:\Dev\ascend-api\ascend.api\bin\ReleaseR339uk\netcoreapp2.1\publish\soe.core.dll");
	//Assembly.LoadFile(@"D:\Dev\ascend-api\ascend.api\bin\ReleaseR339uk\netcoreapp2.1\publish\linq2db.dll");
    //The code that causes the error goes here.
	api.GetTypes().Dump();
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