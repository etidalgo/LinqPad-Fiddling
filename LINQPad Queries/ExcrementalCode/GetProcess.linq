<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.dll</Reference>
  <Namespace>System.Diagnostics</Namespace>
</Query>

Process[] processes = Process.GetProcessesByName("ECargo.Workers.EventService");
foreach( Process process in processes) { Console.WriteLine(process.ProcessName); };
Console.WriteLine( Process.GetProcessesByName("ECargo.Workers.EventService")
                    .Any() );