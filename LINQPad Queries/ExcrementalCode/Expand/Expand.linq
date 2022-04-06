<Query Kind="Program" />

void Main()
{
// case 1
var treatments = new[]{ new Treatment("1", 10)};

var expandedTreatments = treatments.Expand(); // array with 10 treatments
expandedTreatments.Dump();

// case 2
var treatments2 = new[]{ 
    new Treatment("1", 1),
    new Treatment("2", 10),
    new Treatment("3", 5)
};

var expandedTreatments2 = treatments2.Expand(); // array with expanded treatments	
expandedTreatments2.Dump();
}

// You can define other methods, fields, classes and namespaces here

public class Treatment { 
    public string Id { get; set; }
    public int Occurences { get; set; }

    public Treatment(string id, int occurences){ 
        this.Id = id;
        this.Occurences = occurences;
    }
}

public static class TreatmentHelpers {
	public static IEnumerable<Treatment> Expand(this IEnumerable<Treatment> treatments){
		treatments.Where(t => t.Occurences > 1).ToList().ForEach(tr => 
			{ 
				var toAdd = Enumerable.Range(0, tr.Occurences - 1).Select(_ => new Treatment(tr.Id, 10));
				treatments = treatments.Concat(toAdd); // why doesn't this create an infinite loop? 
			});
		return treatments;
	}
}
