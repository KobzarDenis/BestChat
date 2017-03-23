using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WSS
{
    public class Log
    {
        public static void Add(string login, string action, string method)
        {
            string writePath = AppDomain.CurrentDomain.BaseDirectory + "/Server Errors/Logs.txt";
            //string writePath = HttpContext.Current.Server.MapPath("/Server Errors/Logs.txt");

            StreamWriter write;
            FileInfo file = new FileInfo(writePath);
            write = file.AppendText();
            write.WriteLine(DateTime.Now + "     [" + login + "] : " + method + "     " + action);
            write.Close();
        }
    }
}