using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Task4.Tests
{
    [TestClass]
    public class ClientMessageTest
    {
        [TestMethod]
        public void Send_Client_Message()
        {
            Client client = new Client();
            string msg = "Тест";
            client.Message(msg);
            ClientEventHandler clientEvent = new ClientEventHandler(client);          
            Assert.AreEqual(clientEvent.serverMsg, "Test");
        }

        [TestMethod]
        public void Server_Start()
        {
            Server server = new Server();
            server.Start();
            Client client = new Client();
        }
    }
}
