<Query Kind="Statements" />


IEnumerable<string> ConsignmentNumbers = null;
			
int ix = 1;
foreach(var consignmentNumber in ConsignmentNumbers ?? Enumerable.Empty<string>())
{
	Console.WriteLine($"ix = {ix}");
    ix++;
}

// Object reference not set to an instance of an object
foreach(var consignmentNumber in ConsignmentNumbers)
{
	Console.WriteLine($"ix = {ix}");
    ix++;
}