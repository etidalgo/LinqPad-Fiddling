<Query Kind="Statements" />

            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                Console.WriteLine(z.Id);