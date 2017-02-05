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
    public partial class CreateMyDialog : Form
    {
        public static MainWindow mainWindow;

        public CreateMyDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mainWindow.CreateDialog(txtNameDialog.Text, false);
            ServerCommands.CreateDialog(ClientAPI.Login ,txtNameDialog.Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
