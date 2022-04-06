<Query Kind="Program" />

void Main()
{
	var treatment1 = new Treatment("13", 1);
	var treatment2 = treatment1;
	treatment1.Dump();
	treatment2.Dump();
	treatment2.Occurences = 3;
	treatment1.Dump();
	treatment2.Dump();
}

// You can define other methods, fields, classes and namespaces here
    public class Treatment
    {
        public string Id { get; set; }
        public int Occurences { get; set; }

        public Treatment(string id, int occurences)
        {
            this.Id = id;
            this.Occurences = occurences;
        }
    }