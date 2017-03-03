<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.NetworkInformation.dll</Reference>
  <Namespace>System.Net.NetworkInformation</Namespace>
</Query>

void Main()
{
    string[] servers = { "localhost", "systweb", "bogusmachine" };
    servers.ToList().ForEach(server => PingServer(server));
}

// Define other methods and classes here
void PingServer(string machineName){
    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
        Ping ping = new Ping();
        Console.Write($"{machineName} ");
        PingReply pingReply = ping.Send(machineName); // get an exception unreachable machines

        if (pingReply.Status == IPStatus.Success) {
            Console.WriteLine("Pinged");
        } else {
            Console.WriteLine("Not pinged");
        }
    } else {
        Console.WriteLine("Network is not available");
    }
}
