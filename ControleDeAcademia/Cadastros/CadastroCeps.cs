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
    public partial class CadastroCeps : Form{
        //Atributos
        private ConnectionDataBase connectionDataBase = new ConnectionDataBase();

        //Construtor
        public CadastroCeps(){
            InitializeComponent();
        }

        //Metodos
        public void carregarCeps(){
            try{
                connectionDataBase.openConnection();

                MySqlDataAdapter results = new MySqlDataAdapter("Select cep,logradouro,cidade,bairro,estado,abreviacao from cadastrosceps where deleted = 0", connectionDataBase.gsConexao);
                DataTable ceps = new DataTable();
                results.Fill(ceps);

                dataGridView1.DataSource = ceps;

                dataGridView1.Columns[0].HeaderText = "cep";
                dataGridView1.Columns[0].Width = 60;
                dataGridView1.Columns[1].HeaderText = "logradouro";
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[2].HeaderText = "cidade";
                dataGridView1.Columns[2].Width = 60;
                dataGridView1.Columns[3].HeaderText = "bairro";
                dataGridView1.Columns[3].Width = 70;
                dataGridView1.Columns[4].HeaderText = "estado";
                dataGridView1.Columns[4].Width = 68;
                dataGridView1.Columns[5].HeaderText = "abreviacao";
                dataGridView1.Columns[5].Width = 50;
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.2");
            }
            connectionDataBase.closeConnection();
        }

        private void carregaConteudoComboBox(){
            CommitFunctions.addDadosCombobox(CommitFunctions.Estados, comboBox1);
        }

        private void carregarTextBoxComDadosRegistro(){
            try{
                connectionDataBase.openConnection();
                MySqlDataReader results = connectionDataBase.query("Select cep,logradouro,cidade,bairro,estado,abreviacao from cadastrosceps where deleted = 0 and cep = " + dataGridView1.CurrentRow.Cells[0].Value.ToString());

                if (results.Read()){
                    tbxCep.Text = results.GetString(0);
                    textBox1.Text = results.GetString(5);
                    textBox5.Text = results.GetString(1);
                    textBox2.Text = results.GetString(2);
                    textBox3.Text = results.GetString(3);

                    comboBox1.Text = results.GetString(4);
                }
            } catch {
                tbxCep.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";

                comboBox1.SelectedValue = -1;
            }
            connectionDataBase.closeConnection();
        }

        private void incluirRegistroEmBranco(){
            try{
                connectionDataBase.openConnection();
                connectionDataBase.query("INSERT INTO cadastrosceps(deleted, dtcadastro, dtalteracao,cep) values(0, CURRENT_DATE(), CURRENT_DATE(),0)");
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.1");
            }
            connectionDataBase.closeConnection();
        }

        private void excluirCep(){
            if (MessageBox.Show("Confirma excluir registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes){
                try{
                    connectionDataBase.openConnection();
                    connectionDataBase.query("Update cadastrosCeps Set deleted = 1, dtalteracao = CURRENT_DATE() Where cep = " + dataGridView1.CurrentRow.Cells[0].Value);
                }  catch {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                }
                connectionDataBase.closeConnection();
            }
        }

        private void refreshCurrenRow(){
            dataGridView1.CurrentRow.Cells[0].Value = tbxCep.Text;
            dataGridView1.CurrentRow.Cells[1].Value = textBox5.Text;
            dataGridView1.CurrentRow.Cells[2].Value = textBox2.Text;
            dataGridView1.CurrentRow.Cells[3].Value = textBox3.Text;
            dataGridView1.CurrentRow.Cells[4].Value = comboBox1.Text;
            dataGridView1.CurrentRow.Cells[5].Value = textBox1.Text;
        }

        private void salvarInformacoesCep(){
            try{
                connectionDataBase.openConnection();
                connectionDataBase.query("Update cadastrosCeps Set dtalteracao = CURRENT_DATE(), cep = '" + tbxCep.Text + "', logradouro = '" + textBox5.Text + "', cidade = '" + textBox2.Text + "', bairro = '" + textBox3.Text + "', estado = '" + comboBox1.Text + "', abreviacao = '" + textBox1.Text + "' WHERE cep = " + dataGridView1.CurrentRow.Cells[0].Value);
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        //Metodos de eventos
        private void CadastroCeps_Load(object sender, EventArgs e){
            this.carregarCeps();
            this.carregaConteudoComboBox();
            this.carregarTextBoxComDadosRegistro();
        }

        private void dataGridView1_Click(object sender, EventArgs e){
            this.carregarTextBoxComDadosRegistro();
        }

        private void button4_Click(object sender, EventArgs e){
            this.incluirRegistroEmBranco();
            this.carregarCeps();
            this.carregarTextBoxComDadosRegistro();
        }

        private void button2_Click(object sender, EventArgs e){
            this.excluirCep();
            this.carregarCeps();
            this.carregarTextBoxComDadosRegistro();
        }

        private void button1_Click(object sender, EventArgs e){
            salvarInformacoesCep();
            refreshCurrenRow();
        }
    }
}
