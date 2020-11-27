<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.AspNetCore.App\5.0.0\Microsoft.Extensions.Logging.Abstractions.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.AspNetCore.App\5.0.0\Microsoft.Extensions.Logging.dll</Reference>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
</Query>

void Main()
{
	var logger = new SimpleLogger();
	
	var lambdaLogger = new LambdaLoggerWrapper<SimpleLogger>(logger, (lgr, txt) => { lgr.DumpToConsole(txt); });
	
	lambdaLogger.Log("Holy carp");
	lambdaLogger.LogLine("Too many levels of indirection");
}

public class SimpleLogger{
	public void DumpToConsole(string text) => Console.WriteLine(text);
}

public class LambdaLoggerWrapper<T> : ILambdaLogger
    where T : class
{
    private T _logger { get; }
	private Action<T, string> _logAction { get; }
	private Action<T, string> _logLineAction { get; }
 
    public LambdaLoggerWrapper(T logger, Action<T, string>logAction)
    {
        this._logger = logger;
		this._logAction = logAction;
		this._logLineAction = logAction;
    }

    public LambdaLoggerWrapper(T logger, Action<T, string>logAction, Action<T, string>logLineAction)
    {
        this._logger = logger;
		this._logAction = logAction;
		this._logLineAction = logLineAction;
    }
	
    public void Log(string message) => this._logAction(this._logger, message);
 
    public void LogLine(string message) => this._logLineAction(this._logger, message);
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