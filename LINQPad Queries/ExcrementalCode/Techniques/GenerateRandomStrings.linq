<Query Kind="Program" />

void Main()
{
	Console.WriteLine(QuickAndDirty.RandomString(10));
}

public sealed class QuickAndDirty {
// https://stackoverflow.com/a/1344242
	private static Random random = new Random();
	
	public static string RandomString(int length)
	{
	    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
	    return new string(Enumerable.Repeat(chars, length)
	      .Select(s => s[random.Next(s.Length)]).ToArray());
	}
}