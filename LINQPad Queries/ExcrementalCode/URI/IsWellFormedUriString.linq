<Query Kind="Statements" />

var connectionString = "Host=ec2-54-216-48-43.eu-west-1.compute.amazonaws.com;Username=bfpirelcvvizpo;Database=d3u54n5mli73b1;Port=5432;Password=6f7029a218958fdca31a4259f7cd792dd8ca1e97435a5e5320133a26a4b19095;SSL Mode=Require;Trust Server Certificate=true";
var connectionUri = "postgres://bfpirelcvvizpo:6f7029a218958fdca31a4259f7cd792dd8ca1e97435a5e5320133a26a4b19095@ec2-54-216-48-43.eu-west-1.compute.amazonaws.com:5432/d3u54n5mli73b1";

Uri.IsWellFormedUriString(connectionString, UriKind.Absolute).Dump();

Uri.IsWellFormedUriString(connectionUri, UriKind.Absolute).Dump();
