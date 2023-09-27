using Netly.Core;

public static class Endpoint
{
    public static string IP { get; set; } = "127.0.0.1";
    public static Host TcpData => new Host(IP, 2000);
    public static Host TcpEvent => new Host(IP, 3000);
    public static Host UdpAny => new Host(IP, 4000);
}