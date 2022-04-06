<Query Kind="Program" />

void Main()
{
	string EmptyRecord = "999999999999999999999999NNNNNNNNNNNNNNNNNN9999999999NNNNNNcc\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0";
	EmptyRecord.Length.Dump();
	
	new[]{"000", "00", "99", "01", "13", "53", "ab", "alpha", "\01"}.ToList().
	ForEach(x => { 
		var result = ProbeHelpers.ParseProbe(x);
		Console.WriteLine($"{x}: {result}");
	});
	
	var record = "019913";
	var readings = Enumerable.Range(0, 3).Select(ix => record.Substring(ix*2, 2)).Select(st => ProbeHelpers.ParseProbe(st));
	var toothPoints = new[]{"Distal", "Central", "Messial"};
	readings.Zip(toothPoints, (int? reading, string point) => reading.HasValue? $"{point}: {reading}": "no reading").Dump();
	
}

// You can define other methods, fields, classes and namespaces here
public static class ProbeHelpers{
	public static int? ParseProbe(string probe){
		return probe switch{
			"99" => null,
			var x when Regex.IsMatch(x, "^[0-8\0][0-8]$") => Int32.Parse(x.Replace('\0', '0')),
			//var y when Regex.IsMatch(y, "^[\0][0-8]$") => Int32.Parse(y.Replace('\0', '0')),
			_ => null
		};
	}
}