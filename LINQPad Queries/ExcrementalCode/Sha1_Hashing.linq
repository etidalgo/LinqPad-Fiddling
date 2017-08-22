<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var hashValue = Hash("alpha");
	Console.WriteLine(hashValue);
}

// Define other methods and classes here
// https://stackoverflow.com/questions/17292366/hashing-with-sha1-algorithm-in-c-sharp
static string Hash(string input)
{
    using (SHA1Managed sha1 = new SHA1Managed())
    {
        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
        var sb = new StringBuilder(hash.Length * 2);

        foreach (byte b in hash)
        {
            // can be "x2" if you want lowercase
            sb.Append(b.ToString("x2"));
        }

        return sb.ToString();
    }
}
