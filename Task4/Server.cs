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
    /// A class describing a server for interacting with clients
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Delegate accepting any method 'void(string)
        /// </summary>
        /// <param name="msg"></param>
        public delegate void MessageFrom(string msg);
        /// <summary>
        /// Event to get message from client
        /// </summary>
        public event MessageFrom MessageFromClient;
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
        public Server(int port = 1234, string hostName = "127.0.0.1")
        {
            Port = port;
            HostName = hostName;
            tcpEndpoint = new IPEndPoint(IPAddress.Parse(hostName), port);
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        /// <summary>
        /// Get message from client
        /// </summary>
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
