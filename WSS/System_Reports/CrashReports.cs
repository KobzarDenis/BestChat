using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WSS
{
    public class CrashReports
    {
        public static void Add(string error, string method)
        {
            string writePath = AppDomain.CurrentDomain.BaseDirectory + "/Server Errors/CrashReports.txt";
            //string writePath = HttpContext.Current.Server.MapPath("/Server Errors/CrashReports.txt");

            StreamWriter write;
            FileInfo file = new FileInfo(writePath);
            write = file.AppendText();
            write.WriteLine(DateTime.Now + "     " + method + "     " + "{" + error + "}");
            write.Close();
        }
    }
}