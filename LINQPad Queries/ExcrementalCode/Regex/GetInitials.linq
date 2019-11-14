<Query Kind="Program" />

void Main()
{

	var convProv = new ConvProvider{Surname = "1Dentistry", Firstname = "66", Name ="Dr Christina Thevalapan"};
	GetProviderInitials(convProv).Dump();
}

// Define other methods and classes here
public class ConvProvider{
public string Surname {get; set;}
public string Firstname {get; set;}
public string Name {get; set;}
}

string GetProviderInitials(ConvProvider prov)
{
   var fullName = $"{(string.IsNullOrWhiteSpace(prov.Surname) ? prov.Name : prov.Surname)} {(string.IsNullOrWhiteSpace(prov.Firstname) ? string.Empty : prov.Firstname)}";
   var initials = new Regex(@"(\b[a-zA-Z0-9])[a-zA-Z0-9]* ?");
   return initials.Replace(fullName, "$1").ToUpper();
}