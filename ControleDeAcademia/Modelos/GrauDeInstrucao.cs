using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControleDeAcademia{
    class GrauDeInstrucao{
        //Atributos
        private int deleted;
        private DateTime dtcadastro;
        private DateTime dtalteracao;
        private int codigo;
        private string grau;
        private int sefip;
        private int caged;
        private int rais;
        private static ConnectionDataBase connectionDataBase = new ConnectionDataBase();

        //Construtor
        public GrauDeInstrucao(int deleted, DateTime dtcadastro, DateTime dtalteracao, int codigo, string grau, int sefip, int caged, int rais){
            this.deleted = deleted;
            this.dtcadastro = dtcadastro;
            this.dtalteracao = dtalteracao;
            this.codigo = codigo;
            this.grau = grau;
            this.sefip = sefip;
            this.caged = caged;
            this.rais = rais;
        }

        //Metodos
        public static string[] getGrausDeInstrucoes(){
            List<string> grausDeInstrucoes = new List<string>();

            try{
                connectionDataBase.openConnection();
                MySqlDataReader results = connectionDataBase.query("Select grau from cadastrosgrausdeinstrucoes where deleted = 0");

                while (results.Read())
                    grausDeInstrucoes.Add(results.GetString(0));

            } catch {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.2");
            }
            connectionDataBase.closeConnection();

            return grausDeInstrucoes.ToArray();
        }

        public static int[] getValuesGrausDeInstrucoes(){
            List<int> grausDeInstrucoes = new List<int>();

            try{
                connectionDataBase.openConnection();
                MySqlDataReader results = connectionDataBase.query("Select codigo from cadastrosgrausdeinstrucoes where deleted = 0");

                while (results.Read())
                    grausDeInstrucoes.Add(results.GetInt32(0));

            } catch (Exception xe) {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados.1");
                MessageBox.Show(xe.Message);
            }
            connectionDataBase.closeConnection();

            return grausDeInstrucoes.ToArray();
        }

        //Get's e Set's
        public int Deleted{
            get{
                return deleted;
            }
            set{
                deleted = value;
            }
        }
        public DateTime Dtcadastro{
            get{
                return dtcadastro;
            }
            set{
                dtcadastro = value;
            }
        }
        public DateTime Dtalteracao{
            get{
                return dtalteracao;
            }
            set{
                dtalteracao = value;
            }
        }
        public int Codigo{
            get{
                return codigo;
            }
            set{
                codigo = value;
            }
        }
        public string Grau{
            get{
                return grau;
            }
            set{
                grau = value;
            }
        }
        public int Sefip{
            get{
                return sefip;
            }
            set{
                sefip = value;
            }
        }
        public int Caged{
            get{
                return caged;
            }
            set{
                caged = value;
            }
        }
        public int Rais{
            get{
                return rais;
            }
            set{
                rais = value;
            }
        }

    }
}
