<Query Kind="Program" />

void Main()
{
	DemonstrateIDisposableWithHappyOrUnhappyPath(followHappyPath: true);
	DemonstrateIDisposableWithHappyOrUnhappyPath(followHappyPath: false);
}

void DemonstrateIDisposableWithHappyOrUnhappyPath(bool followHappyPath) {
	Console.WriteLine(followHappyPath ? "Pursuing the happy path" : "Pursuing the unhappy path");
	using(new ArtificialLogScope()) {
        Console.WriteLine("\tRunning some stuff inside the using");
		if (followHappyPath) {
	        Console.WriteLine("\tFollowing the happy path");
		} else {
	        Console.WriteLine("\tFollowing the unhappy path");
			throw new Exception("Force exception here to pursue the unhappy path");
		}
	}
    Console.WriteLine("Outside of the using\n");
}
// Define other methods and classes here
    public sealed class ArtificialLogScope : IDisposable
    {
        readonly Stopwatch _timer;

        public ArtificialLogScope()
        {
            _timer = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("Log object has gone out of scope");
        }
    }
