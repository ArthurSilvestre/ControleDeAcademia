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
    public partial class ConsultaDeAlunos : Form{
        //Atributos
        private ConnectionDataBase connectionDataBase = new ConnectionDataBase();

        //Contrutor
        public ConsultaDeAlunos(){
            InitializeComponent();
        }

        //Metodos
        public void carregarAlunos(){
            try{
                connectionDataBase.openConnection();

                MySqlDataAdapter results = new MySqlDataAdapter("Select lpad(codigo,6,'0'),nome from cadastrosAlunos where deleted = 0", connectionDataBase.gsConexao);
                DataTable alunos = new DataTable();
                results.Fill(alunos);

                dataGridView1.DataSource = alunos;

                dataGridView1.Columns[0].HeaderText = "Código";
                dataGridView1.Columns[0].Width = 77;
                dataGridView1.Columns[1].HeaderText = "Nome";
                dataGridView1.Columns[1].Width = 200;
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        public void excluirAluno(){
            if (MessageBox.Show("Confirma excluir registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes){
                try{
                    connectionDataBase.openConnection();
                    connectionDataBase.query("Update cadastrosAlunos Set deleted = 1, dtalteracao = CURRENT_DATE() Where codigo = " + dataGridView1.CurrentRow.Cells[0].Value);
                } catch {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                }
                connectionDataBase.closeConnection();
            }
        }

        //Metodos de eventos
        private void ConsultaDeAlunos_Load(object sender, EventArgs e){
            this.carregarAlunos();
        }

        private void button1_Click(object sender, EventArgs e){
            CadastroAluno cadastroAluno = new CadastroAluno(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cadastroAluno.Alteracao = true;
            cadastroAluno.carregarDadosAluno();
            cadastroAluno.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e){
            this.excluirAluno();
            this.carregarAlunos();
        }

        private void button4_Click(object sender, EventArgs e){
            CadastroAluno cadastroAluno = new CadastroAluno(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cadastroAluno.carregarDadosAluno();
            cadastroAluno.desativarCamposEBotoes();
            cadastroAluno.ShowDialog();
        }
    }
}
