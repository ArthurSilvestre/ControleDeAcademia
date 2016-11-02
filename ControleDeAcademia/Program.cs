using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace ControleDeAcademia{
    static class Program{
        [STAThread]
        static void Main(){
            //CommitFunctions.checkRegistryKey1("ControleDeAcademia");

            LicenseKey licenseKey = new LicenseKey();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists("C:\\windows\\CommitSQLSettingsCA.ini")){
                MessageBox.Show("Primeiro acesso, favor configurar banco dados.");
                Application.Run(new CommitMySqlSettings());
            }

            Application.Run(new loginScreen());

            Application.Run(new MainWindow());

            //Application.Run(new Backup());

            #region Códigos exemplos
            //List<string> list = new List<string>();
            //list.Add("one");
            //list.Add("two");
            //list.Add("three");
            //string[] array = list.ToArray();

            //while (results.Read()){
            //MessageBox.Show(results.GetString(0));
            //MessageBox.Show(results.GetString(1));
            //}

            //DadosEmpresa d = new DadosEmpresa();

            //MemoryStream ms = new MemoryStream(d.Logo);
            //Image I = Image.FromStream(ms);

            //pictureBox1.Image = I;

            //private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
            //{
            //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            //    {
            //        e.Handled = true;
            //    }
            //}
            #endregion
        }
    }
}
