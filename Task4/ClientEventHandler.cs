using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class ClientEventHandler
    {
        /// <summary>
        /// Client
        /// </summary>
        private Client client { get; set; }
        /// <summary>
        /// Message from server
        /// </summary>
        public string serverMsg { get; set; }
        /// <summary>
        /// array of russian letters
        /// </summary>
        string[] Rus = new string[] {"а", "б", "в","г","д","е","ё","ж","з","и","й","к","л","м","н","о","п",
                                     "р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я",
                                     "А", "Б", "В","Г","Д","Е","Ё","Ж","З","И","Й","К","Л","М","Н","О","П",
                                     "Р","С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","Ъ","Ы","Ь","Э","Ю","Я", " "};
        /// <summary>
        /// array of english letters
        /// </summary>
        string[] En = new string[] {"a", "b", "v","g","d","e","e","j","z","i","i","k","l","m","n","o","p",
                                    "r","s","t","u","f","h","c","ch","sh","sh'","","","","e","yu","ya",
                                    "A", "B", "V","G","D","E","E","J","Z","I","I","K","L","M","N","O","P",
                                    "R","S","T","U","F","H","C","CH","SH","SH'","","","","E","YU","YA", " "};
        /// <summary>
        /// Recoding russian letters to english
        /// </summary>
        /// <param name="client"></param>
        public void EventHandler(Client client)
        {
            client.MessageFromServer += delegate (string msg)
            {
                serverMsg = "";

                for (int i = 0; i < msg.Length; i++)
                {
                    for (int j = 0; j < Rus.Length; j++)
                    {
                        if (msg.Substring(i,1)==Rus[j])
                        {
                            serverMsg += En[j];
                        }
                    }
                }
            };
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        public ClientEventHandler(Client client)
        {
            this.client = client;
            EventHandler(client);
        }
    }
}
