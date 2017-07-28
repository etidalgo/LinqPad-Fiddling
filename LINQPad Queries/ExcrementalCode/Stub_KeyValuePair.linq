<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
IEnumerable<(string template, IEnumerable<KeyValuePair<string, string>> parameters)> PackagedMessages() {
    yield return ("alpha", new [] { new KeyValuePair<string, string>("", "") });
}
