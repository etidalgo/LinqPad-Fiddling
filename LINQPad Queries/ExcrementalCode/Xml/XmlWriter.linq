<Query Kind="Statements" />

// [Create XML in C#] (https://www.c-sharpcorner.com/UploadFile/mahesh/create-xml-in-C-Sharp/)
using (XmlWriter writer = XmlWriter.Create(Console.Out))
{
	writer.WriteStartDocument();
	writer.WriteStartElement("Hello-XML");
	writer.WriteEndElement();
	writer.WriteEndDocument();
}
