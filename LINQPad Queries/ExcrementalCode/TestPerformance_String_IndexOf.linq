<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Diagnostics</Namespace>
</Query>


static void Main()
{
    string s = new string(' ', 10000) + "*" + new string(' ', 10000);
    TestPerf("StringComparison.CurrentCulture", () => s.IndexOf("*", StringComparison.CurrentCulture));
    TestPerf("StringComparison.Ordinal", () => s.IndexOf("*", StringComparison.Ordinal));
    TestPerf("StringComparison.OrdinalIgnoreCase", () => s.IndexOf("*", StringComparison.OrdinalIgnoreCase));
}

private static void TestPerf(string name, Func<int> finder)
{
    finder();

    var timer = Stopwatch.StartNew();
    for (int i = 0; i != 1000; ++i)
    {
        if(finder() != 10000)
            throw new InvalidOperationException("Bug in implementation.");
    }
    timer.Stop();
    Console.WriteLine($"{name} took {timer.ElapsedMilliseconds} ms.");
}
