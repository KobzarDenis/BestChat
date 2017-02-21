using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WSS.AdminSettings;
using WSS.ConnectionAPI;

namespace WSS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BannedUsers bu = new BannedUsers();
            RegistredUsers ru = new RegistredUsers();
            Dispatcher.banedUsers = bu;
            ClientComands.registredUsers = ru;
            ClientComands.banedUsers = bu;
            new Task(bu.AutomaticUnban).Start();
        }
    }
}
