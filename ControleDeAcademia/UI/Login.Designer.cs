namespace ControleDeAcademia
{
    partial class loginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginScreen));
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbxSenha = new System.Windows.Forms.TextBox();
            this.tbxUsuario = new System.Windows.Forms.TextBox();
            this.chbxRememberMe = new System.Windows.Forms.CheckBox();
            this.lbForgetPassword = new System.Windows.Forms.Label();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbSenha = new System.Windows.Forms.Label();
            this.pbxSenha = new System.Windows.Forms.PictureBox();
            this.pbxUsuario = new System.Windows.Forms.PictureBox();
            this.pbxLoginScreen = new System.Windows.Forms.PictureBox();
            this.pbxBackground = new System.Windows.Forms.PictureBox();
            this.lbTitle1 = new System.Windows.Forms.Label();
            this.lbTitle2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoginScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Black;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(484, 192);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(290, 35);
            this.btnLogin.TabIndex = 18;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbxSenha
            // 
            this.tbxSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSenha.Location = new System.Drawing.Point(484, 81);
            this.tbxSenha.Multiline = true;
            this.tbxSenha.Name = "tbxSenha";
            this.tbxSenha.PasswordChar = '*';
            this.tbxSenha.Size = new System.Drawing.Size(290, 35);
            this.tbxSenha.TabIndex = 17;
            this.tbxSenha.Enter += new System.EventHandler(this.tbxSenha_Enter);
            this.tbxSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSenha_KeyDown);
            this.tbxSenha.Leave += new System.EventHandler(this.tbxSenha_Leave);
            // 
            // tbxUsuario
            // 
            this.tbxUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsuario.Location = new System.Drawing.Point(484, 12);
            this.tbxUsuario.Multiline = true;
            this.tbxUsuario.Name = "tbxUsuario";
            this.tbxUsuario.Size = new System.Drawing.Size(290, 35);
            this.tbxUsuario.TabIndex = 16;
            this.tbxUsuario.Enter += new System.EventHandler(this.tbxUsuario_Enter);
            this.tbxUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUsuario_KeyPress);
            this.tbxUsuario.Leave += new System.EventHandler(this.tbxUsuario_Leave);
            this.tbxUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.tbxID_Validating);
            // 
            // chbxRememberMe
            // 
            this.chbxRememberMe.AutoSize = true;
            this.chbxRememberMe.Location = new System.Drawing.Point(484, 133);
            this.chbxRememberMe.Name = "chbxRememberMe";
            this.chbxRememberMe.Size = new System.Drawing.Size(101, 17);
            this.chbxRememberMe.TabIndex = 19;
            this.chbxRememberMe.Text = "Lembrar usuario";
            this.chbxRememberMe.UseVisualStyleBackColor = true;
            // 
            // lbForgetPassword
            // 
            this.lbForgetPassword.AutoSize = true;
            this.lbForgetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbForgetPassword.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbForgetPassword.Location = new System.Drawing.Point(992, 700);
            this.lbForgetPassword.Name = "lbForgetPassword";
            this.lbForgetPassword.Size = new System.Drawing.Size(113, 13);
            this.lbForgetPassword.TabIndex = 20;
            this.lbForgetPassword.Text = "Esqueceu sua senha?";
            this.lbForgetPassword.Click += new System.EventHandler(this.lbForgetPassword_Click);
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbUsuario.ForeColor = System.Drawing.Color.DarkGray;
            this.lbUsuario.Location = new System.Drawing.Point(493, 19);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(43, 13);
            this.lbUsuario.TabIndex = 21;
            this.lbUsuario.Text = "Usuário";
            this.lbUsuario.UseMnemonic = false;
            this.lbUsuario.Click += new System.EventHandler(this.lbUsuario_Click);
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.ForeColor = System.Drawing.Color.DarkGray;
            this.lbSenha.Location = new System.Drawing.Point(493, 88);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(38, 13);
            this.lbSenha.TabIndex = 22;
            this.lbSenha.Text = "Senha";
            this.lbSenha.Click += new System.EventHandler(this.lbSenha_Click);
            // 
            // pbxSenha
            // 
            this.pbxSenha.Image = global::ControleDeAcademia.Properties.Resources.pbxSenha;
            this.pbxSenha.Location = new System.Drawing.Point(37, 186);
            this.pbxSenha.Name = "pbxSenha";
            this.pbxSenha.Size = new System.Drawing.Size(24, 24);
            this.pbxSenha.TabIndex = 25;
            this.pbxSenha.TabStop = false;
            // 
            // pbxUsuario
            // 
            this.pbxUsuario.Image = global::ControleDeAcademia.Properties.Resources.pbxUsuario;
            this.pbxUsuario.Location = new System.Drawing.Point(37, 156);
            this.pbxUsuario.Name = "pbxUsuario";
            this.pbxUsuario.Size = new System.Drawing.Size(24, 24);
            this.pbxUsuario.TabIndex = 24;
            this.pbxUsuario.TabStop = false;
            // 
            // pbxLoginScreen
            // 
            this.pbxLoginScreen.BackColor = System.Drawing.SystemColors.Control;
            this.pbxLoginScreen.Image = global::ControleDeAcademia.Properties.Resources.Login_Screen8;
            this.pbxLoginScreen.Location = new System.Drawing.Point(0, 0);
            this.pbxLoginScreen.Name = "pbxLoginScreen";
            this.pbxLoginScreen.Size = new System.Drawing.Size(460, 540);
            this.pbxLoginScreen.TabIndex = 23;
            this.pbxLoginScreen.TabStop = false;
            // 
            // pbxBackground
            // 
            this.pbxBackground.Image = global::ControleDeAcademia.Properties.Resources.Login_Background_Screen;
            this.pbxBackground.Location = new System.Drawing.Point(0, 0);
            this.pbxBackground.Name = "pbxBackground";
            this.pbxBackground.Size = new System.Drawing.Size(1920, 1080);
            this.pbxBackground.TabIndex = 14;
            this.pbxBackground.TabStop = false;
            // 
            // lbTitle1
            // 
            this.lbTitle1.AutoSize = true;
            this.lbTitle1.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle1.Font = new System.Drawing.Font("Neuropolitical Rg", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle1.ForeColor = System.Drawing.Color.White;
            this.lbTitle1.Location = new System.Drawing.Point(30, 41);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Size = new System.Drawing.Size(260, 38);
            this.lbTitle1.TabIndex = 26;
            this.lbTitle1.Text = "Controle de";
            // 
            // lbTitle2
            // 
            this.lbTitle2.AutoSize = true;
            this.lbTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle2.Font = new System.Drawing.Font("AR DESTINE", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle2.ForeColor = System.Drawing.Color.White;
            this.lbTitle2.Location = new System.Drawing.Point(176, 71);
            this.lbTitle2.Name = "lbTitle2";
            this.lbTitle2.Size = new System.Drawing.Size(256, 63);
            this.lbTitle2.TabIndex = 27;
            this.lbTitle2.Text = "Academia";
            // 
            // loginScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Controls.Add(this.lbTitle2);
            this.Controls.Add(this.lbTitle1);
            this.Controls.Add(this.pbxSenha);
            this.Controls.Add(this.pbxUsuario);
            this.Controls.Add(this.pbxLoginScreen);
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.lbForgetPassword);
            this.Controls.Add(this.chbxRememberMe);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxSenha);
            this.Controls.Add(this.tbxUsuario);
            this.Controls.Add(this.pbxBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "loginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Academia - Versão: 01.01.001";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.loginScreen_FormClosed);
            this.Shown += new System.EventHandler(this.loginScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoginScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxBackground;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbxSenha;
        private System.Windows.Forms.TextBox tbxUsuario;
        private System.Windows.Forms.CheckBox chbxRememberMe;
        private System.Windows.Forms.Label lbForgetPassword;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbSenha;
        private System.Windows.Forms.PictureBox pbxLoginScreen;
        private System.Windows.Forms.PictureBox pbxUsuario;
        private System.Windows.Forms.PictureBox pbxSenha;
        private System.Windows.Forms.Label lbTitle1;
        private System.Windows.Forms.Label lbTitle2;
    }
}