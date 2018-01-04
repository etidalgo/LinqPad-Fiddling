<Query Kind="Program">
  <Reference Relative="..\..\..\eCargo\ThirdParty\NuGetPackages\Equ.1.0.3\lib\net45\Equ.dll">D:\dev\eCargo\ThirdParty\NuGetPackages\Equ.1.0.3\lib\net45\Equ.dll</Reference>
  <Namespace>Equ</Namespace>
</Query>

void Main()
{
	Console.WriteLine(new Record("v1", "v2", "A") == new Record("v1", "v2", "B")); /* should be true, does MemberwiseEqualityIgnore work? */
	Console.WriteLine(new Record("v1", "v2", "A") == new Record("v1", "v2", "A")); /* true */
	Console.WriteLine(new Record("v1", "V2", "A") == new Record("v1", "v2", "A")); /* false but true if case-insensitive compare */
	Console.WriteLine(new Person("Sherlock", new Address("Baker Street", "London")) == new Person("Sherlock", new Address("Baker Street", "London"))); /* true */
	Console.WriteLine(new Person("SHERLOCK", new Address("Baker Street", "London")) == new Person("Sherlock", new Address("Baker Street", "London"))); /* false but true if case-insensitive compare */
}

// Define other methods and classes here
class Record : MemberwiseEquatable<Record>
{
    public Record(string value1, string value2, string transientValue)
    {
        Value1 = value1;
        Value2 = value2;
        TransientValue = transientValue;
    }

    public string Value1 { get; }

    public string Value2 { get; }

    [MemberwiseEqualityIgnore] // This seems to have problems in Linqpad
    public string TransientValue { get; }
}

class Person : MemberwiseEquatable<Person>
{
    public Person(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public string Name { get; }
    public Address Address { get; }
}

class Address : MemberwiseEquatable<Address>
{
    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }

    public string Street { get; }
    public string City { get; }
}