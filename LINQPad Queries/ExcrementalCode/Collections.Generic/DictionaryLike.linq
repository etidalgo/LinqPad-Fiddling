<Query Kind="Program" />

void Main()
{
	var lex = new LikeADictionary();
	lex["war"] = "peace";
	lex["freedom"] = "slavery";
	lex["ignorance"] = "strength";
	
	Console.WriteLine(lex["freedom"]);
}

// Define other methods and classes here
class LikeADictionary { 
	Dictionary<string, string> _dictionary;
	public LikeADictionary() {
		_dictionary = new Dictionary<string, string>();
	}

	public string this[string pKey]
    {
        get
        {
			string value;
			_dictionary.TryGetValue(pKey, out value);
			return value;
        }
        set
        {
			_dictionary.Add(pKey, value);
        }
    }
}