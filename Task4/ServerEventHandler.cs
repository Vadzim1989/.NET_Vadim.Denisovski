using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class ServerEventHandler
    {
        /// <summary>
        /// Server
        /// </summary>
        private Server Server { get; set; }
        /// <summary>
        /// Client messages
        /// </summary>
        List<string> clientMsg = new List<string>();
        /// <summary>
        /// Add message
        /// </summary>
        /// <param name="server"></param>
        public void EventHandler(Server server)
        {
            server.MessageFromClient += delegate (string msg)
            {
                clientMsg.Add(msg);
            };
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="server"></param>
        public ServerEventHandler(Server server)
        {
            Server = server;
            EventHandler(server);
        }
    }
}
