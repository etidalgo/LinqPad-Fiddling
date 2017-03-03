<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.NetworkInformation.dll</Reference>
  <Namespace>System.Net.NetworkInformation</Namespace>
</Query>

Process.GetProcesses("ECARGOERNESTDEV");
Process.GetProcesses("SystApp.chhnet.net");
Process.GetProcesses("SystData.chhnet.net");
Process.GetProcesses("SystData");

if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
    Ping ping = new Ping();
    PingReply pingReply = ping.Send("systweb");

    if (pingReply.Status == IPStatus.Success) {
        Console.WriteLine("Pinged");
    } else {
        Console.WriteLine("Not pinged");
    }
} else {
    Console.WriteLine("Network is not available");
}
