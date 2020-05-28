<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.Annotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.CompilerServices.VisualC.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <AppConfig>
    <Content>
      <configuration></configuration>
    </Content>
  </AppConfig>
</Query>

// Assembly.Load("System.Runtime, Version=4.2.1.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
// Assembly.LoadFile(@"D:\Dev\ascend-api\ascend.api\bin\Debug\netcoreapp2.1\linquifier.dll");
var assembly = Assembly.LoadFrom(@"D:\Dev\ascend-wavelength-api\ascend.api\bin\ReleaseR349au\netcoreapp2.1\publish\");
var types = assembly.GetTypes();
types.ToList().ForEach(ty => Console.WriteLine(ty.Name));