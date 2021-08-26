<Query Kind="Statements" />

var updateConsignmentSenderDictionary = new Dictionary<string, int>()
	{ {"THESUPPLYCHAIN", 34585},
	  {"CHHWOODPRODUCTS", 36527}
	  };
	  
	  Console.WriteLine(updateConsignmentSenderDictionary["THESUPPLYCHAIN"]);
	  Console.WriteLine(updateConsignmentSenderDictionary["THESUPPLYchain"]); // throws key not found exception
	  