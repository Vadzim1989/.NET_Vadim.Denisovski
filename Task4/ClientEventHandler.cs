using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class ClientEventHandler
    {
        private Client Client { get; set; }

        public string MessageFromServer { get; private set; }

        string[] Rus = {"а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н",
                        "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ь", "ы", "ъ",
                        "э", "ю", "я", " " };
        string[] En ={"a", "b", "v", "g", "d", "e", "e", "zh","z", "i", "y", "k", "l", "m","n",
                        "o", "p", "r", "s", "t", "u", "f", "kh","ts","ch","sh","sch","", "y", "",
                        "e", "ju","ja"," "};

        public void EventHandler(Client client)
        {
            client.MessageFromServer += delegate (string msg)
            {
                MessageFromServer = "";

                string msgLower = msg.ToLower();

                for (int i = 0; i < msgLower.Length; i++)
                {
                    for (int j = 0; j < Rus.Length; j++)
                    {
                        if (msgLower.Substring(i,1)==Rus[j])
                        {
                            MessageFromServer += En[j];
                        }
                    }
                }
            };
        }

        public ClientEventHandler(Client client)
        {
            Client = client;
            EventHandler(client);
        }
    }
}
