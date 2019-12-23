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
            //Arrange
            Client client = new Client();
            string msg = "Тест";
            //Action
            client.SendMsg(msg);
            ClientEventHandler clientEvent = new ClientEventHandler(client);
            //Assert
            Assert.AreEqual(clientEvent.serverMsg, "Test");
        }
    }
}
