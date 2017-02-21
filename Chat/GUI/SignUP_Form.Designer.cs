namespace Chat
{
    partial class SignUP_Form
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
            this.btnSignUP = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSignUP
            // 
            this.btnSignUP.Location = new System.Drawing.Point(57, 164);
            this.btnSignUP.Name = "btnSignUP";
            this.btnSignUP.Size = new System.Drawing.Size(173, 23);
            this.btnSignUP.TabIndex = 0;
            this.btnSignUP.Text = "SignUP";
            this.btnSignUP.UseVisualStyleBackColor = true;
            this.btnSignUP.Click += new System.EventHandler(this.btnSignUP_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(57, 44);
            this.txtName.MaxLength = 32;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(173, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Put your name";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(57, 79);
            this.txtLogin.MaxLength = 32;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(173, 20);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.Text = "Put your login";
            this.txtLogin.Click += new System.EventHandler(this.txtLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(57, 115);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(173, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.Text = "Put your password";
            this.txtPass.Click += new System.EventHandler(this.txtPass_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(57, 13);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 13);
            this.lbMessage.TabIndex = 4;
            // 
            // SignUP_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSignUP);
            this.Name = "SignUP_Form";
            this.Text = "SignUP_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignUP;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lbMessage;
    }
}