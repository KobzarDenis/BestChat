using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        private const int Port = 5555;

        private TcpClient client;
        private NetworkStream networkStream;

        private Thread threadListen;

        public ClientAPI()
        {
            try
            {
                dispatcher = Dispatcher.GetInstance();
                Init();
                ThreadInit();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private void Init()
        {
            client = new TcpClient("localhost", Port);
            networkStream = client.GetStream();
        }

        private void ThreadInit()
        {
            threadListen = new Thread(new ThreadStart(Listen));
            threadListen.Start();
        }

        public void Say(string message)
        {
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(message);
            streamWriter.Flush();
        }

        public void Listen()
        {
            StreamReader streamReader = new StreamReader(networkStream);
            while (true)
            {
                if (networkStream.DataAvailable)
                {
                    var message = streamReader.ReadLine();
                    dispatcher.OnMessageRecieved(message);
                }
            }
        }
    }
}
