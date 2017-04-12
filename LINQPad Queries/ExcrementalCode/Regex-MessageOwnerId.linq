<Query Kind="Program" />

void Main()
{
CheckIfFormat("ECARGOWORKER|11060|2017-03-09T10:01:02Z");
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
    Console.WriteLine("{0}", IsMessageOwnerIdFormat(text));
}

// Define other methods and classes here
bool IsMessageOwnerIdFormat(string text) {
    var MessageOwnerIdRegex = new Regex(@"[A-Za-z]+\|[0-9]+\|\d{4}?-\d{2}?-\d{2}?T\d{2}?:\d{2}?:\d{2}?Z");
    return MessageOwnerIdRegex.IsMatch(text);
}

