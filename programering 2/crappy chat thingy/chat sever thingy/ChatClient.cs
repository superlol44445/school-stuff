using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace message_sender_thingy
{
    internal class ChatClient
    {
        public TcpClient client;
        private byte[] buffer;

        public ChatClient(TcpClient client)
        {
            this.client = client;
            this.buffer = new byte[1024];
        }

        public void ReadHeader()
        {
            var stream = client.GetStream();
            stream.BeginRead(buffer,0,1,HandleHeaderData,stream);
        }
        void HandleHeaderData(IAsyncResult ar)
        {
            var stream = client.GetStream();

            stream.EndRead(ar);
            var length = buffer[0];
            stream.BeginRead(buffer, 1, length, HanadleBodyData, stream);
        }
        void HanadleBodyData(IAsyncResult ar)
        {
            client.GetStream().EndRead(ar);

            var str = Encoding.UTF8.GetString(buffer, 1, buffer[0]);
            Console.WriteLine(str);

            foreach(var client in Server.Clients)
            {
                client.client.GetStream().Write(buffer, 0, buffer[0]);
            }

            ReadHeader();
        }
    }
}
