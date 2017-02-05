using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class BannedUsers
    {
        private static List<string> list = new List<string>();

        public static void Ban(string login, string time)
        {
            OnlineUsers.onlineUsers.First(u => u.login == login).Ban = true;

            string writePath = "BannedUsers.txt";

            StreamWriter write = new StreamWriter(writePath, true, Encoding.Default);
            //FileInfo file = new FileInfo(writePath);
           // write = file.AppendText();
            write.WriteLine(login + ":" + time);
            write.Close();

            ClientComands.Banned(OnlineUsers.onlineUsers.First(u => u.login == login));
        }

        public static void Start()
        {
            string readPath = "BannedUsers.txt";
            StreamReader read = new StreamReader(readPath, Encoding.Default);
            string line;
            while ((line = read.ReadLine()) != null)
            {
                list.Add(line);
            }
        }

        public static List<string> GetBannedList()
        {
            return list;
        }

        public static void Unban(string login)
        {
            string writePath = "BannedUsers.txt";

            StreamWriter write = new StreamWriter(writePath, false, Encoding.Default);
            //FileInfo file = new FileInfo(writePath);
           // write = file.AppendText();
            foreach(string users in list )
            {
                var parts = users.Split(':');
                if (parts[0] == login)
                {
                    list.Remove(users);
                    break;
                }
            }
            foreach (string users in list)
            {
                write.WriteLine(users);
            }
            write.Close();

            if(OnlineUsers.onlineUsers.Any(u=>u.login==login))
            ClientComands.Unbanned(OnlineUsers.onlineUsers.First(u => u.login == login));
        }

        public static bool FindUsers(string login)
        {
            foreach (string user in list)
            {
                var parts = user.Split(':');
                if (parts[0] == login)
                    return true;
            }
            return false;
        }
    }
}
