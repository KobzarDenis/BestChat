using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace Chat
{
    public class ClientAPI
    {
        #region Singleton
        private static ClientAPI unique;

        public static ClientAPI GetInstance()
        {
            return unique ?? (unique = new ClientAPI());
        }

        #endregion

        public static string Login { get; set; }
        public static string Role {get; set;}
        public static bool Ban { get; set; }

        Dispatcher dispatcher;
        private readonly string socketUrl = ConfigurationManager.AppSettings["wssUrl"];

        private WebSocket webSocketClient; // Обьявление веб сокет клиента

        private ClientAPI()
        {
            try
            {
                dispatcher = Dispatcher.GetInstance();
                Init();
            }
            catch (Exception e)
            {
                MessageBox.Show("Server is not avaliable now", "Sorry");
                //throw e.InnerException;
            }
        }

        private void Init()
        {
            webSocketClient = new WebSocket(socketUrl);            //Инициализация веб сокет клиента 
            webSocketClient.Open();                                //Открытие соединения
            webSocketClient.MessageReceived += OnMessageReceived;  //Присваивание обрабочика для приема смс
        }

        public void Say(string message)
        {
            webSocketClient.Send(message);        // отправка сообщения на сервер
        }

        public void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            dispatcher.OnMessageRecieved(e.Message);
        }
    }
}
