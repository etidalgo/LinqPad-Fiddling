<Query Kind="Program">
  <Reference Relative="..\..\..\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\NodaTime.1.3.1\lib\net35-Client\NodaTime.dll</Reference>
  <Namespace>NodaTime</Namespace>
</Query>

void Main()
{
	Instant date20160701 = Instant.FromUtc(2016, 07, 01, 0, 0, 0);
	Instant date20160715 = Instant.FromUtc(2016, 07, 15, 0, 0, 0);
	Instant date20160801 = Instant.FromUtc(2016, 08, 01, 0, 0, 0);
	Instant date20160815 = Instant.FromUtc(2016, 08, 15, 0, 0, 0);
	Instant date20160825 = Instant.FromUtc(2016, 08, 25, 0, 0, 0);
	Instant date20160831 = Instant.FromUtc(2016, 08, 31, 0, 0, 0);
	Instant date20160901 = Instant.FromUtc(2016, 09, 01, 0, 0, 0);
	Instant date20160930 = Instant.FromUtc(2016, 09, 30, 0, 0, 0);
	Instant? noDate = null;
		
		
				
}

// Define other methods and classes here
class PlotterBaseline {
}

class NodaPlotter {
	static void Baseline() {
		Instant plotStart = Instant.FromUtc(2016, 06, 15, 0, 0, 0);
		Instant plotEnd = Instant.FromUtc(2016, 10, 31, 0, 0, 0);
		}
	
	void Plot(Instant newEffectiveFromInclusive, Instant? newEffectiveTo, Instant currentEffectiveFromInclusive, Instant? currentEffectiveTo) {
		// StringBuilder
	}

	void AddFill(StringBuilder sb) {
		sb.Add("-");
	}	
	void AddEmpty(StringBuilder sb) {
		sb.Add(".");
	}
}