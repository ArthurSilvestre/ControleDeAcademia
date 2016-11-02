using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcademia{
    public partial class TipoIdentificacao : Form{
        public int sentido; //1 - Entrada, 2 - Saída
        private Random rdn = new Random();
        private ConnectionDataBase connectionDataBase = new ConnectionDataBase();
        private string[] Digitais = { "Polegar Direito", "Indicador Direito", "Médio Direito", "Anelar Direito", "Mínimo Direito", "Polegar Esquerdo", "Indicador Esquerdo", "Médio Esquerdo", "Anelar Esquerdo", "Mínimo Esquerdo" };

        public TipoIdentificacao(){
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e){
            if (String.IsNullOrEmpty( textBox1.Text )){
                MessageBox.Show("O código está em branco.");
            } else {
                if ((radioButton1.Checked == true) && (radioButton2.Checked == false)) {// Aluno
                    try
                    {
                        connectionDataBase.openConnection();
                        MySqlDataReader results = connectionDataBase.query("Select senha from cadastrosAlunos where deleted = 0 and codigo = " + textBox1.Text);
                        if (results.Read())
                        {

                            getSenha gs = new getSenha();
                            gs.ShowDialog();

                            if (gs.getsenhainformada() == results.GetValue(0).ToString())
                            {
                                ConnectionTopDataDevices.EnviarMensagemTemporariaOnLine(1, 1, "ACESSO LIBERADO", 5);
                                ConnectionTopDataDevices.AcionarBipCurto(1);
                                ConnectionTopDataDevices.LiberarCatracaDoisSentidos(1);
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(gs.getsenhainformada())) MessageBox.Show("Senhas não conferem, tente novamente.");
                            }
                        } else
                        {
                            MessageBox.Show("Instrutor não encontrado.");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                    }
                }
                else { // Instrutor
                    try
                    {
                        connectionDataBase.openConnection();
                        MySqlDataReader results = connectionDataBase.query("Select senha from cadastrosInstrutores where deleted = 0 and codigo = " + textBox1.Text);
                        if (results.Read())
                        {

                            getSenha gs = new getSenha();
                            gs.ShowDialog();

                            if (gs.getsenhainformada() == results.GetValue(0).ToString())
                            {
                                ConnectionTopDataDevices.EnviarMensagemTemporariaOnLine(1, 1, "ACESSO LIBERADO", 5);
                                ConnectionTopDataDevices.AcionarBipCurto(1);
                                ConnectionTopDataDevices.LiberarCatracaDoisSentidos(1);
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(gs.getsenhainformada())) MessageBox.Show("Senhas não conferem, tente novamente.");
                            }
                        } else
                        {
                            MessageBox.Show("Instrutor não encontrado.");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e){

            if (String.IsNullOrEmpty(textBox1.Text)){
                MessageBox.Show("O código está em branco.");
            } else {
                if ((radioButton1.Checked == true) && (radioButton2.Checked == false)) { // Aluno
                    try {
                        connectionDataBase.openConnection();
                        MySqlDataReader results = connectionDataBase.query("Select digitaldireita1,digitaldireita2,digitaldireita3,digitaldireita4,digitaldireita5,digitalesquerda1,digitalesquerda2,digitalesquerda3,digitalesquerda4,digitalesquerda5,ativo,restrito,horaentrada,horasaida from cadastrosAlunos where deleted = 0 and codigo = " + textBox1.Text);
                        if (results.Read()) {

                            int randomDigital = rdn.Next(0, 9);

                            MessageBox.Show("Coloque o seguinte dedo: " + Digitais[randomDigital]);

                            if (ConnectionTopDataDevices.compararDigitais(results.GetValue(randomDigital).ToString(), ConnectionTopDataDevices.capturarDigital())){
                                ConnectionTopDataDevices.EnviarMensagemTemporariaOnLine(1, 1, "ACESSO LIBERADO", 5);
                                ConnectionTopDataDevices.AcionarBipCurto(1);
                                ConnectionTopDataDevices.LiberarCatracaDoisSentidos(1);
                            } else {
                                MessageBox.Show("Digitais não conferem, tente novamente.");
                            }
                        }
                    } catch {
                        MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                    }

                    connectionDataBase.closeConnection();
                } else { // Instrutor
                    try
                    {
                        connectionDataBase.openConnection();
                        MySqlDataReader results = connectionDataBase.query("Select digitaldireita1,digitaldireita2,digitaldireita3,digitaldireita4,digitaldireita5,digitalesquerda1,digitalesquerda2,digitalesquerda3,digitalesquerda4,digitalesquerda5,ativo from cadastrosInstrutores where deleted = 0 and codigo = " + textBox1.Text);
                        if (results.Read())
                        {
                            int randomDigital = rdn.Next(0, 9);

                            MessageBox.Show("Coloque o seguinte dedo: " + Digitais[randomDigital]);

                            if (ConnectionTopDataDevices.compararDigitais(results.GetValue(randomDigital).ToString(), ConnectionTopDataDevices.capturarDigital())){
                                ConnectionTopDataDevices.EnviarMensagemTemporariaOnLine(1, 1, "ACESSO LIBERADO", 5);
                                ConnectionTopDataDevices.AcionarBipCurto(1);
                                ConnectionTopDataDevices.LiberarCatracaDoisSentidos(1);
                            }
                            else {
                                MessageBox.Show("Digitais não conferem, tente novamente.");
                            }
                        }
                    } catch {
                        MessageBox.Show("Não foi possível conectar-se ao banco de dados.");
                    }

                    connectionDataBase.closeConnection();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e){
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("O código está em branco.");
            }
            else {
                if ((radioButton1.Checked == true) && (radioButton2.Checked == false)){// Aluno

                }
                else { // Instrutor

                }
            }
        }
    }
}
