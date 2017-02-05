﻿using System;
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
    public partial class AdminSettings : Form
    {
        string users = "Select please All or Banned!";

        public AdminSettings()
        {
            InitializeComponent();
        }

        private void rbAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            users = "AllUsers";
        }

        private void rbBannedUsers_CheckedChanged(object sender, EventArgs e)
        {
            users = "BannedUsers";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (users == "BannedUsers")
                ServerCommands.ShowBannedUsers();
            else if (users == "AllUsers")
                ServerCommands.ShowAllUsersForAdmin();
            else
                lbBanUsers.Items.Add(users);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            ServerCommands.Ban(lbBanUsers.SelectedItem.ToString(), "Forever");
        }

        private void btnUnban_Click(object sender, EventArgs e)
        {
            ServerCommands.Unban(lbBanUsers.SelectedItem.ToString());
        }

        public void ShowUsers(string[] bannedUsers)
        {
            Invoke(new Action(() =>
            {
                lbBanUsers.Items.Clear();
                for (int i = 0; i < bannedUsers.Length; i++)
                {
                    lbBanUsers.Items.Add(bannedUsers[i]);
                }
            }));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
