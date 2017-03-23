using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class SignUP_Form : Form
    {
        public SignUP_Form()
        {
            InitializeComponent();
            Dispatcher.signUP_Form = this;
        }


        private void btnSignUP_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != "Put your login" && txtName.Text != "Put your name" && txtPass.Text != "Put your password" && txtLogin.Text != "" && txtName.Text != "" && txtPass.Text != "")
                ServerCommands.SingUP(txtName.Text, txtLogin.Text, txtPass.Text);
            else
                MessageBox.Show("Please put correct information in fields", "Error");
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }

        public void Success(bool go)
        {
            Invoke(new Action(() =>
            {
                if (go)
                {
                    lbMessage.Text = "Welcome to our chat!";
                    Thread.Sleep(3000);
                    Close();
                }
                else
                    lbMessage.Text = "Your name or login already exists";
                    lbMessage.BackColor = Color.Red;
            }));
        }
    }
}
