<Query Kind="Statements" />

if( Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION") == null) {
	Console.WriteLine("not found");
} else {
	Console.WriteLine("found");
}