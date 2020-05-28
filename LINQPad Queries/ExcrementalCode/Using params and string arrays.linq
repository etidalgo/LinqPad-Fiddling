<Query Kind="Program" />

void Main()
{
	ConsumeParameters();
	ConsumeParameters("alpha");
	ConsumeParameters("beta", "gamma");
// 	ConsumeParameters("Dentist", 2, "two");
	ConsumeParameters();
}

// Define other methods and classes here
void ConsumeParameters(params string[] parameters){
	parameters.Dump();
}
