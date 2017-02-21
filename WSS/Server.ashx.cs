using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSS
{
    //Обработчик запросов на сервер 

    public class Server : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest || context.IsWebSocketRequestUpgrading) //Проверка на веб сокет соединение!
            {
                context.AcceptWebSocketRequest(new MicrosoftWebSocket());          //Передача управления в обработчик клиента
            }
        }

        public bool IsReusable => false;
    }
}