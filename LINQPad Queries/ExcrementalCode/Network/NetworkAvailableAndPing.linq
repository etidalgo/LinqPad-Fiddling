<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.NetworkInformation.dll</Reference>
  <Namespace>System.Net.NetworkInformation</Namespace>
</Query>

if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
	Ping ping = new Ping();
	PingReply pingReply = ping.Send("systwebogus");
	
	if (pingReply.Status == IPStatus.Success) { 
		Console.WriteLine("Pinged");
	} else {
		Console.WriteLine("Not pinged");
	}
} else {
	Console.WriteLine("Network is not available");
}