using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Chat
{
    public partial class DialogView : UserControl
    {
        public string Key { get; set; }
        public bool privateDialog;

        public static MainWindow mainWindow;
        public List<string> messages;

        public int newMessage = 0;

        public DialogView()
        {
            InitializeComponent();
            messages = new List<string>();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                if (privateDialog == false)
                {
                    if (ClientAPI.Ban == false)
                    {
                        ServerCommands.SendMessage(Parent.Name, ClientAPI.Login, txtMessage.Text);
                        string str = "[" + ClientAPI.Login + "] : " + txtMessage.Text;
                        messages.Add(str);
                        lbMessages.Items.Add(str);
                    }
                    else
                        MessageBox.Show("You are banned from this server! Try again latter please!", "Error!");
                }
                else
                {
                    ServerCommands.SendPrivateMessage(Parent.Name, txtMessage.Text);
                    string str = "[" + ClientAPI.Login + "] : " + txtMessage.Text;
                    messages.Add(str);
                    lbMessages.Items.Add(str);
                }
                txtMessage.Clear();
                newMessage = 0;
            }
        }

        public void SetMessage(string loginSender, string message)
        {
            Invoke(new Action(() =>
            {
                string content = "[" + loginSender + "] : " + message;
                lbMessages.Items.Add(content);
                messages.Add(content); 
            }));
        }

        private void btnExitDialog_Click(object sender, EventArgs e)
        {
            mainWindow.CloseDialog(privateDialog);
        }

        public void SaveDialog(string nameDialog)
        {
            string writePath =@"Dialogs/"+ nameDialog + ".txt";

            StreamWriter write;
            FileInfo file = new FileInfo(writePath);
            write = file.AppendText();
            foreach (string message in messages)
            {
                write.WriteLine(message);
            }
            write.Close();
        }

        private void txtMessage_Click(object sender, EventArgs e)
        {
            Parent.Text = Parent.Name;
            txtMessage.Focus();
        }

    }
}
