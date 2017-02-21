using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WSS.AdminSettings;
using WSS.DialogsAPI;
using WSS.History;

namespace WSS.ConnectionAPI
{
    class Dispatcher
    {

        private static object block = new object();
        static Content contentFromClient;
        public static BannedUsers banedUsers;
        public Dispatcher()
        {

        }

        public static void GetMessage(string content, Client client)
        {
            contentFromClient = new Content();
            contentFromClient = contentFromClient.SetContent(content);

            switch (contentFromClient.Action)
            {
                case "Authorization"    :     client.login = contentFromClient.Login;
                                              client.role = contentFromClient.Role;
                                              ClientComands.Authorization(contentFromClient.Login, contentFromClient.NameDialog, client);                             break;

                case "SignUP":                ClientComands.SignUP(contentFromClient.Login, contentFromClient.NameDialog, contentFromClient.Message, client);         break;

                case "Invite"           :     ClientComands.InviteToDialog(contentFromClient.Login, contentFromClient.NameDialog);                                    break;

                case "SendMessage"      :     ClientComands.NewMessage(contentFromClient.NameDialog, contentFromClient.Message, contentFromClient.Login);
                                              HistoryMessagesInDialogs.SaveHistory(contentFromClient.Login, contentFromClient.NameDialog, contentFromClient.Message); break;

                case "CloseDialog"      :     ListOfDialogs.ExitDialog(contentFromClient.Login, contentFromClient.NameDialog);                                        break;

                case "ToComeIn"         :     ListOfDialogs.ToComeIn(contentFromClient.Login, contentFromClient.NameDialog);                                          break;   
                                                                                
                case "ShowAllDialogs"   :     ClientComands.ShowAllDialogs(client);                                                                                   break;

                case "ShowOnlineUsers"  :     ClientComands.ShowOnlineUsers(client);                                                                                  break;

                case "CreateDialog"     :     ListOfDialogs.AddDialogToList(contentFromClient.NameDialog, client);                                                    break;

                case "LogOut"           :     ClientComands.LogOut(contentFromClient.Login);                                                                          break;

                case "ShowBannedUsers"  :     if(contentFromClient.Login=="admin") ClientComands.ShowBannedUsers(client);                                             break;

                case "ShowAllUsersForAdmin":  ClientComands.ShowAllUsersForAdmin(client);                                                                             break;

                case "BanUser"          :     banedUsers.Ban(contentFromClient.Login, contentFromClient.Message);                                                     break;

                case "UnbanUser"        :     banedUsers.Unban(contentFromClient.Login);                                                                              break;

                case "PrivatMessage"    :     ClientComands.PrivatMessage(contentFromClient.Login, contentFromClient.NameDialog, contentFromClient.Message);          break;

                    

                default: break;
            }

            contentFromClient = null;
        }
    }
}
