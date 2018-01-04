<Query Kind="Program" />

/* 
c# - What really happens in a try { return x; } finally { x = null; } statement? - Stack Overflow <https://stackoverflow.com/questions/421797/what-really-happens-in-a-try-return-x-finally-x-null-statement>
The finally statement is executed, but the return value isn't affected. The execution order is:
	Code before return statement is executed
	Expression in return statement is evaluated
	finally block is executed
	Result evaluated in step 2 is returned
*/
	static string x;

    static void Main()
    {
        Console.WriteLine($"Returned: {Method()}");
        Console.WriteLine($"x: {x}");
    }

    static string Method()
    {
        try
        {
            x = "try";
            return x;
        }
        finally
        {
            x = "finally";
        }
    }