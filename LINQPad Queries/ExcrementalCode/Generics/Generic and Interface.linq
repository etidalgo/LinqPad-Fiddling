<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.AspNetCore.App\5.0.0\Microsoft.Extensions.Logging.dll</Reference>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
</Query>

void Main()
{
	var loggerFactory = ( Microsoft.Extensions.Logging.ILoggerFactory)new LoggerFactory();
	loggerFactory.AddSerilog(serilogLogger);
	var logger = loggerFactory.CreateLogger<TCategoryName>();

	// var lambdaLogger = new LambdaLoggerWrapper
}

public class LambdaLoggerWrapper<T> : ILambdaLogger
    where T : class
{
    private T _logger { get; }
	private Action<T, string> _logAction { get; }
 
    public LambdaLoggerWrapper(T logger, Action<T, string>logAction)
    {
        this._logger = logger;
		this._logAction = logAction;
    }
 
    public void Log(string message) => this._logAction(this._logger, message);
 
    public void LogLine(string message) => this._logAction(this._logger, message);
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