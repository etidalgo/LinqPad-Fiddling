<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Xml</Namespace>
</Query>

// Not really Linq

// XmlNode.SelectSingleNode Method (String) (System.Xml) <https://msdn.microsoft.com/en-us/library/fb63z0tw(v=vs.110).aspx>

public class Program
{
	static string rawXml = 
@"<?xml version=""1.0""?>
<!-- A fragment of a book store inventory database -->
<bookstore xmlns:bk=""urn:samples"">
  <book genre=""novel"" publicationdate=""1997"" bk:ISBN=""1-861001-57-8"">
    <title>Pride And Prejudice</title>
    <author>
      <first-name>Jane</first-name>
      <last-name>Austen</last-name>
    </author>
    <price>24.95</price>
  </book>
  <book genre=""novel"" publicationdate=""1992"" bk:ISBN=""1-861002-30-1"">
    <title>The Handmaid's Tale</title>
    <author>
      <first-name>Margaret</first-name>
      <last-name>Atwood</last-name>
    </author>
    <price>29.95</price>
  </book>
  <book genre=""novel"" publicationdate=""1991"" bk:ISBN=""1-861001-57-6"">
    <title>Emma</title>
    <author>
      <first-name>Jane</first-name>
      <last-name>Austen</last-name>
    </author>
    <price>19.95</price>
  </book>
  <book genre=""novel"" publicationdate=""1982"" bk:ISBN=""1-861001-45-3"">
    <title>Sense and Sensibility</title>
    <author>
      <first-name>Jane</first-name>
      <last-name>Austen</last-name>
    </author>
    <price>19.95</price>
  </book>
</bookstore>";
		
	public static void Main()
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(rawXml);
		XmlNode root = xmlDoc.DocumentElement;
		XmlNode book = root.SelectSingleNode("descendant::book[author/last-name='Austen']");
		// Doesn't work 
		// XmlNode book = root.SelectSingleNode("descendant::book[bk:ISBN='1-861001-45-3']");
		Console.WriteLine(book.InnerText);
		Console.WriteLine(book.InnerXml);
	}
}