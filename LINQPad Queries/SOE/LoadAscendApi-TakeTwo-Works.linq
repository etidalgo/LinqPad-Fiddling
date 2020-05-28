<Query Kind="Statements">
  <Reference Relative="..\..\..\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\ascend.api.dll">D:\Dev\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\ascend.api.dll</Reference>
  <Reference Relative="..\..\..\Packages\Microsoft.Windows.Compatibility.2.0.1\Microsoft.Windows.Compatibility.2.0.1.nupkg">D:\Dev\Packages\Microsoft.Windows.Compatibility.2.0.1\Microsoft.Windows.Compatibility.2.0.1.nupkg</Reference>
</Query>

// Load in LinqPad6, this is a .net core app
// Use release directory with all the files
var asm = Assembly.Load("ascend.api");

//Console.WriteLine("------------------------------");
//var nameSpace = "Soe.Ascend";
//var ascendClasses = asm.GetTypes().Where(p => p.Namespace == nameSpace).ToList();
//ascendClasses.ForEach(t => Console.WriteLine(t.Name));
//
//Console.WriteLine("------------------------------");
//nameSpace = "Soe.Services";
//var servicesClasses = asm.GetTypes().Where(p => p.Namespace == nameSpace).ToList();
//servicesClasses.ForEach(t => Console.WriteLine(t.Name));

Console.WriteLine("------------------------------");
var nameSpace = "Soe.Services.People"; // "Soe.Services.Medical";
var classes = asm.GetTypes().Where(t => t.Namespace == nameSpace && !t.IsNested).Take(13).ToList(); // IsNested is classes like "<>c__DisplayClass0_0"
classes.ForEach(t => Console.WriteLine($"{t.Name}"));

Console.WriteLine("------------------------------");
var getPatientsArgs = classes.Where(c => c.Name == "GetPatientsArgs").First();
var properties = getPatientsArgs.GetProperties().ToList();
properties.ForEach(p => Console.WriteLine($"{p.PropertyType} {((p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) ? Nullable.GetUnderlyingType(p.PropertyType): p.PropertyType)} {p.Name} "));

