<Query Kind="Program">
  <RuntimeVersion>3.1</RuntimeVersion>
</Query>

void Main()
{
	var alpha = Status.Cool;
	var pass = alpha switch {
		Status.Hip or Status.Def or Status.Cool or Status.DownWithIt => true,
		_ => false
	};
	pass.Dump("pass");
}

// You can define other methods, fields, classes and namespaces here
public enum Status {
	Hip,
	Def,
	Cool,
	DownWithIt,
	Okay,
	Inbetween,
	Bland,
	Boring,
	Uptight,
	Square,
	WetBlanket,
	AnalRetentive
};
	
	