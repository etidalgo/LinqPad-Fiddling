<Query Kind="Statements" />

System.Web.HttpUtility.UrlDecode("\u0000").Dump();
Char.IsControl('\u0000').Dump();

var bogus = "embedded \u0000 null";
bogus.Dump();
var cleansed = new string(bogus.Where(c => !char.IsControl(c)).ToArray());
cleansed.Dump();
var cleansed2 = bogus.Where(c => !char.IsControl(c)).ToArray().ToString().Dump();
