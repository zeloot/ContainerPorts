using Netly;
using Netly.Core;


if (args == null || args.Length <= 0)
{
    Console.WriteLine("Entry point not fount: add dotnet run --client/--server");
    Console.ReadLine();
    return;
}

if (args[0] == "--client")
{
    new Client();
}
else if (args[0] == "--server")
{
    var s = new Server();
}
else
{
    Console.WriteLine("Invalid entry point: add dotnet run --client/--server");
}


Console.WriteLine("[Manual]\nq: Quit");
while (true)
{
    var line = Console.ReadLine();

    if(line != "q")
    {
        Console.WriteLine("Invalid input.\nq: Quit");
    }
    else
    {
        break;
    }
}