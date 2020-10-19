<Query Kind="Statements" />

// [Creating XML Trees in C# (LINQ to XML) | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/creating-xml-trees-linq-to-xml-2)

XElement contacts =  
    new XElement("Contacts",  
        new XElement("Contact",  
            new XElement("Name", "Patrick Hines"),
            new XElement("Phone", "206-555-0144"),  
            new XElement("Address",  
                new XElement("Street1", "123 Main St"),  
                new XElement("City", "Mercer Island"),  
                new XElement("State", "WA"),  
                new XElement("Postal", "68042")  
            )  
        )  
    );  
Console.WriteLine(contacts); 

XElement phone = new XElement("Phone",  
    new XAttribute("Type", "Home"),  
    "555-555-5555");  
Console.WriteLine(phone); 