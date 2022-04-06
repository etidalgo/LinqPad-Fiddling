<Query Kind="Statements" />

var connectionUri = "postgres://bfpirelcvvizpo:6f7029a218958fdca31a4259f7cd792dd8ca1e97435a5e5320133a26a4b19095@ec2-54-216-48-43.eu-west-1.compute.amazonaws.com:5432/d3u54n5mli73b1";
var namedComponents = "(scheme)://(username):(password)@(host):(port)/(database)";

var uri = new Uri(connectionUri);

var userInfo = uri.UserInfo.Split(':');
// var (userName, password) = uri.UserInfo.Split(':').Take(2); // no, doesn't work

var components = new[]{
	$"Host={uri.Host}",
	$"Username={userInfo[0]}",
	$"Database={uri.LocalPath.Split('/').Skip(1).First()}",
	$"Port={uri.Port}",
	$"Password={userInfo[1]}",
	$"SSL Mode=Require",
	$"Trust Server Certificate=true"
	};

var composed = String.Join(";", components);
composed.Dump();
var expected = "Host=ec2-54-216-48-43.eu-west-1.compute.amazonaws.com;Username=bfpirelcvvizpo;Database=d3u54n5mli73b1;Port=5432;Password=6f7029a218958fdca31a4259f7cd792dd8ca1e97435a5e5320133a26a4b19095;SSL Mode=Require;Trust Server Certificate=true";
expected.Dump();
composed.Equals(expected).Dump();

// alternate using Dictionary
// [How to initialize a dictionary with a collection initializer - C# Programming Guide | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer)
var entries = new Dictionary<string, string>{
	{"Host", uri.Host},
	{"Username", userInfo[0]},
	{"Database", uri.LocalPath.Split('/').Skip(1).First()},
	{"Port", uri.Port.ToString()},
	{"Password", userInfo[1]},
	{"SSL Mode", "Require"},
	{"Trust Server Certificate", "true"}
};

var formatted = entries.Select(e => $"{e.Key}={e.Value}");
var composed2 = string.Join(";", formatted);
composed2.Dump();
composed2.Equals(expected).Dump();