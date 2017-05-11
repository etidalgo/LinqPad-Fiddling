<Query Kind="Program" />

void Main()
{
CheckIfFormat("Customer ebb635a3-653e-41d3-aa33-5799e8b19cc0");
CheckIfFormat("ECARGONONWORKER|10060|2016-04-09T10:01:02Z");
CheckIfFormat("Tests on ECARGORANDOMDEV");
CheckIfFormat("|11060|2017-03-09T10:01:02Z");
CheckIfFormat("ECARGOWORKER|-1|2017-03-09T10:01:02Z");
CheckIfFormat("ECARGOWORKER||2017-03-09T10:01:02Z");
CheckIfFormat("ECARGOWORKER|11060|");
CheckIfFormat("ECARGOWORKER|11060|{nextYear}-03-09T10:01:02Z");
CheckIfFormat("Completely random string");
CheckIfFormat("");
}

void CheckIfFormat(string text) {
    Console.WriteLine("{0}", ContainsRegex(text, @"[0-9A-Fa-f]{8}[-]?([0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}"));
}


// Define other methods and classes here
bool ContainsRegex(string text, string regexpression) {
    var regex = new Regex(regexpression);
    return regex.IsMatch(text);
}