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
    public partial class CommitMySqlSettings : Form{
        public CommitMySqlSettings(){
            InitializeComponent();
        }

        private void CommitSettings_Load(object sender, EventArgs e){

        }

        private void btCancelar_Click(object sender, EventArgs e){
            this.Close();
        }

        private void btConfirmar_Click(object sender, EventArgs e){
            //Abrir o arquivo
            StreamWriter commitSQLSettingsCA = new StreamWriter("C:\\windows\\CommitSQLSettingsCA.ini", true, Encoding.ASCII);

            //Escrever
            commitSQLSettingsCA.WriteLine(tbHost.Text);
            commitSQLSettingsCA.WriteLine(tbPorta.Text);
            commitSQLSettingsCA.WriteLine(tbDataBase.Text);
            commitSQLSettingsCA.WriteLine(tbUsuario.Text);
            commitSQLSettingsCA.WriteLine(tbSenha.Text);

            //Fecha o arquivo
            commitSQLSettingsCA.Close();
            this.Close();
        }
    }
}
