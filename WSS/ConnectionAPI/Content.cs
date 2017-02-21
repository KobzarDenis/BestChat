using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WSS.ConnectionAPI
{
    public class Content
    {
        public string Action { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string NameDialog { get; set; }
        public string Message { get; set; }

        public Content()
        {

        }

        public Content(string action, string login, string nameDialog, string message)
        {
            this.Action = action;
            this.Login = login;
            this.Role = "";
            this.NameDialog = nameDialog;
            this.Message = message;
        }

        public Content SetContent(string message)
        {
            return JsonConvert.DeserializeObject<Content>(message);
        }

        public string GetContent(Content content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
