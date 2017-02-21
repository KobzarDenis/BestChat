using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSS.ConnectionAPI;
using WSS.DialogsAPI;

//Обработчик на сервере для одного клиента, заносит его в список клиентов

namespace WSS
{
    public class MicrosoftWebSocket : WebSocketHandler // Стандартный класс с методами для обработки связи с клиентом
    {
        public override void OnMessage(string message) // Прием сообщения от клиента 
        {
            var client = OnlineUsers.onlineUsers.FirstOrDefault(u => u.client == this);
            Dispatcher.GetMessage(message, client);
        }

        public override void OnOpen() // Открытие соединения, действия при первом соединении
        {
            var client = new Client(this);
            OnlineUsers.onlineUsers.Add(client);
        }
    }
}