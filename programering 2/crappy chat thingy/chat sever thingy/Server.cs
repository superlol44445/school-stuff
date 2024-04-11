using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace message_sender_thingy
{
    internal class Server
    {
        public TcpListener Listener;
        static public List<ChatClient> Clients = new List<ChatClient>();
        public Server(int port) 
        {
            Listener = new TcpListener(IPAddress.Any,port);
        }
        void HandleAccept(IAsyncResult asyncResult)
        {
            TcpClient client = Listener.EndAcceptTcpClient(asyncResult);

            ChatClient cclient = new ChatClient(client);
            cclient.ReadHeader();

            var endpoint = client.Client.RemoteEndPoint as IPEndPoint;
            Console.WriteLine($"connection from {endpoint.Address}:{endpoint.Port}");

            accept();
        }
        void accept()
        {
            Listener.BeginAcceptTcpClient(HandleAccept, Listener);
        }
        public void run()
        {
            Listener.Start();
            accept();
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
