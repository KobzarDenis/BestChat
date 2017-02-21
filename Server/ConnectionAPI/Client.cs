using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Client
    {
        public string login;
        public string role;
        public string name;
        public bool Ban = false;

        public TcpClient client;

        public Client(TcpClient client)
        {
            this.client = client;
        }
    }
}
