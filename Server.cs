using Netly;

public class Server
{
    public Server()
    {
        // TCP Echo raw data
        var tcpServerEcho = new TcpServer(messageFraming: true);
        tcpServerEcho.OnOpen(() => Console.WriteLine($"[TCP] ECHO SERVER STARTED AT: {tcpServerEcho.Host}"));
        tcpServerEcho.OnData((c, d) => c.ToData(d));

        // TCP Echo event data
        var tcpServerEchoEvent = new TcpServer(messageFraming: true);
        tcpServerEchoEvent.OnOpen(() => Console.WriteLine($"[TCP] ECHO EVENT SERVER STARTED AT: {tcpServerEchoEvent.Host}"));
        tcpServerEchoEvent.OnEvent((c, n, d) => c.ToEvent(n, d));

        // TCP Echo event data
        var udpServerEchoAny = new UdpServer();
        udpServerEchoAny.OnOpen(() => Console.WriteLine($"[UDP] ECHO EVENT SERVER STARTED AT: {udpServerEchoAny.Host}"));
        udpServerEchoAny.OnData((c, d) => c.ToData(d));
        udpServerEchoAny.OnEvent((c, n, d) => c.ToEvent(n, d));

        Console.WriteLine("SERVER STATED!");

        tcpServerEcho.Open(Endpoint.TcpData, 10);
        tcpServerEchoEvent.Open(Endpoint.TcpEvent, 10);
        udpServerEchoAny.Open(Endpoint.UdpAny);
    }
}