using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WSS.ConnectionAPI
{
    public class Client
    {
        public string login;
        public string role;
        public string name;
        public bool Ban = false;

        public MicrosoftWebSocket client;

        public Client(MicrosoftWebSocket client)
        {
            this.client = client;
        }
    }
}
