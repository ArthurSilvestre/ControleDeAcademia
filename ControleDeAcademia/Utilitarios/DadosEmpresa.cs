using MySql.Data.MySqlClient;
using System;

namespace ControleDeAcademia{
    class DadosEmpresa {
        //Atributos
        private DateTime dtalteracao;
        private string key;
        private byte[] logo;
        private string razaosocial;
        private string nomefantasia;
        private int cnpj;
        private int inscricaoestadual;
        private int inscricaomunicipal;
        private int cep;
        private string estado;
        private string cidade;
        private string bairro;
        private string endereco;
        private int numero;
        private string complemento;
        private int dddtelefone;
        private int telefone;
        private string email;
        private ConnectionDataBase connectionDataBase = new ConnectionDataBase();

        //Construtor
        public DadosEmpresa(){
            try{
                connectionDataBase.openConnection();
                MySqlDataReader results = connectionDataBase.query("select * from dadosEmpresa");

                if (results.Read()){
                    this.dtalteracao = results.GetDateTime(0);
                    this.key = results.GetString(1);
                    this.logo = getLogo(results);
                    this.razaosocial = results.GetString(3);
                    this.nomefantasia = results.GetString(4);
                    this.cnpj = results.GetInt32(5);
                    this.inscricaoestadual = results.GetInt32(6);
                    this.inscricaomunicipal = results.GetInt32(7);
                    this.cep = results.GetInt32(8);
                    this.estado = results.GetString(9);
                    this.cidade = results.GetString(10);
                    this.bairro = results.GetString(11);
                    this.endereco = results.GetString(12);
                    this.numero = results.GetInt32(13);
                    this.complemento = results.GetString(14);
                    this.dddtelefone = results.GetInt32(15);
                    this.telefone = results.GetInt32(16);
                    this.email = results.GetString(17);
                }
            }catch{}

            connectionDataBase.closeConnection();
        }

        public DadosEmpresa(DateTime dtalteracao, string key, byte[] logo, string razaosocial, string nomefantasia, int cnpj, int inscricaoestadual, int inscricaomunicipal, int cep, string estado, string cidade, string bairro, string endereco, int numero, string complemento, int dddtelefone, int telefone, string email){
            this.dtalteracao = dtalteracao;
            this.key = key;
            this.logo = logo;
            this.razaosocial = razaosocial;
            this.nomefantasia = nomefantasia;
            this.cnpj = cnpj;
            this.inscricaoestadual = inscricaoestadual;
            this.inscricaomunicipal = inscricaomunicipal;
            this.cep = cep;
            this.estado = estado;
            this.cidade = cidade;
            this.bairro = bairro;
            this.endereco = endereco;
            this.numero = numero;
            this.complemento = complemento;
            this.dddtelefone = dddtelefone;
            this.telefone = telefone;
            this.email = email;
        }

        //Metodos
        private byte[] getLogo(MySqlDataReader results){
            int lengthlogobuffer = (int)results.GetBytes(2, 0, null, 0, 0);
            byte[] logobuffer = new byte[lengthlogobuffer];
            int bytesRead;

            if (lengthlogobuffer > 0){
                for (int index = 0; index < lengthlogobuffer; index += bytesRead)
                    bytesRead = (int)results.GetBytes(2, index, logobuffer, index, lengthlogobuffer - index);
            }
            return logobuffer;
        }

        //Get's e Set's
        public DateTime Dtalteracao{
            get{
                return dtalteracao;
            }
            set{
                dtalteracao = value;
            }
        }
        public string Key{
            get{
                return key;
            }
            set{
                key = value;
            }
        }
        public byte[] Logo{
            get{
                return logo;
            }
            set{
                logo = value;
            }
        }
        public string Razaosocial{
            get{
                return razaosocial;
            }
            set{
                razaosocial = value;
            }
        }
        public string Nomefantasia{
            get{
                return nomefantasia;
            }
            set{
                nomefantasia = value;
            }
        }
        public int Cnpj{
            get{
                return cnpj;
            }
            set{
                cnpj = value;
            }
        }
        public int Inscricaoestadual{
            get{
                return inscricaoestadual;
            }
            set{
                inscricaoestadual = value;
            }
        }
        public int Inscricaomunicipal{
            get{
                return inscricaomunicipal;
            }
            set{
                inscricaomunicipal = value;
            }
        }
        public int CEP{
            get{
                return cep;
            }
            set{
                cep = value;
            }
        }
        public string Estado{
            get{
                return estado;
            }
            set{
                estado = value;
            }
        }
        public string Cidade{
            get{
                return cidade;
            }
            set{
                cidade = value;
            }
        }
        public string Bairro{
            get{
                return bairro;
            }
            set{
                bairro = value;
            }
        }
        public string Endereco{
            get{
                return endereco;
            }
            set{
                endereco = value;
            }
        }
        public int Numero{
            get{
                return numero;
            }
            set{
                numero = value;
            }
        }
        public string Complemento{
            get{
                return complemento;
            }
            set{
                complemento = value;
            }
        }
        public int Dddtelefone{
            get{
                return dddtelefone;
            }
            set{
                dddtelefone = value;
            }
        }
        public int Telefone{
            get{
                return telefone;
            }
            set{
                telefone = value;
            }
        }
        public string Email{
            get{
                return email;
            }
            set{
                email = value;
            }
        }
    }
}
