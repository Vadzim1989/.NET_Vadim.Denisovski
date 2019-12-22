using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class ServerEventHandler
    {
        private Server Server { get; set; }

        List<string> clientMsg = new List<string>();

        public void EventHandler(Server server)
        {
            server.MessageFromClient += delegate (string msg)
            {
                clientMsg.Add(msg);
            };
        }

        public ServerEventHandler(Server server)
        {
            Server = server;
            EventHandler(server);
        }
    }
}
