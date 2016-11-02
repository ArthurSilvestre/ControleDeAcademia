using System;

namespace ControleDeAcademia{
    class Dispositivo{
        //Atributos
        private int deleted;
        private DateTime dtcadastro;
        private DateTime dtalteracao;
        private int codigo;
        private int numeroinner;
        private int porta;
        private int tipoconexao;
        private int tipoleitor;
        private int padraocartao;
        private int tipoequipamento;
        private int sentido;

        //Construtor
        public Dispositivo(int deleted, DateTime dtcadastro, DateTime dtalteracao, int codigo, int numeroinner, int porta, int tipoconexao, int tipoleitor, int padraocartao, int tipoequipamento, int sentido){
            this.deleted = deleted;
            this.dtcadastro = dtcadastro;
            this.dtalteracao = dtalteracao;
            this.codigo = codigo;
            this.numeroinner = numeroinner;
            this.porta = porta;
            this.tipoconexao = tipoconexao;
            this.tipoleitor = tipoleitor;
            this.padraocartao = padraocartao;
            this.tipoequipamento = tipoequipamento;
            this.sentido = sentido;
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
        public int Numeroinner{
            get{
                return numeroinner;
            }
            set{
                numeroinner = value;
            }
        }
        public int Porta{
            get{
                return porta;
            }
            set{
                porta = value;
            }
        }
        public int Tipoconexao{
            get{
                return tipoconexao;
            }
            set{
                tipoconexao = value;
            }
        }
        public int Tipoleitor{
            get{
                return tipoleitor;
            }
            set{
                tipoleitor = value;
            }
        }
        public int Padraocartao{
            get{
                return padraocartao;
            }
            set{
                padraocartao = value;
            }
        }
        public int Tipoequipamento{
            get{
                return tipoequipamento;
            }
            set{
                tipoequipamento = value;
            }
        }
        public int Sentido{
            get{
                return sentido;
            }
            set{
                sentido = value;
            }
        }

    }
}
