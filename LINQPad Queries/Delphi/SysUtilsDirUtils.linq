<Query Kind="Program">
  <Reference>&lt;CommonProgramFiles&gt;\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Delphi.dll</Reference>
  <Reference>&lt;CommonProgramFiles&gt;\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.Vcl.dll</Reference>
  <Reference>&lt;CommonProgramFiles&gt;\CodeGear Shared\RAD Studio\Shared Assemblies\5.0\Borland.VclRtl.dll</Reference>
  <Namespace>Borland.Delphi</Namespace>
  <Namespace>Borland.Delphi.Units</Namespace>
  <Namespace>Borland.Vcl</Namespace>
  <Namespace>Borland.Vcl.Units</Namespace>
</Query>

void Main()
{
	Console.WriteLine("{0}", Borland.Vcl.Units.SysUtils.DirectoryExists(@"D:\vault\Invoice PDF"));
}

// Define other methods and classes here
