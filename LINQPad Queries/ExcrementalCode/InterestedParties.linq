<Query Kind="Program">
  <Reference Relative="..\..\..\NuGetPackages\Optional.3.2.0\lib\net462\Optional.dll">C:\dev\NuGetPackages\Optional.3.2.0\lib\net462\Optional.dll</Reference>
  <Namespace>Optional</Namespace>
</Query>

void Main()
{
	
}

// Define other methods and classes here
class InterestedParty {
	Optional.Option<IEnumerable<string>> NamedParties { get; }
	
	public InterestedParty(Optional.Option<IEnumerable<string>> namedParties) {
		NamedParties = namedParties;
	}
}

class InterestedParties {
	static InterestedParty NoOne = new InterestedParty(Option.None<IEnumerable<string>>());
	static InterestedParty Author = new InterestedParty(Option.None<IEnumerable<string>>());
	static InterestedParty NonApprovingReviewers = new InterestedParty(Option.Some<IEnumerable<string>>( new List<string>()));
}
