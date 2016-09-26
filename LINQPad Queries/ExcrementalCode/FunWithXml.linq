<Query Kind="Program" />

void Main()
{
	string rawXml = @"<PolicyChangeSet schemaVersion=""2.1"" username="""" description=""""><Attachment name="""" contentType=""""><Description/><Location></Location><SomeElement></SomeElement><SomeElement></SomeElement><SomeDate></SomeDate></Attachment></PolicyChangeSet>";
	Console.WriteLine(rawXml);
	Console.WriteLine("-------------");
	DateTime date = DateTime.Now;
	Console.WriteLine(date.ToString("yyyy-MM-dd"));
	var xml = XDocument.Parse(rawXml);
	// ReplaceValue(xml, "//Attachment/SomeElement", "Julius");
	ReplaceValue(xml, "(//Attachment/SomeElement)[2]", "Julius");
	ReplaceValue(xml, "(//Attachment/SomeElement)[1]", "Arthur"); // 1-based
	ReplaceValue(xml, "//Attachment/SomeDate", date.ToString("yyyy-MM-dd"));
	Console.WriteLine(xml.ToString());
}

// Define other methods and classes here
	static void ReplaceValue(XNode document, string xpath, string replacement)
	{
	    var nodes = document.XPathSelectElements(xpath);
	    nodes.ToList().ForEach(node => { node.Value = replacement; });
	}
	