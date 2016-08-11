<Query Kind="Program">
  <Reference>C:\Users\ernest\eCargo\Tasks\EC-619 Migrate Dashboard\Dashboard\bin\Humanizer.dll</Reference>
  <Namespace>Humanizer</Namespace>
  <Namespace>System</Namespace>
</Query>


public class Program
{
	public static Tuple<string, string> DoSomething( int value ) {
		return new Tuple<string,string>(value.ToString(), value.ToWords());
	}
	
	public static void Main()
	{
		Console.WriteLine( DoSomething(43).ToString() );
	}
}