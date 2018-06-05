<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

// DateTime.ToString Method (String) (System) <https://msdn.microsoft.com/en-us/library/zdtaw1bw(v=vs.110).aspx>
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Standard Date Time formats");
		DateTime dateValue = new DateTime(2008, 11, 5, 21, 15, 07);
		// Create an array of standard format strings.
		string[] standardFmts = {"d", "D", "f", "F", "g", "G", "m", "o", 
								 "R", "s", "t", "T", "u", "U", "y"};
		// Output date and time using each standard format string.
		CultureInfo ciNZ = new CultureInfo("en-NZ");
		int fieldWidth = 32; // alternate {0}: {1,35} | {2,35} | {3,35}"
		foreach (string standardFmt in standardFmts) {
			Console.WriteLine("{0}: {1} | {2} | {3}", standardFmt, 
							  dateValue.ToString(standardFmt).PadLeft(fieldWidth), 
							  dateValue.ToString(standardFmt, CultureInfo.InvariantCulture).PadLeft(fieldWidth), 
							  dateValue.ToString(standardFmt, ciNZ).PadLeft(fieldWidth));
		}
		Console.WriteLine();
		Console.WriteLine("Custom Date Time formats");

		DateTime updated = dateValue.AddMonths(1); // next month...
		
		// Create an array of some custom format strings. 
		string[] customFmts = {"h:mm:ss.ff t", "d MMM yyyy", "HH:mm:ss.f", 
							   "dd MMM HH:mm:ss", @"\Mon\t\h\: M", "HH:mm:ss.ffffzzz", 
							   "yyyyMMdd"};
		// Output date and time using each custom format string. 
		foreach (string customFmt in customFmts) {
			Console.WriteLine("{0}: {1}", customFmt.PadRight(20),
							  updated.ToString(customFmt));
		}
		
		DisplayInStandardCompanyFormat(dateValue);
	}
	
	public static void DisplayInStandardCompanyFormat(DateTime dateTime) {
		Console.WriteLine($"Standard Company Format: {dateTime:o}");
	
	}
}