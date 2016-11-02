using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security;

namespace ControleDeAcademia{
    public class CommitFunctions{
        private static string[] estados = { "PB", "PE", "SP", "DF", "RJ", "GO", "RN", "MG", "ES", "PR", "CE", "BA", "SC", "PI", "AM", "RS", "SE", "AL", "AC", "MA", "MT", "PA", "PO", "PR", "MS", "TO", "EX" };
        private static string[] grausDeInstrucoes = GrauDeInstrucao.getGrausDeInstrucoes();
        private static int[] valuesGrausDeInstrucoes = GrauDeInstrucao.getValuesGrausDeInstrucoes();

        public static void addDadosCombobox(string[] dados, ComboBox comboBox){
            DataTable dataTable = new DataTable();
            DataColumn colunaId = new DataColumn("ID");
            DataColumn colunaDescricao = new DataColumn("Descricao");

            dataTable.Columns.Add(colunaId);
            dataTable.Columns.Add(colunaDescricao);

            dataTable.Rows.Add(-1, "");
            for (int i = 0; i < dados.Length; i++){
                dataTable.Rows.Add(i, dados[i]);
            }

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "Descricao";
            comboBox.ValueMember = "ID";
        }
        public static void addDadosCombobox(string[] dados, ComboBox comboBox, int[] values){
            DataTable dataTable = new DataTable();
            DataColumn colunaId = new DataColumn("ID");
            DataColumn colunaDescricao = new DataColumn("Descricao");

            dataTable.Columns.Add(colunaId);
            dataTable.Columns.Add(colunaDescricao);

            dataTable.Rows.Add(-1, "");
            for (int i = 0; i < dados.Length; i++){
                dataTable.Rows.Add(values[i], dados[i]);
            }

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "Descricao";
            comboBox.ValueMember = "ID";
        }

        public static Image resizeImage(Image imgToResize, Size size){
            return (Image)(new Bitmap(imgToResize, size));
        }

        public static Bitmap ResizeImage(Image image, int width, int height){
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static byte[] getImageFromDataBase(MySqlDataReader results,int position){
            int lengthlogobuffer = (int)results.GetBytes(position, 0, null, 0, 0);
            byte[] logobuffer = new byte[lengthlogobuffer];
            int bytesRead;

            if (lengthlogobuffer > 0){
                for (int index = 0; index < lengthlogobuffer; index += bytesRead)
                    bytesRead = (int)results.GetBytes(position, index, logobuffer, index, lengthlogobuffer - index);
            }
            return logobuffer;
        }

        public static GraphicsPath BorderRadius(Rectangle pRect, int pCanto, bool pTopo, bool pBase){
            GraphicsPath gp = new GraphicsPath();

            if (pTopo){
                gp.AddArc(pRect.X - 1, pRect.Y - 1, pCanto, pCanto, 180, 90);
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y - 1, pCanto, pCanto, 270, 90);
            } else {
                // Se não arredondar o topo, adiciona as linhas para poder fechar o retangulo junto com
                // a base arredondada
                gp.AddLine(pRect.X - 1, pRect.Y - 1, pRect.X + pRect.Width, pRect.Y - 1);
            }

            if (pBase){
                gp.AddArc(pRect.X + pRect.Width - pCanto, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 0, 90);
                gp.AddArc(pRect.X - 1, pRect.Y + pRect.Height - pCanto, pCanto, pCanto, 90, 90);
            } else {
                // Se não arredondar a base, adiciona as linhas para poder fechar o retangulo junto com
                // o topo arredondado. Adiciona da direita para esquerda pois é na ordem contrária que 
                // foi adicionado os arcos do topo. E pra fechar o retangulo tem que desenhar na ordem :
                //  1 - Canto Superior Esquerdo
                //  2 - Canto Superior Direito
                //  3 - Canto Inferior Direito 
                //  4 - Canto Inferior Esquerdo.
                gp.AddLine(pRect.X + pRect.Width, pRect.Y + pRect.Height, pRect.X - 1, pRect.Y + pRect.Height);
            }

            return gp;
        }

        /// Tenta ler a chave do registro, caso nao exista, serah criada automaticamente./// 
        public static void checkRegistryKey1(string sKeyname){
            RegistryKey oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + sKeyname, true);

            if (oRegistryKey == null){
                oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                oRegistryKey.CreateSubKey(sKeyname);
            }
        }

        /// Verifica a existencide um valor string no caminho fornecido, Caso nao achado, adiciono valor padrao provido/// 
        public static string getStringValue1(string sKeyname, string sValueName, string sDefaultValue){
            RegistryKey oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + sKeyname, true);

            if (oRegistryKey == null){
                oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                oRegistryKey.CreateSubKey(sKeyname);
            }

            if (oRegistryKey.GetValue(sValueName) == null){
                oRegistryKey.SetValue(sValueName, sDefaultValue);
                return sDefaultValue;
            } else
                return (string)oRegistryKey.GetValue(sValueName);
        }

        /// Configura um valor string para a chave dada /// 
        public static void setStringValue1(string sKeyname, string sValueName, string sValue){
            RegistryKey oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + sKeyname, true);

            if (oRegistryKey == null){
                oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                oRegistryKey.CreateSubKey(sKeyname);
            }

            oRegistryKey.SetValue(sValueName, sValue);
        }

        //Get's e Set's
        public static string[] Estados{
            get{
                return estados;
            }
        }

        public static string[] GrauDeInstrucoes{
            get{
                return grausDeInstrucoes;
            }
        }

        public static int[] ValuesGrausDeInstrucoes{
            get{
                return valuesGrausDeInstrucoes;
            }
        }
    }
}
