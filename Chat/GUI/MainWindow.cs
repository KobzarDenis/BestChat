using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class MainWindow : Form
    {
        CollectionOfDialogsView collectionOfDialogsView;
        CollectionOfTabPages collectionOfTabPages;
        AdminSettings adminSetings;
        Authorization authorization;

        bool LogOut = false;

        public static int newMessage = 1;

        public MainWindow(Authorization a)
        {
            DialogView.mainWindow = this;
            CreateMyDialog.mainWindow = this;
            Dispatcher.mainWindow = this;

            collectionOfDialogsView = CollectionOfDialogsView.GetInstance();
            collectionOfTabPages = CollectionOfTabPages.GetInstance();

            InitializeComponent();
            lableMyName.Text = ClientAPI.Login;

            if (ClientAPI.Role !="admin")
            {
                btnAdminSettings.Visible = false;
                btnAdminSettings.Enabled = false;
            }
            authorization = a;
        }

        private void MenuHandler(object sender, EventArgs e)
        {
            switch ((string)((ToolStripItem)sender).Text)
            {
                case "CreateDialog"      : if(ClientAPI.Ban==false) new CreateMyDialog().Show();                    
                                           else MessageBox.Show("You are banned from this server! Try again latter please!", "Error!");                            break;
                case "My dialogs"        : ShowMyDialogs();                                                                                                        break;
                case "All dialogs"       : RequestShowAllDialogs();                                                                                                break;
                case "Show online users" : RequestShowOnlineUsers();                                                                                               break;
                case "Log Out/Exit"      : ServerCommands.LogOut(ClientAPI.Login); Close(); LogOut = true;   authorization.Show();                                               break;
                case "Save dialog"       : collectionOfDialogsView.GetSelectedDialogView(tabC_Dialogs.SelectedTab.Text).SaveDialog(tabC_Dialogs.SelectedTab.Text); break;
                case "Change password"   : new ChangePassword().Show();                                                                                            break;

                default: break;
            }
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem != null && tabC_Dialogs.SelectedTab!=null && tabC_Dialogs.SelectedTab.Text!="")
            {
                ServerCommands.InviteToDialog(tabC_Dialogs.SelectedTab.Text, lbUsers.SelectedItem.ToString());
            }
        }

        private void btnToComeIn_Click(object sender, EventArgs e)
        {
            if (lbDialogs.SelectedItem != null)
            {
                ServerCommands.ToComeIn_TheDialog(lbDialogs.SelectedItem.ToString(), ClientAPI.Login);
                CreateDialogWhereImComeIn(lbDialogs.SelectedItem.ToString());
            }
        }

        #region Comand to create and close dialog

        public void CloseDialog(bool privateDialog)
        {
            if (privateDialog == false)
            {
                ServerCommands.CloseDialog(tabC_Dialogs.SelectedTab.Name, ClientAPI.Login);
            }
            collectionOfDialogsView.DeleteDialog(tabC_Dialogs.SelectedTab.Name);
            collectionOfTabPages.DeletePage(tabC_Dialogs.SelectedTab.Name);
            tabC_Dialogs.TabPages.Remove(tabC_Dialogs.SelectedTab);

        }

        public void CreateDialog(string name, bool pDialog)
        {
            Invoke(new Action(() =>
            {
                 TabPage tab = new TabPage();
                 tab.Text = name;
                 tab.Name = tab.Text;
                 
                 DialogView dialog = new DialogView();
                 dialog.privateDialog = pDialog;
                 tab.Controls.Add(dialog);
                 
                 collectionOfDialogsView.AddDialogView(tab.Text, dialog);
                 collectionOfTabPages.AddNewPage(tab);
                 
                 tabC_Dialogs.TabPages.Add(tab);
            }));
        }

        public void CreateDialogWhereImComeIn(string name)
        {
               TabPage tab = new TabPage();
               tab.Text = name;
               tab.Name = tab.Text;
              
               DialogView dialog = new DialogView();
               tab.Controls.Add(dialog);
              
               collectionOfDialogsView.AddDialogView(tab.Text, dialog);
               collectionOfTabPages.AddNewPage(tab);
              
               tabC_Dialogs.TabPages.Add(tab);
        }

        #endregion

        #region Comant to show dialogs or users

        private void ShowMyDialogs()
        {
            lbDialogs.Text = null;
            var myDialogs = collectionOfTabPages.GetMyDialogs();
            myDialogs.ForEach(dialogs => lbDialogs.Items.Add(dialogs.Name));
        }

        private void RequestShowAllDialogs()
        {
            ServerCommands.ShowAllDialogs(ClientAPI.Login);
        }

        private void RequestShowOnlineUsers()
        {
            ServerCommands.ShowOnlineUsers(ClientAPI.Login);
        }

        public void ShowAllDialogs(string[] allDialogs)
        {
            Invoke(new Action(() =>
            {
                lbDialogs.Items.Clear();
                for (int i = 0; i < allDialogs.Length; i++)
                {
                    lbDialogs.Items.Add(allDialogs[i]);
                }
            }));
        }

        public void ShowOnlineUsers(string[] onlineUsers)
        {
            Invoke(new Action(() =>
            {
                lbUsers.Items.Clear();
                for (int i = 0; i < onlineUsers.Length; i++)
                {
                    lbUsers.Items.Add(onlineUsers[i]);
                }
            }));
        }

        public void NewMessage(string name)
        {
            Invoke(new Action(() =>
            {
                foreach (TabPage page in collectionOfTabPages.GetMyDialogs())
                {
                    if (page.Name == name)
                    {
                        collectionOfDialogsView.GetSelectedDialogView(name).newMessage++;
                        page.Text = name +"(" + collectionOfDialogsView.GetSelectedDialogView(name).newMessage + ")";
                        return;
                    }
                }
            }));
        }

        #endregion

        #region For admin settings

        private void btnAdminSettings_Click(object sender, EventArgs e)
        {
                adminSetings = new AdminSettings();
                Dispatcher.adminSetings = adminSetings;
                adminSetings.Show();
        }

        #endregion

        private void btnPrivateMessage_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                CreateDialog(lbUsers.SelectedItem.ToString(), true);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!LogOut)
            {
                authorization.Close();
            }
        }
    }
}
