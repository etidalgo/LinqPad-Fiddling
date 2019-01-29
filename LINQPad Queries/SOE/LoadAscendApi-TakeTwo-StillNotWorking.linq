<Query Kind="Statements">
  <Reference Relative="..\..\..\ascend-api\ascend.api\bin\DebugUk\netcoreapp2.1\ascend.api.dll">D:\Dev\ascend-api\ascend.api\bin\DebugUk\netcoreapp2.1\ascend.api.dll</Reference>
  <Reference Relative="..\..\..\ascend-api\ascend.api\bin\DebugUk\netcoreapp2.1\linquifier.dll">D:\Dev\ascend-api\ascend.api\bin\DebugUk\netcoreapp2.1\linquifier.dll</Reference>
  <Reference Relative="..\..\..\Packages\Microsoft.Windows.Compatibility.2.0.1\Microsoft.Windows.Compatibility.2.0.1.nupkg">D:\Dev\Packages\Microsoft.Windows.Compatibility.2.0.1\Microsoft.Windows.Compatibility.2.0.1.nupkg</Reference>
</Query>

// problems loading AscendConversion, abandoning this attempt except to leave this record as a warning to others.
// "Could not load type 'System.Runtime.CompilerServices.IAsyncStateMachine' from assembly 'System.Runtime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'."
var asm = Assembly.Load("ascend.api");
var nameSpace = "Soe.Ascend";

var classes = asm.GetTypes().Where(p =>
     p.Namespace == nameSpace
).ToList();
classes.ForEach(t => Console.WriteLine(t.Name));