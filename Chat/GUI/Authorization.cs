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
            Dispatcher.authorization = this;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtLogin.Text == "Put your login" )
            {
                MessageBox.Show("Please, put your natural login.", "Error!");
            }
            else
            {

                ServerCommands.Authorization(txtLogin.Text, txtPass.Text);
            }
        }

        public void Authorized(string name)
        {
            Invoke(new Action(() =>
            {
                 ClientAPI.Login = name;

                 switch (name)
                 {
                     case "admin": ClientAPI.Role = "admin"; Hide(); new MainWindow(this).Show(); break;
                     case "Not registred": MessageBox.Show("You are not registred this server", "Error"); break;
                     default: ClientAPI.Role = "user"; Hide(); new MainWindow(this).Show(); break;
                 }
            }));
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            new SignUP_Form().Show();
        }

        private void ForgotPass_Click(object sender, EventArgs e)
        {
            new ForgotPassword().Show();
        }
    }
}
