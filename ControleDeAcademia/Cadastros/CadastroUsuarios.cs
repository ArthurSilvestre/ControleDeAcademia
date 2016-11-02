using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcademia{
    public partial class CadastroUsuarios : Form{

        //Atributos
        private ConnectionDataBase connectionDataBase = new ConnectionDataBase();
        private string[] niveis = { "Padrão", "Administrador" };

        //Construtor
        public CadastroUsuarios(){
            InitializeComponent();
        }

        //Metodos
        public void carregarUsuarios(){
            try{
                connectionDataBase.openConnection();

                MySqlDataAdapter results = new MySqlDataAdapter("Select lpad(codigo,6,'0'),id,nivel from cadastrosusuarios where deleted = 0", connectionDataBase.gsConexao);
                DataTable ususarios = new DataTable();
                results.Fill(ususarios);

                dataGridView1.DataSource = ususarios;

                dataGridView1.Columns[0].HeaderText = "Código";
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].HeaderText = "ID";
                dataGridView1.Columns[1].Width = 125;
                dataGridView1.Columns[2].HeaderText = "Nível";
                dataGridView1.Columns[2].Width = 200;
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        private void carregaConteudoComboBox(){
            CommitFunctions.addDadosCombobox(this.niveis, cbxNiveis);
        }

        private void carregarTextBoxComDadosRegistro(){
            try{
                connectionDataBase.openConnection();
                MySqlDataReader results = connectionDataBase.query("Select lpad(codigo,6,'0'),id,senha,nivel from cadastrosusuarios where deleted = 0 and codigo = " + dataGridView1.CurrentRow.Cells[0].Value.ToString());

                if (results.Read()){
                    tbxCodigo.Text = results.GetString(0);
                    tbxID.Text = results.GetString(1);
                    tbxSenha.Text = results.GetString(2);

                    cbxNiveis.SelectedValue = results.GetInt64(3);
                }
            } catch {
                tbxCodigo.Text = "";
                tbxID.Text = "";
                tbxSenha.Text = "";

                cbxNiveis.SelectedValue = -1;
            }
            connectionDataBase.closeConnection();
        }

        private void incluirRegistroEmBranco(){
            try{
                connectionDataBase.openConnection();
                connectionDataBase.query("INSERT INTO cadastrosUsuarios(deleted, dtcadastro, dtalteracao) values(0, CURRENT_DATE(), CURRENT_DATE())");
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        private void excluirUsuario(){
            if (MessageBox.Show("Confirma excluir registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes){
                try{
                    connectionDataBase.openConnection();
                    connectionDataBase.query("Update cadastrosUsuarios Set deleted = 1, dtalteracao = CURRENT_DATE() Where codigo = " + dataGridView1.CurrentRow.Cells[0].Value);
                } catch {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                }
                connectionDataBase.closeConnection();
            }
        }

        private void refreshCurrenRow(){
            dataGridView1.CurrentRow.Cells[1].Value = tbxID.Text;
            dataGridView1.CurrentRow.Cells[2].Value = cbxNiveis.SelectedValue;
        }

        private void salvarInformacoesUsuario(){
            try{
                connectionDataBase.openConnection();
                connectionDataBase.query("Update cadastrosUsuarios Set dtalteracao = CURRENT_DATE(), id = '" + tbxID.Text + "', senha = '" + tbxSenha.Text + "', nivel = " + cbxNiveis.SelectedValue + " WHERE codigo = " + dataGridView1.CurrentRow.Cells[0].Value);
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        //Metodos dos eventos
        private void CadastroUsuarios_Load(object sender, EventArgs e){
            carregarUsuarios();
            carregaConteudoComboBox();
            carregarTextBoxComDadosRegistro();
        }

        private void dataGridView1_Click(object sender, EventArgs e){
            this.carregarTextBoxComDadosRegistro();
        }

        private void button4_Click(object sender, EventArgs e){
            this.incluirRegistroEmBranco();
            this.carregarUsuarios();
            this.carregarTextBoxComDadosRegistro();
        }

        private void button2_Click(object sender, EventArgs e){
            this.excluirUsuario();
            this.carregarUsuarios();
            this.carregarTextBoxComDadosRegistro();
        }

        private void button1_Click(object sender, EventArgs e){
            salvarInformacoesUsuario();
            refreshCurrenRow();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e){
            if (e.ColumnIndex == 2){
                e.Value = niveis[(int)e.Value];
                e.FormattingApplied = true;
            }
        }
    }
}
