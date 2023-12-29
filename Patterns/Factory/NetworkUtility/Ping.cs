namespace Patterns.Factory.NetworkUtility;

public class Ping : INetwork
{
    public void SendRequest(string ip, int timesSent) 
    {
        Console.WriteLine($"Ping request sent to {ip} {timesSent} times.");
    }
}

public class DNS : INetwork
{
    public void SendRequest(string ip, int timesSent)
    {
        Console.WriteLine($"DNS request sent to {ip} {timesSent} times.");
    }
}

public class ARP : INetwork
{
    public void SendRequest(string ip, int timesSent)
    {
        Console.WriteLine($"ARP request sent to {ip} {timesSent} times.");
    }
}

public interface INetwork
{
    void SendRequest(string ip, int timesSent);
}
