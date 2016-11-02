using System;

namespace ControleDeAcademia{
    class Cep{
        //Atributos
        private int deleted;
        private DateTime dtcadastro;
        private DateTime dtalteracao;
        private int cep;
        private string logradouro;
        private string cidade;
        private string bairro;
        private string estado;
        private string abreviacao;

        //Construtor
        public Cep(int deleted, DateTime dtcadastro, DateTime dtalteracao, int cep, string logradouro, string cidade, string bairro, string estado, string abreviacao){
            this.deleted = deleted;
            this.dtcadastro = dtcadastro;
            this.dtalteracao = dtalteracao;
            this.cep = cep;
            this.logradouro = logradouro;
            this.cidade = cidade;
            this.bairro = bairro;
            this.estado = estado;
            this.abreviacao = abreviacao;
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
        public int CEP{
            get{
                return cep;
            }
            set{
                cep = value;
            }
        }
        public string Logradouro{
            get{
                return logradouro;
            }
            set{
                logradouro = value;
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
        public string Estado{
            get{
                return estado;
            }
            set{
                estado = value;
            }
        }
        public string Abreviacao{
            get{
                return abreviacao;
            }
            set{
                abreviacao = value;
            }
        }
    }
}
