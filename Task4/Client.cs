using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Task4
{
    /// <summary>
    /// A class describing a client for interacting with server
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Get the connection port
        /// </summary>
        public int Port { get; private set; }
        /// <summary>
        /// Get the name of the host
        /// </summary>
        public string HostName { get; private set; }
        /// <summary>
        /// Information about network interface
        /// </summary>
        private IPEndPoint tcpEndpoint;
        /// <summary>
        /// Listen for connection requests
        /// </summary>
        private Socket tcpSocket;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port"></param>
        /// <param name="hostName"></param>
        public Client(int port = 1234, string hostName="127.0.0.1")
        {
            Port = port;
            HostName = hostName;
            tcpEndpoint = new IPEndPoint(IPAddress.Parse(hostName), port);
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        /// <summary>
        /// Delegate accepting any method 'void(string)
        /// </summary>
        /// <param name="msg"></param>
        public delegate void MessageFrom(string msg);
        /// <summary>
        /// Event to get message from server
        /// </summary>
        public event MessageFrom MessageFromServer;
        /// <summary>
        /// Connect with server. Send/Get message
        /// </summary>
        /// <param name="msg"></param>
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
