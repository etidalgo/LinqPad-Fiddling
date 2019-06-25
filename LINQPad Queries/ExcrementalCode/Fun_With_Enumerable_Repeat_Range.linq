<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
    var tenCopies = Enumerable.Repeat(GetMockCommitHash(), 10);
    // Enumerable.Repeat(Console.WriteLine(GetMockCommitHash()), 10); // there is no TResult
    Console.WriteLine("Enumerable.Repeat(GetMockCommitHash(), 10) repeats the result, creates 10 copies, not 10 unique strings");
    Console.WriteLine(Enumerable.Repeat(GetMockCommitHash(), 10));

    Console.WriteLine("Enumerable.Range(0, 10).ToList().ForEach(act => Console.WriteLine(GetMockCommitHash())), displays 10 unique strings, but does not return");
    Enumerable.Range(0, 10).ToList().ForEach(act => Console.WriteLine(GetMockCommitHash()));

    var hashes = new List<string>();
    Enumerable.Range(0, 10).ToList().ForEach(act => hashes.Add(GetMockCommitHash()));
    Console.WriteLine(hashes.Take(3));
    Console.WriteLine(hashes.Take(4));
    Console.WriteLine(hashes.Take(5));
    Console.WriteLine(hashes.Take(6));
    Console.WriteLine(hashes.Take(7));
	
    Console.WriteLine("Enumerable.Range(0, 10).ToList().Select(act => GetMockCommitHash()); does return!");
    var hashbrowns = Enumerable.Range(0, 10).ToList().Select(act => GetMockCommitHash());
	hashbrowns.Dump();
}

// Define other methods and classes here
string GetMockCommitHash() {
    using(var rng = new RNGCryptoServiceProvider())
    {
        var raw = new byte[20];
        rng.GetBytes(raw);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < raw.Length; i++)
            sb.Append(raw[i].ToString("x2"));

        return sb.ToString();
    }
}