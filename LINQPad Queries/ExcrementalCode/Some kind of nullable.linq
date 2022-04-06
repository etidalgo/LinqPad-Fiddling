<Query Kind="Program" />

#nullable enable
void Main()
{
	Extensions.AsComments(null, null).Dump();
	Extensions.AsComments("alpha", null).Dump();
	Extensions.AsComments(null, "beta").Dump();
	Extensions.AsComments("alpha", "beta").Dump();
}

public record Comment(string? By, string Text);

// Define other methods and classes here
public static class Extensions {
	public static IEnumerable<Comment>? AsComments(string? med, string? den){
		if(!String.IsNullOrEmpty(med)){
			yield return new Comment(null, $"Med {med}");
		}
		if(!String.IsNullOrEmpty(den)){
			yield return new Comment(null, $"Den {den}");
		}
	}
}