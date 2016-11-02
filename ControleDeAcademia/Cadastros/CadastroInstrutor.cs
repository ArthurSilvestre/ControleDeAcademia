using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcademia{
    public partial class CadastroInstrutor : Form{
        //Atributos
        private ConnectionDataBase connectionDataBase = new ConnectionDataBase();
        private Instrutor instrutor = new Instrutor();
        private bool alteracao = false;

        //Construtores
        public CadastroInstrutor(){
            InitializeComponent();

            carregarConteudoComboBoxes();
            removerFoto();
        }
        public CadastroInstrutor(int codigo){
            InitializeComponent();

            carregarConteudoComboBoxes();
            removerFoto();

            instrutor.Codigo = codigo;
        }

        //Methodos
        private void carregarConteudoComboBoxes(){
            CommitFunctions.addDadosCombobox(CommitFunctions.Estados, comboBox1);
            CommitFunctions.addDadosCombobox(CommitFunctions.GrauDeInstrucoes, comboBox2,CommitFunctions.ValuesGrausDeInstrucoes);
        }

        private void findeFile(){
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.InitialDirectory = @"C:\";
            dialogo.Filter = "Arquivos texto (*.bmp)|*.bmp|Todos os arquivos (*.*)|*.*";
            DialogResult resposta = dialogo.ShowDialog();

            if (resposta == DialogResult.OK){
                FileStream selectedFile = new FileStream(dialogo.FileName, FileMode.Open);
                MemoryStream memoryStreamSelectedFile = new MemoryStream();

                selectedFile.CopyTo(memoryStreamSelectedFile);
                instrutor.Foto = memoryStreamSelectedFile.ToArray();
            }
        }

        private void removerFoto() {
            pictureBox2.Image = CommitFunctions.resizeImage(ControleDeAcademia.Properties.Resources.SemFoto, new Size(pictureBox2.Width, pictureBox2.Height));
            instrutor.Foto = null;
            button2.Enabled = false;
        }

        private bool verificarCamposEmBranco(){
            if (String.IsNullOrEmpty(textBox2.Text)/*Nome*/ || String.IsNullOrEmpty(textBox19.Text)/*Senha*/)
                return true;

            return false;
        }

        private bool editInstrutor(){
            if (verificarCamposEmBranco()){
                MessageBox.Show("Os campos com * são obrigatórios.");
                return false;
            } else {
                string mySqlInsertSintax = "";
                List<string> insertFields = new List<string>();
                List<string> insertValues = new List<string>();

                //Campos obrigatorios
                insertFields.Add("deleted");
                insertFields.Add("dtcadastro");
                insertFields.Add("dtalteracao");
                insertFields.Add("nome");
                insertFields.Add("senha");
                insertFields.Add("ativo");

                insertValues.Add("0");
                insertValues.Add("CURRENT_DATE()");
                insertValues.Add("CURRENT_DATE()");
                insertValues.Add("'"+textBox2.Text+"'");
                insertValues.Add(textBox19.Text);
                insertValues.Add("0");

                //Campos opcionais

                if (!String.IsNullOrEmpty(textBox3.Text)){
                    insertFields.Add("cpf");
                    insertValues.Add(textBox3.Text);
                }

                if (!String.IsNullOrEmpty(textBox4.Text)){
                    insertFields.Add("rg");
                    insertValues.Add(textBox4.Text);
                }

                insertFields.Add("foto");
                insertValues.Add("@foto");

                insertFields.Add("dtnascimento");
                insertValues.Add("'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'");

                if (!String.IsNullOrEmpty(textBox5.Text)){
                    insertFields.Add("cep");
                    insertValues.Add(textBox5.Text);
                }

                if (!String.IsNullOrEmpty(comboBox1.Text)){
                    insertFields.Add("estado");
                    insertValues.Add("'"+comboBox1.Text+"'");
                }

                if (!String.IsNullOrEmpty(textBox6.Text)){
                    insertFields.Add("cidade");
                    insertValues.Add("'"+textBox6.Text+"'");
                }

                if (!String.IsNullOrEmpty(textBox7.Text)){
                    insertFields.Add("bairro");
                    insertValues.Add("'" + textBox7.Text + "'");
                }

                if (!String.IsNullOrEmpty(textBox8.Text)){
                    insertFields.Add("endereco");
                    insertValues.Add("'" + textBox8.Text + "'");
                }

                if (!String.IsNullOrEmpty(textBox9.Text)){
                    insertFields.Add("numero");
                    insertValues.Add(textBox9.Text);
                }

                if (!String.IsNullOrEmpty(textBox10.Text)){
                    insertFields.Add("complemento");
                    insertValues.Add("'" + textBox10.Text + "'");
                }

                if (!String.IsNullOrEmpty(textBox11.Text)){
                    insertFields.Add("dddtelefone");
                    insertValues.Add(textBox11.Text);
                }

                if (!String.IsNullOrEmpty(textBox12.Text)){
                    insertFields.Add("telefone");
                    insertValues.Add(textBox12.Text);
                }

                if (!String.IsNullOrEmpty(textBox14.Text)){
                    insertFields.Add("dddcelular1");
                    insertValues.Add(textBox14.Text);
                }

                if (!String.IsNullOrEmpty(textBox13.Text)){
                    insertFields.Add("celular1");
                    insertValues.Add(textBox13.Text);
                }

                if (!String.IsNullOrEmpty(textBox16.Text)){
                    insertFields.Add("dddcelular2");
                    insertValues.Add(textBox16.Text);
                }

                if (!String.IsNullOrEmpty(textBox15.Text)){
                    insertFields.Add("celular2");
                    insertValues.Add(textBox15.Text);
                }

                if (!String.IsNullOrEmpty(comboBox2.Text)){
                    insertFields.Add("codgrauinst");
                    insertValues.Add(comboBox2.SelectedValue.ToString());
                }

                /* TODO: FALTA AS DIGITAIS */

                //Montar MySql Sintax
                string[] insertFieldsArray = insertFields.ToArray();
                string[] insertValuesArray = insertValues.ToArray();

                if (this.alteracao) {
                    mySqlInsertSintax += "Update cadastrosInstrutores Set ";

                    for (int i = 0; i < insertFieldsArray.Length; i++){
                        mySqlInsertSintax += ((i == 0) ? "" : ", ") + insertFieldsArray[i] + " = " + insertValuesArray[i];
                    }

                    mySqlInsertSintax += " where codigo = " + instrutor.Codigo;
                } else {
                    mySqlInsertSintax += "INSERT INTO cadastrosInstrutores (";

                    for (int i = 0; i < insertFieldsArray.Length; i++)
                        mySqlInsertSintax += ((i == 0) ? "" : ", ") + insertFieldsArray[i];

                    mySqlInsertSintax += ") values(";

                    for (int i = 0; i < insertValuesArray.Length; i++)
                        mySqlInsertSintax += ((i == 0) ? "" : ", ") + insertValuesArray[i];

                    mySqlInsertSintax += ")";
                }

                MessageBox.Show(mySqlInsertSintax);

                //Efetuar o MySql Insert
                try {
                    connectionDataBase.openConnection();
                    connectionDataBase.query(mySqlInsertSintax, instrutor.Foto);
                }
                catch (MySqlException Ex) {
                    MessageBox.Show("Não foi possível conectar-se ao banco de dados." + Environment.NewLine + "Erro: " + Ex.Message);
                    connectionDataBase.closeConnection();
                    return false;
                }
                connectionDataBase.closeConnection();
                return true;
            }
        }

        public void carregarDadosInstrutor(){
            try {
                connectionDataBase.openConnection();
                MySqlDataReader results = connectionDataBase.query("Select nome,cpf,rg,foto,dtnascimento,cep,estado,cidade,bairro,endereco,numero,complemento,dddtelefone,telefone,dddcelular1,celular1,dddcelular2,celular2,senha,'digitais','digitais','digitais','digitais','digitais','digitais','digitais','digitais','digitais','digitais',ativo,codgrauinst from cadastrosinstrutores where deleted = 0 and codigo = " + instrutor.Codigo);

                if (results.Read()) {
                    textBox2.Text = results.GetValue(0).ToString();
                    textBox3.Text = results.GetValue(1).ToString();
                    textBox4.Text = results.GetValue(2).ToString();
                    try { 
                        pictureBox2.Image = CommitFunctions.resizeImage(Image.FromStream(new MemoryStream(CommitFunctions.getImageFromDataBase(results, 3))), new Size(pictureBox2.Width, pictureBox2.Height));
                        button2.Enabled = true;
                    } catch {
                        removerFoto();
                    }
                    dateTimePicker1.Value = results.GetDateTime(4);
                    textBox5.Text = results.GetValue(5).ToString();
                    comboBox1.Text = results.GetValue(6).ToString();
                    textBox6.Text = results.GetValue(7).ToString();
                    textBox7.Text = results.GetValue(8).ToString();
                    textBox8.Text = results.GetValue(9).ToString();
                    textBox9.Text = results.GetValue(10).ToString();
                    textBox10.Text = results.GetValue(11).ToString();
                    textBox11.Text = results.GetValue(12).ToString();
                    textBox12.Text = results.GetValue(13).ToString();
                    textBox14.Text = results.GetValue(14).ToString();
                    textBox13.Text = results.GetValue(15).ToString();
                    textBox16.Text = results.GetValue(16).ToString();
                    textBox15.Text = results.GetValue(17).ToString();
                    comboBox2.SelectedValue = Convert.ToInt32(results.GetValue(30));
                    textBox19.Text = results.GetValue(18).ToString();
                }
            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
            }
            connectionDataBase.closeConnection();
        }

        public void desativarCamposEBotoes(){
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox14.Enabled = false;
            textBox13.Enabled = false;
            textBox16.Enabled = false;
            textBox15.Enabled = false;
            textBox19.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        //Methodos de eventos
        private void button3_Click(object sender, EventArgs e){
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e){
            if (MessageBox.Show("Confirma excluir foto?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes){
                removerFoto();
            }
        }

        private void button1_Click(object sender, EventArgs e){
            findeFile();
            if (instrutor.Foto != null) {
                MemoryStream memoryStreamPictureBox2Image = new MemoryStream(instrutor.Foto);
                pictureBox2.Image = CommitFunctions.resizeImage(Image.FromStream(memoryStreamPictureBox2Image), new Size(pictureBox2.Width, pictureBox2.Height));
                button2.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e){
            if (editInstrutor()){
                this.Close();
                if (alteracao)
                    MessageBox.Show("Alteração realizada com sucesso.");
                else
                    MessageBox.Show("Cadastro realizado com sucesso.");
            }
        }
        
        //Get's e Set's
        public bool Alteracao{
            get{
                return alteracao;
            }
            set{
                alteracao = value;
            }
        }

    }
}
