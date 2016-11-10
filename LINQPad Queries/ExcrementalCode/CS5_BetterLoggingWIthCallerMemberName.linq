<Query Kind="Program">
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

// using System.Runtime.CompilerServices;

void Main()
{
	Log("testing");
}

// Define other methods and classes here
private static void Log(string message, 
  [CallerMemberName] string methodName = null, 
  [CallerFilePath] string sourceFile = null,
  [CallerLineNumber] int lineNumber = 0)
{
  Console.WriteLine("[{2} -- {0}] - {1} ({3}:{4})", 
    methodName, message, DateTime.Now,   
    sourceFile, lineNumber);
}