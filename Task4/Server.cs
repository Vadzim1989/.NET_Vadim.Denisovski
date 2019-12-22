using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Task4
{
    class Server
    {
        public delegate void MessageFrom(string msg);
        public event MessageFrom MessageFromClient;
        

        public int Port { get; private set; }

        public string HostName { get; private set; }

        private IPEndPoint tcpEndpoint;

        private Socket tcpSocket;

        public Server(int port = 1234, string hostName = "127.0.0.1")
        {
            Port = port;
            HostName = hostName;
            tcpEndpoint = new IPEndPoint(IPAddress.Parse(hostName), port);
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            tcpSocket.Bind(tcpEndpoint);
            tcpSocket.Listen(1);

            while(true)
            {
                Socket Listener = tcpSocket.Accept();
                byte[] receivedBytes = new byte[128];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = Listener.Receive(receivedBytes);
                    data.Append(Encoding.UTF8.GetString(receivedBytes, 0, size));
                } while (Listener.Available > 0);

                byte[] msg = Encoding.UTF8.GetBytes("Well Done");
                Listener.Send(msg);

                MessageFromClient?.Invoke(data.ToString());
                Listener.Shutdown(SocketShutdown.Both);
                Listener.Close();
            }
        }
    }
}
