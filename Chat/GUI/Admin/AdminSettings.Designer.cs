namespace Chat
{
    partial class AdminSettings
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
            this.btnBan = new System.Windows.Forms.Button();
            this.btnUnban = new System.Windows.Forms.Button();
            this.lbBanUsers = new System.Windows.Forms.ListBox();
            this.rbAllUsers = new System.Windows.Forms.RadioButton();
            this.rbBannedUsers = new System.Windows.Forms.RadioButton();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.cbTimeValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(12, 142);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(126, 23);
            this.btnBan.TabIndex = 0;
            this.btnBan.Text = "Ban";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // btnUnban
            // 
            this.btnUnban.Location = new System.Drawing.Point(221, 142);
            this.btnUnban.Name = "btnUnban";
            this.btnUnban.Size = new System.Drawing.Size(126, 23);
            this.btnUnban.TabIndex = 1;
            this.btnUnban.Text = "Unban";
            this.btnUnban.UseVisualStyleBackColor = true;
            this.btnUnban.Click += new System.EventHandler(this.btnUnban_Click);
            // 
            // lbBanUsers
            // 
            this.lbBanUsers.FormattingEnabled = true;
            this.lbBanUsers.Location = new System.Drawing.Point(12, 66);
            this.lbBanUsers.Name = "lbBanUsers";
            this.lbBanUsers.Size = new System.Drawing.Size(335, 43);
            this.lbBanUsers.TabIndex = 2;
            // 
            // rbAllUsers
            // 
            this.rbAllUsers.AutoSize = true;
            this.rbAllUsers.Location = new System.Drawing.Point(12, 12);
            this.rbAllUsers.Name = "rbAllUsers";
            this.rbAllUsers.Size = new System.Drawing.Size(64, 17);
            this.rbAllUsers.TabIndex = 3;
            this.rbAllUsers.TabStop = true;
            this.rbAllUsers.Text = "All users";
            this.rbAllUsers.UseVisualStyleBackColor = true;
            this.rbAllUsers.CheckedChanged += new System.EventHandler(this.rbAllUsers_CheckedChanged);
            // 
            // rbBannedUsers
            // 
            this.rbBannedUsers.AutoSize = true;
            this.rbBannedUsers.Location = new System.Drawing.Point(12, 35);
            this.rbBannedUsers.Name = "rbBannedUsers";
            this.rbBannedUsers.Size = new System.Drawing.Size(90, 17);
            this.rbBannedUsers.TabIndex = 4;
            this.rbBannedUsers.TabStop = true;
            this.rbBannedUsers.Text = "Banned users";
            this.rbBannedUsers.UseVisualStyleBackColor = true;
            this.rbBannedUsers.CheckedChanged += new System.EventHandler(this.rbBannedUsers_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(272, 12);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 40);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(273, 189);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(12, 113);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(38, 20);
            this.txtTime.TabIndex = 7;
            // 
            // cbTimeValue
            // 
            this.cbTimeValue.FormattingEnabled = true;
            this.cbTimeValue.Items.AddRange(new object[] {
            "minutes",
            "days",
            "weeks",
            "months",
            "years",
            "forever"});
            this.cbTimeValue.Location = new System.Drawing.Point(60, 112);
            this.cbTimeValue.Name = "cbTimeValue";
            this.cbTimeValue.Size = new System.Drawing.Size(78, 21);
            this.cbTimeValue.TabIndex = 8;
            // 
            // AdminSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 225);
            this.ControlBox = false;
            this.Controls.Add(this.cbTimeValue);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.rbBannedUsers);
            this.Controls.Add(this.rbAllUsers);
            this.Controls.Add(this.lbBanUsers);
            this.Controls.Add(this.btnUnban);
            this.Controls.Add(this.btnBan);
            this.Name = "AdminSettings";
            this.Text = "AdminSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.Button btnUnban;
        private System.Windows.Forms.ListBox lbBanUsers;
        private System.Windows.Forms.RadioButton rbAllUsers;
        private System.Windows.Forms.RadioButton rbBannedUsers;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.ComboBox cbTimeValue;
    }
}