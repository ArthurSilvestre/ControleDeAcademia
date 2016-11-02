using System;

namespace ControleDeAcademia{
    class Usuario {
        //Atributos
        private int deleted;
        private DateTime dtcadastro;
        private DateTime dtalteracao;
        private int codigo;
        private string id;
        private string senha;
        private int nivel;

        //Construtor
        public Usuario(int deleted, DateTime dtcadastro, DateTime dtalteracao, int codigo, string id, string senha, int nivel) {
            this.deleted = deleted;
            this.dtcadastro = dtcadastro;
            this.dtalteracao = dtalteracao;
            this.codigo = codigo;
            this.id = id;
            this.senha = senha;
            this.nivel = nivel;
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
        public string Id{
            get{
                return id;
            }
            set{
                id = value;
            }
        }
        public string Senha{
            get{
                return senha;
            }
            set{
                senha = value;
            }
        }
        public int Nivel{
            get{
                return nivel;
            }
            set{
                nivel = value;
            }
        }

    }
}
