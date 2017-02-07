using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerAPI server = new ServerAPI();
            BannedUsers bu = new BannedUsers();
            Dispatcher.banedUsers = bu;
            ClientComands.banedUsers = bu;

            new Task(bu.AutomaticUnban).Start();

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
