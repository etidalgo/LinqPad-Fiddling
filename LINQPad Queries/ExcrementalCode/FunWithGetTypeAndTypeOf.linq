<Query Kind="Statements" />

var dateTime = new DateTime(2017, 04, 01);
var dateTimeOffset = new DateTimeOffset(2017, 04, 01, 0, 0, 0, new TimeSpan(12, 0, 0));
Console.WriteLine("{0} vs {1}", dateTime.GetType(), typeof(DateTime));
Console.WriteLine("{0} vs {1}", dateTimeOffset.GetType(), typeof(DateTimeOffset));
var dateTimeTypeA = dateTime.GetType();
var dateTimeTypeB = typeof(DateTime);
Console.WriteLine("FullName, Name: {0}, {1} vs {2}, {3}", dateTimeTypeA.FullName, dateTimeTypeA.Name, dateTimeTypeB.FullName, dateTimeTypeB.Name);
