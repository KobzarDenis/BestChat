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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
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
            this.button1 = new System.Windows.Forms.Button();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChatMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatMenu
            // 
            this.ChatMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dialogsToolStripMenuItem,
            this.usersToolStripMenuItem});
            resources.ApplyResources(this.ChatMenu, "ChatMenu");
            this.ChatMenu.Name = "ChatMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDialogToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.logOutExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveDialogToolStripMenuItem
            // 
            this.saveDialogToolStripMenuItem.Name = "saveDialogToolStripMenuItem";
            resources.ApplyResources(this.saveDialogToolStripMenuItem, "saveDialogToolStripMenuItem");
            this.saveDialogToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // logOutExitToolStripMenuItem
            // 
            this.logOutExitToolStripMenuItem.Name = "logOutExitToolStripMenuItem";
            resources.ApplyResources(this.logOutExitToolStripMenuItem, "logOutExitToolStripMenuItem");
            this.logOutExitToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // dialogsToolStripMenuItem
            // 
            this.dialogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDialogToolStripMenuItem,
            this.myDialogsToolStripMenuItem,
            this.allDialogsToolStripMenuItem});
            this.dialogsToolStripMenuItem.Name = "dialogsToolStripMenuItem";
            resources.ApplyResources(this.dialogsToolStripMenuItem, "dialogsToolStripMenuItem");
            // 
            // createDialogToolStripMenuItem
            // 
            this.createDialogToolStripMenuItem.Name = "createDialogToolStripMenuItem";
            resources.ApplyResources(this.createDialogToolStripMenuItem, "createDialogToolStripMenuItem");
            this.createDialogToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // myDialogsToolStripMenuItem
            // 
            this.myDialogsToolStripMenuItem.Name = "myDialogsToolStripMenuItem";
            resources.ApplyResources(this.myDialogsToolStripMenuItem, "myDialogsToolStripMenuItem");
            this.myDialogsToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // allDialogsToolStripMenuItem
            // 
            this.allDialogsToolStripMenuItem.Name = "allDialogsToolStripMenuItem";
            resources.ApplyResources(this.allDialogsToolStripMenuItem, "allDialogsToolStripMenuItem");
            this.allDialogsToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOnlineUsersToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            resources.ApplyResources(this.usersToolStripMenuItem, "usersToolStripMenuItem");
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // showOnlineUsersToolStripMenuItem
            // 
            this.showOnlineUsersToolStripMenuItem.Name = "showOnlineUsersToolStripMenuItem";
            resources.ApplyResources(this.showOnlineUsersToolStripMenuItem, "showOnlineUsersToolStripMenuItem");
            this.showOnlineUsersToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            resources.ApplyResources(this.lbUsers, "lbUsers");
            this.lbUsers.Name = "lbUsers";
            // 
            // tabC_Dialogs
            // 
            resources.ApplyResources(this.tabC_Dialogs, "tabC_Dialogs");
            this.tabC_Dialogs.Name = "tabC_Dialogs";
            this.tabC_Dialogs.SelectedIndex = 0;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbDialogs
            // 
            this.lbDialogs.FormattingEnabled = true;
            resources.ApplyResources(this.lbDialogs, "lbDialogs");
            this.lbDialogs.Name = "lbDialogs";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnInvite
            // 
            resources.ApplyResources(this.btnInvite, "btnInvite");
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.UseVisualStyleBackColor = true;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // btnToComeIn
            // 
            resources.ApplyResources(this.btnToComeIn, "btnToComeIn");
            this.btnToComeIn.Name = "btnToComeIn";
            this.btnToComeIn.UseVisualStyleBackColor = true;
            this.btnToComeIn.Click += new System.EventHandler(this.btnToComeIn_Click);
            // 
            // lableMyName
            // 
            resources.ApplyResources(this.lableMyName, "lableMyName");
            this.lableMyName.Name = "lableMyName";
            // 
            // btnPrivateMessage
            // 
            resources.ApplyResources(this.btnPrivateMessage, "btnPrivateMessage");
            this.btnPrivateMessage.Name = "btnPrivateMessage";
            this.btnPrivateMessage.UseVisualStyleBackColor = true;
            this.btnPrivateMessage.Click += new System.EventHandler(this.btnPrivateMessage_Click);
            // 
            // btnAdminSettings
            // 
            resources.ApplyResources(this.btnAdminSettings, "btnAdminSettings");
            this.btnAdminSettings.Name = "btnAdminSettings";
            this.btnAdminSettings.UseVisualStyleBackColor = true;
            this.btnAdminSettings.Click += new System.EventHandler(this.btnAdminSettings_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            resources.ApplyResources(this.changePasswordToolStripMenuItem, "changePasswordToolStripMenuItem");
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.MenuHandler);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}