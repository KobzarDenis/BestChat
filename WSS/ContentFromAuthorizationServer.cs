using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSS
{
    public class ContentFromAuthorizationServer
    {

        public string Action { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ContentFromAuthorizationServer()
        {

        }

        public ContentFromAuthorizationServer(string action, string name, string login, string password)
        {
            this.Action = action;
            this.Name = name;
            this.Login = login;
            this.Password = password;
        }

        public ContentFromAuthorizationServer SetContent(string message)
        {
            return JsonConvert.DeserializeObject<ContentFromAuthorizationServer>(message);
        }

        public string GetContent(ContentFromAuthorizationServer content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}