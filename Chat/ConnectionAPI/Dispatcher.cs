﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public class Dispatcher
    {
        #region Singleton
        private static Dispatcher unique;
        private Content contentFromServer;

        public static Dispatcher GetInstance()
        {
            return unique ?? (unique = new Dispatcher());
        }

        #endregion

        public static MainWindow mainWindow;
        private CollectionOfDialogsView collectionOfDialogsView;
        private CollectionOfTabPages collectionOfTabPages;
        public static Authorization authorization;
        public static AdminSettings adminSetings;
        public static SignUP_Form signUP_Form;

        private Dispatcher()
        {
            collectionOfDialogsView = CollectionOfDialogsView.GetInstance();
            collectionOfTabPages = CollectionOfTabPages.GetInstance();
            contentFromServer = new Content();
        }

        public void OnMessageRecieved(string content)
        {
            contentFromServer = contentFromServer.SetContent(content);

            switch(contentFromServer.Action)
            {
                case "Authorization"   :  if (contentFromServer.Message == "True") ClientAPI.Ban = true;
                                          authorization.Authorized(contentFromServer.Name);                                                                     break;

                case "SignUP"          :  if (contentFromServer.Message == "Success") signUP_Form.Success(true);
                                          else if (contentFromServer.Message == "No success") signUP_Form.Success(false);                                       break;

                case "Invite"          :  mainWindow.CreateDialog(contentFromServer.NameDialog, false);                                                         break;

                case "SendMessage"     :  if(contentFromServer.Login!= ClientAPI.Login) mainWindow.NewMessage(contentFromServer.NameDialog);
                                          collectionOfDialogsView.GetMessage(contentFromServer.Login, contentFromServer.Message, contentFromServer.NameDialog); break;

                case "ShowOnlineUsers" :  var users = contentFromServer.Message.Split(';');
                                          mainWindow.ShowOnlineUsers(users);                                                                                    break;

                case "ShowAllDialogs"  :  var dialogs = contentFromServer.Message.Split(';'); mainWindow.ShowAllDialogs(dialogs);                               break;

                case "ShowBannedUsers" :  var bannedUsers = contentFromServer.Message.Split(';'); adminSetings.ShowUsers(bannedUsers);                          break;

                case "ShowAllUsersForAdmin": var allUsers = contentFromServer.Message.Split(';'); adminSetings.ShowUsers(allUsers);                             break;

                case "PrivatMessage"   :  if (collectionOfDialogsView.FindDialog(contentFromServer.NameDialog) == false)
                                          {
                                              mainWindow.CreateDialog(contentFromServer.NameDialog, true);
                                          }
                                          mainWindow.NewMessage(contentFromServer.NameDialog);
                                          collectionOfDialogsView.GetMessage(contentFromServer.Login, contentFromServer.Message, contentFromServer.NameDialog); break;

                case "Banned"          :  ClientAPI.Ban = true;                                                                                                 break;
                case "Unbaned"         :  ClientAPI.Ban = false;                                                                                                break;

                case "ChangePassword"  :  MessageBox.Show("Your password has been changed" , "Succes");                                                         break;

                default: break;
            }

        }

    }
}
