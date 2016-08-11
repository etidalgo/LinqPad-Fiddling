<Query Kind="Program" />

void Main()
{
	// string[] pArgs = new string[] {"alpha", "beta"};
	string[] pArgs = new string[]{};
	// string[] pArgs = null;
	string msg = string.Join(", ", pArgs);
	Console.WriteLine("msg: {0}", msg);
}

// Define other methods and classes here
