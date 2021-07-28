<Query Kind="Program" />

void Main()
{
// throw ArgumentException
// var bogusCondition = (ArtifactCondition)Enum.Parse(typeof(ArtifactCondition), "bogus");

	TryParseArtifactCondition("Fair");
	TryParseArtifactCondition("veryfine");
	TryParseArtifactCondition("bogus");

	EnumParse<ArtifactCondition>("Fair");
	EnumParse<ArtifactCondition>("veryfine");
	EnumParse<ArtifactCondition>("bogus");

	// Gives errors, trying to show that this works only for enums. Needs work
	// EnumParse<SomeClass>("bogus");
	// EnumParse<SomeStruct>("bogus");
}

public class SomeClass{
	public int SomeValue { get; set; }
}

public struct SomeStruct{
	public int SomeValue;
}

ArtifactCondition? TryParseArtifactCondition(string value)
{
	ArtifactCondition? condition = null; 
	if(Enum.TryParse(value, true, out ArtifactCondition _condition)){
		condition = _condition;
	}

	condition.Dump($"ArtifactCondition:{value}");
	return condition;
}

// C# 7.3 proposal, [csharplang/blittable.md at master · dotnet/csharplang] (https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/blittable.md)
T? EnumParse<T>(string value) where T: unmanaged, Enum
{
	T? condition = null; 
	if(Enum.TryParse(value, true, out T _condition)){
		condition = _condition;
	}
	condition.Dump($"ArtifactCondition:{value}");	
	return condition;
}

public static class EnumExtensions {
	public static T? TryParseEnum<T>(this T enumType, string value) where T: unmanaged, Enum
	{
		T? condition = null; 
		if(Enum.TryParse(value, true, out T _condition)){
			condition = _condition;
		}
		condition.Dump($"ArtifactCondition:{value}");	
		return condition;
	}
}

//// C# 7.3 proposal, [csharplang/blittable.md at master · dotnet/csharplang] (https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.3/blittable.md)
//T? EnumParse2<T>(string value) where T: class, Enum
//{
//	T? condition = null; 
//	if(Enum.TryParse(value, true, out T _condition)){
//		condition = _condition;
//	}
//	condition.Dump($"ArtifactCondition:{value}");	
//	return condition;
//}


public enum ArtifactCondition{
	Poor,
	Fair,
	VeryFair,
	Good,
	VeryGood,
	Fine,
	VeryFine,
	Excellent,
	Mint,
	Pristine
};