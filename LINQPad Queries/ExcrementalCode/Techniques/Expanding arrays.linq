<Query Kind="Program" />

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var treatments = new[]{
            new Treatment("1", 1),
            new Treatment("2", 10),
            new Treatment("3", 5)
                                };

            List<Treatment> expandedTreatments = new List<Treatment>();

            foreach (Treatment t in treatments)
            {
                for(int i = t.Occurences; i > 0; i--)
                {
                    expandedTreatments.Add(t);
                }
            }
            
            Console.WriteLine("Expanded Treatment Array Contents: ");
            foreach (Treatment t in expandedTreatments)
            {
                Console.WriteLine("ID: " + t.Id.ToString());
            }

//            Console.ReadKey();
        }
    }

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