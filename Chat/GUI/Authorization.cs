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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            ServerCommands.me = ClientAPI.GetInstance();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (txtLogin.Text)
            {
                case "admin": ClientAPI.Login = txtLogin.Text; ClientAPI.Role = "admin"; break;
                default     : ClientAPI.Login = txtLogin.Text; ClientAPI.Role = "user";  break;
            }
            ServerCommands.Authorization(txtLogin.Text);
            new MainWindow().Show();
            Hide();
        }
    }
}
