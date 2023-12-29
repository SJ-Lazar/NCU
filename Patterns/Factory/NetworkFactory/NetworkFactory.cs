using Patterns.Factory.NetworkUtility;

namespace Patterns.Factory.NetworkFactory;
public class NetworkFactory
{
    public INetwork GetNetworkInstance(string networkType)
    {
        return networkType switch
        {
            "Ping" => new Ping(),
            "DNS" => new DNS(),
            "ARP" => new ARP(),
            _ => throw new ArgumentException("Invalid network type."),
        };
    }
}
