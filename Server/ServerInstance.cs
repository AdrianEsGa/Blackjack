using Server.Core;
using Shared;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Server;

internal class ServerInstance
{
    private static ServerInstance? _instance;

    private Engine _engine;

    private ServerInstance()
    {
        _engine = new Engine();
    }

    public static ServerInstance Build()
    {
        return _instance ?? new ServerInstance();
    }

    public void Start()
    {
        // Get Host IP Address that is used to establish a connection
        // In this case, we get one IP address of localhost that is IP : 127.0.0.1
        // If a host has multiple addresses, you will get a list of addresses
        IPHostEntry host = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = host.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        // Create a Socket that will use Tcp protocol
        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        // A Socket must be associated with an endpoint using the Bind method
        listener.Bind(localEndPoint);

        // Specify how many requests a Socket can listen before it gives Server busy response.
        // We will listen 10 requests at a time
        listener.Listen(10);

        Console.WriteLine($"Waiting for a connection on localhost:{localEndPoint.Port} ...");

        while (true)
        {
            Socket handler = listener.Accept();
            Console.WriteLine("Client connected.");

            // Handle the client connection in a separate task to keep the listener free
            Task.Run(() => HandleClient(handler));
        }
    }

    private void HandleClient(Socket handler)
    {
        // Incoming data from the client.
        string data = null;
        byte[] bytes = new byte[10240];

        while (true)
        {
            int bytesRec = handler.Receive(bytes);
            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

            if (data.IndexOf("<EOF>") > -1)
            {
                break;
            }
        }

        Console.WriteLine("Text received : {0}", data);

        var request = JsonSerializer.Deserialize<ClientRequest>(data.Replace("<EOF>", ""));

        var response = _engine.Receive(request!);

        byte[] msg = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(response));
        handler.Send(msg);

        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
        Console.WriteLine("Client disconnected.");
    }
}