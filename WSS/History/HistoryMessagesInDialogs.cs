using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WSS.History
{
    class HistoryMessagesInDialogs
    {
        public static void SaveHistory(string login, string nameDialog, string message)
        {
            string writePath = HttpContext.Current.Server.MapPath("/Dialogs/"+ nameDialog + ".txt");

            StreamWriter write;
            FileInfo file = new FileInfo(writePath);
            write = file.AppendText();
            write.WriteLine("[" + login + "] : " + message);
            write.WriteLine(DateTime.Now);
            write.Close();
        }
    }
}
