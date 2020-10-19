<Query Kind="Program" />

void Main()
{
// [Generate XML From Object in C#] (https://www.c-sharpcorner.com/UploadFile/ff2f08/generate-xml-from-object-in-C-Sharp/)
// [XElement Constructor (System.Xml.Linq) | Microsoft Docs] (https://docs.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement.-ctor?view=netcore-3.1#System_Xml_Linq_XElement__ctor_System_Xml_Linq_XName_System_Object___)
	var bogi = new[] {
		new BogusObject("Will Eisner", "The Spirit", "Writer/Artist"),
		new BogusObject("Mike Grell", "The Warlord", "Artist/Writer"),
		new BogusObject("George Perez", "Team books", "Artist/Writer"),
		new BogusObject("Gardner Fox", "Golden age characters", "Writer") };
		
	var xmlRepresentation = new XElement("BogusObjects", 
			new XAttribute("Count", bogi.Count()),
	            from el in bogi
	            select new XElement("BogusObject",
					new XAttribute("Attr1", "alpha"),
					new XAttribute("Attr2", "beta"),
					new XAttribute("Attr3", "delta"),
	                new XElement("Name", el.Name),
	                new XElement("KnownFor", el.KnownFor),
	                new XElement("Type", el.Type)
	                ));
	Console.WriteLine(xmlRepresentation);
}

// Define other methods and classes here
public class BogusObject
{
    public BogusObject(string name, string knownFor, string type)
	{
		Name = name;
		KnownFor = knownFor;
		Type = type;
	}
	public string Name { get; }
	public string KnownFor { get; }
	public string Type { get; }
}