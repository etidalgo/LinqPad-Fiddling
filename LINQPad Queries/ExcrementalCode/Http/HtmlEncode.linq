<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Namespace>System.Web</Namespace>
</Query>

var encoding = HttpUtility.HtmlEncode("date & time");
Console.WriteLine(encoding);

// Encode and decode a name with spaces.
string name1 = XmlConvert.EncodeName("Order Detail");
Console.WriteLine("Encoded name: " + name1);
Console.WriteLine("Decoded name: " + XmlConvert.DecodeName(name1));

// Encode and decode a local name.
string name2 = XmlConvert.EncodeLocalName("a:book");
Console.WriteLine("Encoded local name: " + name2);
Console.WriteLine("Decoded local name: " + XmlConvert.DecodeName(name2));

string name3 = XmlConvert.EncodeName("date & time");
Console.WriteLine("Encoded name: " + name3);
Console.WriteLine("Decoded name: " + XmlConvert.DecodeName(name3));
