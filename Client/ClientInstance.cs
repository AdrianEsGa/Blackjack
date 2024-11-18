using Shared;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Client;

internal class ClientInstance
{
    public static ServerResponse Send(ClientRequest request)
    {
        byte[] bytes = new byte[10204];
        string response = string.Empty;

        try
        {
            // Connect to a Remote server
            // Get Host IP Address that is used to establish a connection
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1
            // If a host has multiple addresses, you will get a list of addresses
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP  socket.
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.

            // Connect to Remote EndPoint
            sender.Connect(remoteEP);

            Debug.WriteLine("Socket connected to {0}",
                sender.RemoteEndPoint.ToString());


            // Encode the data string into a byte array.
            byte[] msg = Encoding.ASCII.GetBytes($"{JsonSerializer.Serialize(request)}<EOF>");

            // Send the data through the socket.
            int bytesSent = sender.Send(msg);

            // Receive the response from the remote device.
            int bytesRec = sender.Receive(bytes);

            response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            Debug.WriteLine("Echoed test = {0}", response);

            // Release the socket.
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

        }
        catch (Exception e)
        {
            Debug.WriteLine(e.ToString());
            return ServerResponse.Failed(request.RequestId, e.Message);
        }

        return JsonSerializer.Deserialize<ServerResponse>(response)!;
    }

}
