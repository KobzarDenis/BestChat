namespace Chat
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logOutExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myDialogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDialogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOnlineUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.tabC_Dialogs = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDialogs = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnToComeIn = new System.Windows.Forms.Button();
            this.lableMyName = new System.Windows.Forms.Label();
            this.btnPrivateMessage = new System.Windows.Forms.Button();
            this.btnAdminSettings = new System.Windows.Forms.Button();
            this.ChatMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatMenu
            // 
            this.ChatMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dialogsToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.ChatMenu.Location = new System.Drawing.Point(0, 0);
            this.ChatMenu.Name = "ChatMenu";
            this.ChatMenu.Size = new System.Drawing.Size(711, 24);
            this.ChatMenu.TabIndex = 1;
            this.ChatMenu.Text = "ChatMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDialogToolStripMenuItem,
            this.toolStripSeparator1,
            this.logOutExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveDialogToolStripMenuItem
            // 
            this.saveDialogToolStripMenuItem.Name = "saveDialogToolStripMenuItem";
            this.saveDialogToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveDialogToolStripMenuItem.Text = "Save dialog";
            this.saveDialogToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // logOutExitToolStripMenuItem
            // 
            this.logOutExitToolStripMenuItem.Name = "logOutExitToolStripMenuItem";
            this.logOutExitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.logOutExitToolStripMenuItem.Text = "Log Out/Exit";
            this.logOutExitToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // dialogsToolStripMenuItem
            // 
            this.dialogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDialogToolStripMenuItem,
            this.myDialogsToolStripMenuItem,
            this.allDialogsToolStripMenuItem});
            this.dialogsToolStripMenuItem.Name = "dialogsToolStripMenuItem";
            this.dialogsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.dialogsToolStripMenuItem.Text = "Dialogs";
            // 
            // createDialogToolStripMenuItem
            // 
            this.createDialogToolStripMenuItem.Name = "createDialogToolStripMenuItem";
            this.createDialogToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.createDialogToolStripMenuItem.Text = "CreateDialog";
            this.createDialogToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // myDialogsToolStripMenuItem
            // 
            this.myDialogsToolStripMenuItem.Name = "myDialogsToolStripMenuItem";
            this.myDialogsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.myDialogsToolStripMenuItem.Text = "My dialogs";
            this.myDialogsToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // allDialogsToolStripMenuItem
            // 
            this.allDialogsToolStripMenuItem.Name = "allDialogsToolStripMenuItem";
            this.allDialogsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.allDialogsToolStripMenuItem.Text = "All dialogs";
            this.allDialogsToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOnlineUsersToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // showOnlineUsersToolStripMenuItem
            // 
            this.showOnlineUsersToolStripMenuItem.Name = "showOnlineUsersToolStripMenuItem";
            this.showOnlineUsersToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.showOnlineUsersToolStripMenuItem.Text = "Show online users";
            this.showOnlineUsersToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(12, 49);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(191, 134);
            this.lbUsers.TabIndex = 2;
            // 
            // tabC_Dialogs
            // 
            this.tabC_Dialogs.Location = new System.Drawing.Point(210, 27);
            this.tabC_Dialogs.Name = "tabC_Dialogs";
            this.tabC_Dialogs.SelectedIndex = 0;
            this.tabC_Dialogs.Size = new System.Drawing.Size(500, 400);
            this.tabC_Dialogs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of users :";
            // 
            // lbDialogs
            // 
            this.lbDialogs.FormattingEnabled = true;
            this.lbDialogs.Location = new System.Drawing.Point(15, 264);
            this.lbDialogs.Name = "lbDialogs";
            this.lbDialogs.Size = new System.Drawing.Size(191, 134);
            this.lbDialogs.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "List of dialogs :";
            // 
            // btnInvite
            // 
            this.btnInvite.Location = new System.Drawing.Point(12, 189);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(90, 23);
            this.btnInvite.TabIndex = 6;
            this.btnInvite.Text = "Invite";
            this.btnInvite.UseVisualStyleBackColor = true;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // btnToComeIn
            // 
            this.btnToComeIn.Location = new System.Drawing.Point(12, 404);
            this.btnToComeIn.Name = "btnToComeIn";
            this.btnToComeIn.Size = new System.Drawing.Size(191, 23);
            this.btnToComeIn.TabIndex = 7;
            this.btnToComeIn.Text = "To come in";
            this.btnToComeIn.UseVisualStyleBackColor = true;
            this.btnToComeIn.Click += new System.EventHandler(this.btnToComeIn_Click);
            // 
            // lableMyName
            // 
            this.lableMyName.AutoSize = true;
            this.lableMyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lableMyName.Location = new System.Drawing.Point(563, 0);
            this.lableMyName.Name = "lableMyName";
            this.lableMyName.Size = new System.Drawing.Size(104, 17);
            this.lableMyName.TabIndex = 8;
            this.lableMyName.Text = "lableMyName";
            // 
            // btnPrivateMessage
            // 
            this.btnPrivateMessage.Location = new System.Drawing.Point(114, 189);
            this.btnPrivateMessage.Name = "btnPrivateMessage";
            this.btnPrivateMessage.Size = new System.Drawing.Size(90, 23);
            this.btnPrivateMessage.TabIndex = 9;
            this.btnPrivateMessage.Text = "Private";
            this.btnPrivateMessage.UseVisualStyleBackColor = true;
            this.btnPrivateMessage.Click += new System.EventHandler(this.btnPrivateMessage_Click);
            // 
            // btnAdminSettings
            // 
            this.btnAdminSettings.Location = new System.Drawing.Point(12, 218);
            this.btnAdminSettings.Name = "btnAdminSettings";
            this.btnAdminSettings.Size = new System.Drawing.Size(191, 23);
            this.btnAdminSettings.TabIndex = 10;
            this.btnAdminSettings.Text = "Admin setings";
            this.btnAdminSettings.UseVisualStyleBackColor = true;
            this.btnAdminSettings.Click += new System.EventHandler(this.btnAdminSettings_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 443);
            this.Controls.Add(this.btnAdminSettings);
            this.Controls.Add(this.btnPrivateMessage);
            this.Controls.Add(this.lableMyName);
            this.Controls.Add(this.btnToComeIn);
            this.Controls.Add(this.btnInvite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDialogs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.tabC_Dialogs);
            this.Controls.Add(this.ChatMenu);
            this.MainMenuStrip = this.ChatMenu;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ChatMenu.ResumeLayout(false);
            this.ChatMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip ChatMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDialogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dialogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myDialogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allDialogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.TabControl tabC_Dialogs;
        private System.Windows.Forms.ToolStripMenuItem createDialogToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbDialogs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnToComeIn;
        private System.Windows.Forms.ToolStripMenuItem showOnlineUsersToolStripMenuItem;
        private System.Windows.Forms.Label lableMyName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem logOutExitToolStripMenuItem;
        private System.Windows.Forms.Button btnPrivateMessage;
        private System.Windows.Forms.Button btnAdminSettings;
    }
}