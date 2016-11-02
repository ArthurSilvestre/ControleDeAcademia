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
    public partial class CadastroDispositivos : Form{

        #region Atributos
            private ConnectionDataBase connectionDataBase = new ConnectionDataBase();
            private string[] PadraoCartao = { "Padrão Topdata", "Padrão livre (Padrão)" };
            private string[] TipoDoDispositivo = { "Catraca" };
            private string[] Sentido = { "Esquerda", "Direita" };
            private string[] TipoDoLeitor = { "Leitor de código de barras(Padrão)", "Leitor Magnético", "Leitor proximidade AbaTrack2", "Leitor proximidade Wiegand e Wiegand Facility Code", "Leitor proximidade Smart Card" };
            private string[] TipoConexao = { "Comunicação serial, RS-232/485.", "Comunicação TCP/IP com porta variável.", "Comunicação TCP/IP com porta fixa (Default).", "Comunicação via modem.", "Comunicação via TopPendrive." };
        #endregion

        public CadastroDispositivos(){
            InitializeComponent();
        }

        private void carregarDispositivos(){
            try{
                connectionDataBase.openConnection();

                MySqlDataAdapter results = new MySqlDataAdapter("Select lpad(codigo,6,'0'),lpad(numeroinner,3,'0'),porta,padraocartao,tipoequipamento from cadastrosDispositivos where deleted = 0", connectionDataBase.gsConexao);
                DataTable dispositivos = new DataTable();
                results.Fill(dispositivos);

                dataGridView1.DataSource = dispositivos;

                dataGridView1.Columns[0].HeaderText = "Código";
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].HeaderText = "Número do Inner";
                dataGridView1.Columns[1].Width = 70;
                dataGridView1.Columns[2].HeaderText = "Porta";
                dataGridView1.Columns[2].Width = 70;
                dataGridView1.Columns[3].HeaderText = "Padrão do Cartão";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].HeaderText = "Tipo do Dispositivo";
                dataGridView1.Columns[4].Width = 105;

            }catch{
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        private void carregaConteudoComboBox() {
            CommitFunctions.addDadosCombobox(this.PadraoCartao, cbxPadraoCartao);
            CommitFunctions.addDadosCombobox(this.TipoDoDispositivo, cbxTipoDoDispositivo);
            CommitFunctions.addDadosCombobox(this.Sentido, cbxSentido);
            CommitFunctions.addDadosCombobox(this.TipoDoLeitor, cbxTipoDoLeitor);
            CommitFunctions.addDadosCombobox(this.TipoConexao, cbxTipoConexao);
        }

        private void incluirRegistroEmBranco(){
            try {
                connectionDataBase.openConnection();
                connectionDataBase.query("INSERT INTO cadastrosDispositivos(deleted, dtcadastro, dtalteracao) values(0, CURRENT_DATE(), CURRENT_DATE())");
            }catch{
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        private void carregarTextBoxComDadosRegistro(){
            try{
                connectionDataBase.openConnection();
                MySqlDataReader results = connectionDataBase.query("Select lpad(codigo,6,'0'),lpad(numeroinner,3,'0'),porta,tipoconexao,tipoleitor,padraocartao,tipoequipamento,sentido from cadastrosdispositivos where deleted = 0 and codigo = " + dataGridView1.CurrentRow.Cells[0].Value.ToString());

                if (results.Read()){
                    textBox1.Text = results.GetString(0);
                    textBox2.Text = results.GetString(1);
                    textBox3.Text = results.GetString(2);

                    cbxPadraoCartao.SelectedValue = results.GetInt64(5);
                    cbxTipoDoDispositivo.SelectedValue = results.GetInt64(6);
                    cbxSentido.SelectedValue = results.GetInt64(7);
                    cbxTipoDoLeitor.SelectedValue = results.GetInt64(4);
                    cbxTipoConexao.SelectedValue = results.GetInt64(3);
                }
            }catch{
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                cbxPadraoCartao.SelectedValue = -1;
                cbxTipoDoDispositivo.SelectedValue = -1;
                cbxSentido.SelectedValue = -1;
                cbxTipoDoLeitor.SelectedValue = -1;
                cbxTipoConexao.SelectedValue = -1;
            }
            connectionDataBase.closeConnection();
        }

        private void refreshCurrenRow(){
            dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
            dataGridView1.CurrentRow.Cells[2].Value = textBox3.Text;
            dataGridView1.CurrentRow.Cells[3].Value = cbxPadraoCartao.SelectedValue;
            dataGridView1.CurrentRow.Cells[4].Value = cbxTipoDoDispositivo.SelectedValue;
        }

        private void salvarInformacoesDispositivo(){
            try{
                connectionDataBase.openConnection();
                connectionDataBase.query("Update cadastrosdispositivos Set dtalteracao = CURRENT_DATE(), numeroinner = " + textBox2.Text + ", porta = " + textBox3.Text + ", tipoconexao = " + cbxTipoConexao.SelectedValue + ", padraocartao = " + cbxPadraoCartao.SelectedValue + ", tipoequipamento = " + cbxTipoDoDispositivo.SelectedValue + ", sentido = "+ cbxSentido.SelectedValue + ", tipoleitor = "+ cbxTipoDoLeitor.SelectedValue + " WHERE codigo = " + dataGridView1.CurrentRow.Cells[0].Value);
            }catch{
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        private void excluirDispositivo(){
            if (MessageBox.Show("Confirma excluir registro?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes){
                try{
                    connectionDataBase.openConnection();
                    connectionDataBase.query("Update cadastrosdispositivos Set deleted = 1, dtalteracao = CURRENT_DATE() Where codigo = " + dataGridView1.CurrentRow.Cells[0].Value);
                }catch{
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                }
                connectionDataBase.closeConnection();
            }
        }

        #region Metodos dos componentes
            private void button4_Click(object sender, EventArgs e){
                incluirRegistroEmBranco();
                carregarDispositivos();
                carregarTextBoxComDadosRegistro();
            }

            private void CadastroDispositivos_Load(object sender, EventArgs e){
                carregarDispositivos();
                carregaConteudoComboBox();
                carregarTextBoxComDadosRegistro();
            }

            private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e){
                if (e.ColumnIndex == 3){
                    e.Value = PadraoCartao[(int)e.Value];
                    e.FormattingApplied = true;
                } else if (e.ColumnIndex == 4){
                    e.Value = TipoDoDispositivo[(int)e.Value];
                    e.FormattingApplied = true;
                }
            }

            private void dataGridView1_Click(object sender, EventArgs e){
                    carregarTextBoxComDadosRegistro();
                }

            private void button1_Click(object sender, EventArgs e){
                salvarInformacoesDispositivo();
                refreshCurrenRow();
            }

        private void button2_Click(object sender, EventArgs e){
                excluirDispositivo();
                carregarDispositivos();
                carregarTextBoxComDadosRegistro();
            }
        #endregion

    }
}
