using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Dialog
    {
        public string NameDialog { get; set; }
        public bool PrivatDialog { get; set; }
        public List<Client> dialog;
        public List<string> messages; 

        public Dialog()
        {
            this.dialog = new List<Client>();
            this.messages = new List<string>();
        }

        public void DeleteInDialog(string login)
        {
            dialog.Remove(dialog.FirstOrDefault(c =>c.login == login));
        }

        public void AddToDialog(string login)
        {
            dialog.Add(OnlineUsers.onlineUsers.FirstOrDefault(c=>c.login==login));
        }
    }
}
