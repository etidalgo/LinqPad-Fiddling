<Query Kind="Program" />

void Main()
{
	try{
		Console.Write(@"Ground. That's it. Ground. I wonder if it will be friendly-");
	}
	catch(Exception ex)
	{
		// 
		Exception alpha = ex;
		try {
		}
		// A local variable named 'ex' cannot be declared in this scope because it would give a different meaning to 'ex', which is already used in a 'parent or current' scope to denote something else
		// catch(Exception ex) 
		catch(Exception ex2) 
		{
			Exception alpha2 = ex2;
		}
	}
}

// Define other methods and classes here