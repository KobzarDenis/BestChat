using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSS.ConnectionAPI;

namespace WSS
{
    public class AuthorizationClient
    {
        #region Singleton
        private static AuthorizationClient unique;

        public static AuthorizationClient GetInstance()
        {
            return unique ?? (unique = new AuthorizationClient());
        }

        #endregion

        public static string Login { get; set; }
        public static string Role {get; set;}
        public static bool Ban { get; set; }

        private const int Port = 11111;

        private TcpClient client;
        private NetworkStream networkStream;


        public AuthorizationClient()
        {
            try
            {
               
                Init();
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

        public string Say(string message)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(networkStream);
                streamWriter.WriteLine(message);
                streamWriter.Flush();
                while (true)
                {
                    string sms = Listen();
                    if (sms != null && sms != "")
                        return sms;
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "AuthorizationClient - Say");
                return null;
            }
        }

        public string Listen()
        {
            try
            {
                StreamReader streamReader = new StreamReader(networkStream);
                while (true)
                {
                    if (networkStream.DataAvailable)
                    {
                        var message = streamReader.ReadLine();
                        if (message != null && message != "")
                        {
                            return message;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                CrashReports.Add(e.Message, "AuthorizationClient - Listen");
                return null;
            }
        }
    }
}
