<Query Kind="Program" />

void Main()
{
	
}

// You can define other methods, fields, classes and namespaces here
    //
    // Summary:
    //     Lambda runtime logger.
    public interface ILambdaLogger
    {
        //
        // Summary:
        //     Logs a message to AWS CloudWatch Logs. Logging will not be done: If the role
        //     provided to the function does not have sufficient permissions.
        //
        // Parameters:
        //   message:
        void Log(string message);
        //
        // Summary:
        //     Logs a message, followed by the current line terminator, to AWS CloudWatch Logs.
        //     Logging will not be done: If the role provided to the function does not have
        //     sufficient permissions.
        //
        // Parameters:
        //   message:
        void LogLine(string message);
    }