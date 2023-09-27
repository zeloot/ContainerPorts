using Netly;
using Netly.Core;

public class Client
{
	public static int DELAY = 3000;
	public Client()
	{
		// TCP Echo raw data
		var tcpClientEcho = new TcpClient(messageFraming: true);
		tcpClientEcho.OnClose(() => { Console.WriteLine("Data Client close"); });
		tcpClientEcho.OnError((e) => { Console.WriteLine($"Data Client error: {e}"); });
		tcpClientEcho.OnOpen(() =>
		{
			Console.WriteLine($"[TCP] ECHO Client STARTED AT: {tcpClientEcho.Host}");
			Task.Run(() =>
			{
				while (tcpClientEcho.IsOpened)
				{
					tcpClientEcho.ToData($"Sample DATA: {Guid.NewGuid()}");
					Thread.Sleep(DELAY);
				}
			});
		});

		tcpClientEcho.OnData((d) => Console.WriteLine($"TCP DATA: {NE.GetString(d)}"));

		// TCP Echo event data
		var tcpClientEchoEvent = new TcpClient(messageFraming: true);
		tcpClientEchoEvent.OnError((e) => { Console.WriteLine($"Event Client error: {e}"); });
		tcpClientEchoEvent.OnClose(() => { Console.WriteLine("Event tcp closed"); });


		tcpClientEchoEvent.OnOpen(() =>
		{
			Console.WriteLine($"[TCP] ECHO EVENT Client STARTED AT: {tcpClientEchoEvent.Host}");
			Task.Run(() =>
			{
				while (tcpClientEchoEvent.IsOpened)
				{
					tcpClientEchoEvent.ToEvent("test", $"Sample Event: {Guid.NewGuid()}");
					Thread.Sleep(DELAY);
				}
			});
		});

		tcpClientEchoEvent.OnEvent((n, d) => Console.WriteLine($"TCP EVENT ({n}): {NE.GetString(d)}"));

		// TCP Echo event data
		var udpClientEchoAny = new UdpClient();
		udpClientEchoAny.OnClose(() => { Console.WriteLine("Any UDP closed!"); });
		udpClientEchoAny.OnOpen(() =>
		{
			Console.WriteLine($"[UDP] ECHO EVENT Client STARTED AT: {udpClientEchoAny.Host}");
			Task.Run(() =>
			{
				while (udpClientEchoAny.IsOpened)
				{
					udpClientEchoAny.ToData($"UDP Sample DATA: {Guid.NewGuid()}");
					udpClientEchoAny.ToEvent("test", $"UDP Sample Event: {Guid.NewGuid()}");
					Thread.Sleep(DELAY);
				}
			});
		});
		udpClientEchoAny.OnData((d) => Console.WriteLine($"UDP DATA: {NE.GetString(d)}"));
		udpClientEchoAny.OnEvent((n, d) => Console.WriteLine($"UDP EVENT ({n}): {NE.GetString(d)}"));


		Console.WriteLine("CLIENT STATED!");

		tcpClientEcho.Open(Endpoint.TcpData);
		tcpClientEchoEvent.Open(Endpoint.TcpEvent);
		udpClientEchoAny.Open(Endpoint.UdpAny);
	}
}