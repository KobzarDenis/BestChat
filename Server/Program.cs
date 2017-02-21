using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data.Common;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerAPI server = new ServerAPI();
            BannedUsers bu = new BannedUsers();
            RegistredUsers ru = new RegistredUsers();
            Dispatcher.banedUsers = bu;
            ClientComands.registredUsers = ru;
            ClientComands.banedUsers = bu;

            new Task(bu.AutomaticUnban).Start();

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
