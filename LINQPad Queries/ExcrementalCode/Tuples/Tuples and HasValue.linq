<Query Kind="Program" />

void Main()
{
	((int? distal, int? central, int? messial) facial, (int? distal, int? central, int? messial) lingual) = Extensions.AsProbes();
	if(facial.distal.HasValue)
		Console.WriteLine("facial.distal");
	
	if(facial.central.HasValue)
		Console.WriteLine("facial.central");

	if(facial.messial.HasValue)
		Console.WriteLine("facial.messial");
}

// You can define other methods, fields, classes and namespaces here
public class Extensions {
	public static ((int? distal, int? central, int? messial) facial, (int? distal, int? central, int? messial) lingual) AsProbes() =>
		((1, null, 3), (2, 4, null));
}