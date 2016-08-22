<Query Kind="Program">
  <Reference Relative="..\..\..\eCargo\eCargo.CSharp\Legacy\PreMigrationSnapshots\eCargoFramework.dll">D:\dev\eCargo\eCargo.CSharp\Legacy\PreMigrationSnapshots\eCargoFramework.dll</Reference>
  <Namespace>Utils</Namespace>
  <Namespace>Utils.Units</Namespace>
</Query>

// Uses eCargoFramework.dll - 

void Main()
{
//	Console.WriteLine(Utils.Units.Utils.DamnDelphi());
	Console.WriteLine(Utils.Units.Utils.FixAmper("bogus"));
	Console.WriteLine(Utils.Units.Utils.CleanUpFileName(@"D:\dev\eCargo\eCargo.Net\Shared\Framework\eCargoFramework?.dproj", '_'));

	string reallyBadFileName = @"a|b<c>d\e^f+g=h?i/j[k]l:m;n,o*p";// #0..#32
	Console.WriteLine(Utils.Units.Utils.CleanUpFileName(reallyBadFileName, '_'));
	StringBuilder sb = new StringBuilder();
	int ix;
	for(  ix = 0; ix <= 32 ; ix ++ ) {
		sb.Append( (char) ('A' + ix) );
		sb.Append( (char)ix );
	}
	sb.Append((char) ('A' + ix) );
	Console.WriteLine(Utils.Units.Utils.CleanUpFileName(sb.ToString(), '_'));
	
}

// Define other methods and classes here
