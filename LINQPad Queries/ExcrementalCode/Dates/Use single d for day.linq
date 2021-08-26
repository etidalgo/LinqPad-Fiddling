<Query Kind="Statements" />

DateTime.Now.ToString("[ d]").Dump(); // 1-9
DateTime.Now.AddDays(19).ToString("[ d]").Dump(); // 12 - 20
DateTime.Now.AddDays(9).ToString("[ d]").Dump(); // 22 - 31

