<Query Kind="Statements" />

// setx Bogus2021 'test' 
// refreshenv
// $env:Bogus2021
if( Environment.GetEnvironmentVariable("Bogus2021") == null) {
	Console.WriteLine("not found");
} else {
	Console.WriteLine("found");
}