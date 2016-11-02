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
    public partial class ConsultaDeInstrutores : Form{
        //Atributos
        private ConnectionDataBase connectionDataBase = new ConnectionDataBase();

        //Construtor
        public ConsultaDeInstrutores(){
            InitializeComponent();
        }

        //Metodos
        public void carregarInstrutores(){
            try {
                connectionDataBase.openConnection();

                MySqlDataAdapter results = new MySqlDataAdapter("Select lpad(codigo,6,'0'),nome from cadastrosinstrutores where deleted = 0", connectionDataBase.gsConexao);
                DataTable instrutores = new DataTable();
                results.Fill(instrutores);

                dataGridView1.DataSource = instrutores;

                dataGridView1.Columns[0].HeaderText = "Código";
                dataGridView1.Columns[0].Width = 77;
                dataGridView1.Columns[1].HeaderText = "Nome";
                dataGridView1.Columns[1].Width = 200;
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        public void excluirInstrutor(){
            if (MessageBox.Show("Confirma excluir registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes){
                try{
                    connectionDataBase.openConnection();
                    connectionDataBase.query("Update cadastrosinstrutores Set deleted = 1, dtalteracao = CURRENT_DATE() Where codigo = " + dataGridView1.CurrentRow.Cells[0].Value);
                } catch {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                }
                connectionDataBase.closeConnection();
            }
        }

        //Metodos de eventos
        private void ConsultaDeInstrutores_Load(object sender, EventArgs e){
            carregarInstrutores();
        }

        private void button1_Click(object sender, EventArgs e){
            CadastroInstrutor cadastroInstrutor = new CadastroInstrutor(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cadastroInstrutor.Alteracao = true;
            cadastroInstrutor.carregarDadosInstrutor();
            cadastroInstrutor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e){
            this.excluirInstrutor();
            this.carregarInstrutores();
        }

        private void button4_Click(object sender, EventArgs e){
            CadastroInstrutor cadastroInstrutor = new CadastroInstrutor(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cadastroInstrutor.carregarDadosInstrutor();
            cadastroInstrutor.desativarCamposEBotoes();
            cadastroInstrutor.ShowDialog();
        }

    }
}
