using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcademia{
    public partial class loginScreen : Form{
        //Atributos
        private ConnectionDataBase conexao = new ConnectionDataBase();
        private bool autorizado = false;
        private Usuario usuario;
        private int widthScreen = Screen.PrimaryScreen.Bounds.Width;
        private int heightScreen = Screen.PrimaryScreen.Bounds.Height;

        //Construtor
        public loginScreen(){
            InitializeComponent();
        }

        //Metodos
        private void localizaUsuario(string id){
            if (!String.IsNullOrEmpty(id)){ 
                try {
                    conexao.closeConnection();
                    conexao.openConnection();

                    MySqlDataReader results = conexao.query("Select * from cadastrosusuarios where deleted = 0 and id = '" + id + "'");

                    if (results.Read()){
                        usuario = new Usuario(results.GetInt32(0), results.GetDateTime(1), results.GetDateTime(2), results.GetInt32(3), results.GetString(4), results.GetString(5), results.GetInt32(6));
                    } else {
                        MessageBox.Show("Usuario não encontrado.");
                    }
                } catch {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                }
            }
            conexao.closeConnection();
        }

        private void conferirSenha(){
            if (tbxSenha.Text == usuario.Senha){
                autorizado = true;
                btnLogin.Text = "";

                try {
                    conexao.openConnection();

                    MySqlDataReader results = conexao.query("Select * from settings where field = 'RememberUser'");

                    if (results.Read()){
                        try{
                            conexao.closeConnection();
                            conexao.openConnection();
                            conexao.query("Update settings Set value = '" + chbxRememberMe.Checked.ToString() + "' where field = 'RememberUser'");
                        } catch {
                            MessageBox.Show("Não foi possível conectar-se ao banco de dados.2");
                        }
                    } else {
                        try {
                            conexao.closeConnection();
                            conexao.openConnection();
                            conexao.query("INSERT INTO settings(field, value) values('RememberUser', '" + chbxRememberMe.Checked.ToString() + "')");
                        } catch (MySqlException ex) {
                            MessageBox.Show("Não foi possível conectar-se ao banco de dados.3" + ex.Message);
                        }
                    }
                } catch {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.1");
                }
                conexao.closeConnection();

                try {
                    conexao.openConnection();

                    MySqlDataReader results = conexao.query("Select * from settings where field = 'User'");

                    if (results.Read()){
                        try{
                            conexao.closeConnection();
                            conexao.openConnection();
                            conexao.query("Update settings Set value = '" + tbxUsuario.Text + "' where field = 'User'");
                        } catch {
                            MessageBox.Show("Não foi possível conectar-se ao banco de dados.2");
                        }
                    } else {
                        try {
                            conexao.closeConnection();
                            conexao.openConnection();
                            conexao.query("INSERT INTO settings(field, value) values('User', '" + tbxUsuario.Text + "')");
                        } catch (MySqlException ex) {
                            MessageBox.Show("Não foi possível conectar-se ao banco de dados.3" + ex.Message);
                        }
                    }
                } catch {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.1");
                }
                conexao.closeConnection();

                this.Close();

            } else {
                tbxSenha.Text = "";
                MessageBox.Show("Senha incorreta");
                tbxSenha.Focus();
            }
        }

        public void getTituloLogin(){
            try{
                conexao.openConnection();

                MySqlDataReader results = conexao.query("Select value from settings where field = 'Title1'");

                if (results.Read()){
                    lbTitle1.Text = results.GetValue(0).ToString();
                }
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.1");
            }

            try{
                conexao.openConnection();

                MySqlDataReader results = conexao.query("Select value from settings where field = 'Title2'");

                if (results.Read()){
                    lbTitle2.Text = results.GetValue(0).ToString();
                }
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.1");
            }
            conexao.closeConnection();
        }

        public void getRememberUser(){
            try {
                conexao.openConnection();

                MySqlDataReader results = conexao.query("Select value from settings where field = 'RememberUser'");

                if (results.Read()){
                    chbxRememberMe.Checked = (results.GetValue(0).ToString() == "True");
                }
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.1");
            }

            if (chbxRememberMe.Checked){
                //this.localizaUsuario(CommitFunctions.getStringValue("ControleDeAcademia", "User", ""));
                try{
                    conexao.openConnection();

                    MySqlDataReader results = conexao.query("Select value from settings where field = 'User'");

                    if (results.Read()){
                        this.localizaUsuario(results.GetValue(0).ToString());
                    }
                } catch(MySqlException ex) {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.1"+ex.Message);
                }
                tbxUsuario.Text = usuario.Id;
                tbxSenha.Focus();
            }

            conexao.closeConnection();
        }

        //Metodos de contorle de componentes
        private void btnLogin_Click(object sender, EventArgs e){
            if (String.IsNullOrEmpty(tbxUsuario.Text))
                MessageBox.Show("Nome de usuario em branco.");
            else
                this.conferirSenha();
        }

        private void tbxID_Validating(object sender, CancelEventArgs e){
            this.localizaUsuario(tbxUsuario.Text);
        }

        private void tbxSenha_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter) this.conferirSenha();
        }

        private void loginScreen_Shown(object sender, EventArgs e){
            this.Visible = false;

            Thread.Sleep(1 * 1000);

            Width = widthScreen;
            Height = heightScreen;

            //Login Background Screen
            pbxBackground.Image = CommitFunctions.resizeImage(ControleDeAcademia.Properties.Resources.Login_Screen2, new Size(Width, Height));

            //Login Screen
            pbxBackground.Controls.Add(pbxLoginScreen);
            pbxLoginScreen.BackColor = Color.Transparent;
            pbxLoginScreen.Location = new Point((Width - pbxLoginScreen.Width) / 2, (Height - pbxLoginScreen.Height) / 2);

            //Login Screen Control
            pbxLoginScreen.Controls.Add(tbxUsuario);
            pbxLoginScreen.Controls.Add(pbxUsuario);
            pbxLoginScreen.Controls.Add(tbxSenha);
            pbxLoginScreen.Controls.Add(pbxSenha);
            pbxLoginScreen.Controls.Add(chbxRememberMe);
            pbxLoginScreen.Controls.Add(btnLogin);
            pbxLoginScreen.Controls.Add(lbForgetPassword);
            pbxLoginScreen.Controls.Add(lbTitle1);
            pbxLoginScreen.Controls.Add(lbTitle2);

            //Usuario Controls
            tbxUsuario.Controls.Add(lbUsuario);

            //Senha Controls
            tbxSenha.Controls.Add(lbSenha);

            //Locations
            //Title
            lbTitle1.Location = new Point(Convert.ToInt32(pbxLoginScreen.Width * 0.07), Convert.ToInt32(pbxLoginScreen.Height * 0.08));
            //Analisar para o segundo titulo, mudar o ponto de referencia.
            lbTitle2.Location = new Point(Convert.ToInt32(pbxLoginScreen.Width * 0.40), Convert.ToInt32(pbxLoginScreen.Height * 0.14));

            //TextBox Usuario
            tbxUsuario.Location = new Point(((pbxLoginScreen.Width - tbxUsuario.Width) / 2), Convert.ToInt32((pbxLoginScreen.Height / 2) - (pbxLoginScreen.Height * 0.15)));
            lbUsuario.Location = new Point(0, Convert.ToInt32((tbxUsuario.Height - lbUsuario.Height) * 0.35));
            pbxUsuario.Location = new Point(Convert.ToInt32(((pbxLoginScreen.Width - tbxUsuario.Width) / 2) * 0.60), Convert.ToInt32((pbxLoginScreen.Height / 2) - (pbxLoginScreen.Height * 0.15) + ((tbxUsuario.Height - pbxUsuario.Height) / 2) ));

            //TextBox Senha
            tbxSenha.Location = new Point(((pbxLoginScreen.Width - tbxSenha.Width) / 2), Convert.ToInt32((pbxLoginScreen.Height / 2) - (pbxLoginScreen.Height * 0.05)));
            lbSenha.Location = new Point(0, Convert.ToInt32((tbxSenha.Height - lbSenha.Height) * 0.35));
            pbxSenha.Location = new Point(Convert.ToInt32(((pbxLoginScreen.Width - tbxSenha.Width) / 2) * 0.60), Convert.ToInt32((pbxLoginScreen.Height / 2) - (pbxLoginScreen.Height * 0.05) + ((tbxSenha.Height - pbxSenha.Height)/2) ));

            //Lembrar-se de mim
            chbxRememberMe.Location = new Point(Convert.ToInt32(((pbxLoginScreen.Width) / 2) - (pbxLoginScreen.Height * 0.26)), Convert.ToInt32((pbxLoginScreen.Height / 2) - (pbxLoginScreen.Height * -0.05)));

            //Botão de Login
            btnLogin.Location = new Point(((pbxLoginScreen.Width - btnLogin.Width) / 2), Convert.ToInt32((pbxLoginScreen.Height / 2) - (pbxLoginScreen.Height * -0.15)));
            btnLogin.Region = new Region(CommitFunctions.BorderRadius(btnLogin.ClientRectangle, 8, true, true));

            //Esqueceu sua senha?
            lbForgetPassword.Location = new Point(Convert.ToInt32(((pbxLoginScreen.Width) / 2) - (pbxLoginScreen.Height * -0.07)), Convert.ToInt32((pbxLoginScreen.Height / 2) - (pbxLoginScreen.Height * -0.25)));

            this.getTituloLogin();

            WindowState = FormWindowState.Maximized;
            this.Visible = true;

            this.getRememberUser();
        }

        private void tbxUsuario_Enter(object sender, EventArgs e){
            lbUsuario.Visible = false;
        }

        private void tbxUsuario_Leave(object sender, EventArgs e){
            if(String.IsNullOrEmpty(tbxUsuario.Text)) lbUsuario.Visible = true;
        }

        private void tbxSenha_Enter(object sender, EventArgs e){
            lbSenha.Visible = false;
        }

        private void tbxSenha_Leave(object sender, EventArgs e){
            if (String.IsNullOrEmpty(tbxSenha.Text)) lbSenha.Visible = true;
        }

        private void lbUsuario_Click(object sender, EventArgs e){
            tbxUsuario.Focus();
        }

        private void lbSenha_Click(object sender, EventArgs e){
            tbxSenha.Focus();
        }

        private void loginScreen_FormClosed(object sender, FormClosedEventArgs e){
            if (!this.autorizado) Application.Exit();
        }

        private void lbForgetPassword_Click(object sender, EventArgs e){
            MessageBox.Show("Entre em contato com a Commit Software.\nFone:(83) 98603-9335\nE-Mail:arthursilvestre@outlook.com");
        }

        private void tbxUsuario_KeyPress(object sender, KeyPressEventArgs e){
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0){
                e.Handled = true;
                tbxSenha.Focus();
            }
        }

    }
}