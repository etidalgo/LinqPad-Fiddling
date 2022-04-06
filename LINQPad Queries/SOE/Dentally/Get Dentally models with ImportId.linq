<Query Kind="Program">
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\linq2db\3.4.3\lib\net472\linq2db.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\soe.core\1.1.69198\lib\net5.0\soe.core.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\soe.dentally\1.1.64284\lib\net5.0\soe.dentally.dll</Reference>
  <Reference>C:\Users\ernest.tidalgo\.nuget\packages\soe.linq.db\1.1.64284\lib\net5.0\soe.linq.db.dll</Reference>
</Query>

// soe.core.dll
// soe.dentally.dll
// soe.linq.dll
// linq2db.dll

void Main()
{
	var nspace = "Soe.Dentally";
	var assembly = Assembly.GetAssembly(typeof(Soe.Dentally.Account));
	Console.WriteLine($"{assembly.FullName}");
	var loadableTypes = GetLoadableTypes(assembly);
	loadableTypes
		.Where(t => t.Namespace == nspace && t.IsPublic && t.IsClass)
		.Where(t => t.GetProperty("ImportId") != null) 
		.ToList()
		.ForEach(a => Console.WriteLine(a.Name));
}

// Define other methods and classes here
IEnumerable<Type> GetLoadableTypes(Assembly assembly){
	try {
		return assembly.GetTypes();
	}
	catch(ReflectionTypeLoadException ex){
		// in this instance, the unloadable types are irrelevant. I only want the Dentally models. 
		return ex.Types.Where(t => t != null && t.IsPublic);
	}
}