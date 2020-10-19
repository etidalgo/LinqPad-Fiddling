<Query Kind="Statements" />

var dateTime = DateTime.Parse("2020-04-01");
dateTime.Dump();
dateTime.AddHours(11);
dateTime.Dump();
dateTime = dateTime.AddHours(11);
dateTime.Dump();