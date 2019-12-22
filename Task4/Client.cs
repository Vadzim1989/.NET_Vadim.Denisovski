using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Task4
{
    public class Client
    {
        public int Port { get; private set; }

        public string HostName { get; private set; }

        private IPEndPoint tcpEndpoint;

        private Socket tcpSocket;

        public Client(int port = 1234, string hostName="127.0.0.1")
        {
            Port = port;
            HostName = hostName;
            tcpEndpoint = new IPEndPoint(IPAddress.Parse(hostName), port);
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public delegate void MessageFrom(string msg);
        public event MessageFrom MessageFromServer;

        public void Message(string msg)
        {
            var data = Encoding.UTF8.GetBytes(msg);
            tcpSocket.Connect(tcpEndpoint);
            tcpSocket.Send(data);
            byte[] receivedBytes = new byte[128];
            var size = 0;
            var serverAnswer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(receivedBytes);
                serverAnswer.Append(Encoding.UTF8.GetString(receivedBytes, 0, size));
            } while (tcpSocket.Available > 0);

            MessageFromServer?.Invoke(serverAnswer.ToString());
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
        }
    }
}
