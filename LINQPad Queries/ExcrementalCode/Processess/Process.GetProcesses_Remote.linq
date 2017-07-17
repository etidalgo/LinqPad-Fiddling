<Query Kind="Statements" />

var processes = Process.GetProcesses("etiapp");
foreach( var process in processes) {
    Console.WriteLine( process.ProcessName );
    // Console.WriteLine( process.StartTime );	// throw NotSupportedException for remote machine
}