<Query Kind="Program" />

void Main()
{
	
}

class ArbitraryClass{
	public ArbitraryClass() {}
	
	string ArbitraryMethod(string orig) {
		return orig + ((new Random()).Next(0, 13).ToString());
	}
}

// Define other methods and classes here
void Apply(Func<ArbitraryClass, (string orig, string revised)> func) {
}
