namespace Chat
{
    partial class Authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnSignUP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ForgotPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(77, 117);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(133, 25);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Sign in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(77, 35);
            this.txtLogin.MaxLength = 32;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(133, 20);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.Click += new System.EventHandler(this.txtLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(77, 79);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(133, 20);
            this.txtPass.TabIndex = 2;
            this.txtPass.Click += new System.EventHandler(this.txtPass_Click);
            // 
            // btnSignUP
            // 
            this.btnSignUP.Location = new System.Drawing.Point(77, 148);
            this.btnSignUP.Name = "btnSignUP";
            this.btnSignUP.Size = new System.Drawing.Size(133, 25);
            this.btnSignUP.TabIndex = 3;
            this.btnSignUP.Text = "Sign UP";
            this.btnSignUP.UseVisualStyleBackColor = true;
            this.btnSignUP.Click += new System.EventHandler(this.btnSignUP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Put your login :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Put your password :";
            // 
            // ForgotPass
            // 
            this.ForgotPass.AutoSize = true;
            this.ForgotPass.ForeColor = System.Drawing.Color.Red;
            this.ForgotPass.Location = new System.Drawing.Point(85, 187);
            this.ForgotPass.Name = "ForgotPass";
            this.ForgotPass.Size = new System.Drawing.Size(114, 13);
            this.ForgotPass.TabIndex = 6;
            this.ForgotPass.Text = "Forgot your password?";
            this.ForgotPass.Click += new System.EventHandler(this.ForgotPass_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 209);
            this.Controls.Add(this.ForgotPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignUP);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.btnLogin);
            this.ForeColor = System.Drawing.Color.Blue;
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnSignUP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ForgotPass;
    }
}

