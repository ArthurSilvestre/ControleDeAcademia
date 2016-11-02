using MySql.Data.MySqlClient;
using System.IO;

public class ConnectionDataBase{

    private string host;
    private string porta;
    private string database;
    private string usuario;
    private string senha;
    private MySqlConnection conexao;
    private string fileCommitSQLSettingsCA = "C:\\windows\\CommitSQLSettingsCA.ini";

    #region Construtores
        public ConnectionDataBase(string phost, string pporta, string pdatabase, string pusuario, string psenha){
            this.host = phost;
            this.porta = pporta;
            this.database = pdatabase;
            this.usuario = pusuario;
            this.senha = psenha;

            this.conexao = new MySqlConnection("Server = " + this.host + "; Port = " + porta + "; Database = " + database + "; Uid = " + usuario + ";Pwd = " + senha);
	    }

        public ConnectionDataBase(){
            StreamReader commitSQLSettingsCA = new StreamReader(fileCommitSQLSettingsCA);

            this.host = commitSQLSettingsCA.ReadLine();
            this.porta = commitSQLSettingsCA.ReadLine();
            this.database = commitSQLSettingsCA.ReadLine();
            this.usuario = commitSQLSettingsCA.ReadLine();
            this.senha = commitSQLSettingsCA.ReadLine();

            this.conexao = new MySqlConnection("Server = " + this.host + "; Port = " + porta + "; Database = " + database + "; Uid = " + usuario + ";Pwd = " + senha);

            commitSQLSettingsCA.Close();
        }
    #endregion

    #region Metodos
        public void openConnection(){
            this.conexao.Close();
            this.conexao.Open();
        }
        public void closeConnection(){
            this.conexao.Close();
        }
        public MySqlDataReader query(string sQuery){
            MySqlCommand command = new MySqlCommand(sQuery,conexao);
            return command.ExecuteReader();
        }
        public MySqlDataReader query(string sQuery,byte[] foto){
            MySqlCommand command = new MySqlCommand(sQuery, conexao);
            command.Parameters.Add("@foto", MySqlDbType.Blob).Value = foto;
            return command.ExecuteReader();
        }
    #endregion

    #region Get's and Set's
    public string gsHost{
            get{
                return host;
            }
            set{
                host = value;
            }
        }
        public string gsPorta{
            get{
                return porta;
            }
            set{
                porta = value;
            }
        }
        public string gsDatabase{
            get{
                return database;
            }
            set{
                database = value;
            }
        }
        public string gsUsuario{
            get{
                return usuario;
            }
            set{
                usuario = value;
            }
        }
        public string gsSenha{
            get{
                return senha;
            }
            set{
                senha = value;
            }
        }
        public MySqlConnection gsConexao{
            get{
                return conexao;
            }
            set{
                conexao = value;
            }
        }
    #endregion
}
