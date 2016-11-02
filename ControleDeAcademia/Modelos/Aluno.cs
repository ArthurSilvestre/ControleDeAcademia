using System;

namespace ControleDeAcademia{
    class Aluno{
        //Atributos
        private int deleted;
        private DateTime dtcadastro;
        private DateTime dtalteracao;
        private int codigo;
        private string nome;
        private int cpf;
        private int rg;
        private byte[] foto;
        private DateTime dtnascimento;
        private int cep;
        private string estado;
        private string cidade;
        private string bairro;
        private string endereco;
        private int numero;
        private string complemento;
        private int dddtelefone;
        private int telefone;
        private int dddcelular1;
        private int celular1;
        private int dddcelular2;
        private int celular2;
        private int senha;
        private byte[] digitaldireita1;
        private byte[] digitaldireita2;
        private byte[] digitaldireita3;
        private byte[] digitaldireita4;
        private byte[] digitaldireita5;
        private byte[] digitalesquerda1;
        private byte[] digitalesquerda2;
        private byte[] digitalesquerda3;
        private byte[] digitalesquerda4;
        private byte[] digitalesquerda5;
        private int ativo;
        private int restrito;
        private TimeSpan horaentrada;
        private TimeSpan horasaida;

        //Construtor
        public Aluno(int deleted, DateTime dtcadastro, DateTime dtalteracao, int codigo, string nome, int cpf, int rg, byte[] foto, DateTime dtnascimento, int cep, string estado, string cidade, string bairro, string endereco, int numero, string complemento, int dddtelefone, int telefone, int dddcelular1, int celular1, int dddcelular2, int celular2, int senha, byte[] digitaldireita1, byte[] digitaldireita2, byte[] digitaldireita3, byte[] digitaldireita4, byte[] digitaldireita5, byte[] digitalesquerda1, byte[] digitalesquerda2, byte[] digitalesquerda3, byte[] digitalesquerda4, byte[] digitalesquerda5, int ativo, int restrito, TimeSpan horaentrada, TimeSpan horasaida){
            this.deleted = deleted;
            this.dtcadastro = dtcadastro;
            this.dtalteracao = dtalteracao;
            this.codigo = codigo;
            this.nome = nome;
            this.cpf = cpf;
            this.rg = rg;
            this.foto = foto;
            this.dtnascimento = dtnascimento;
            this.cep = cep;
            this.estado = estado;
            this.cidade = cidade;
            this.bairro = bairro;
            this.endereco = endereco;
            this.numero = numero;
            this.complemento = complemento;
            this.dddtelefone = dddtelefone;
            this.telefone = telefone;
            this.dddcelular1 = dddcelular1;
            this.celular1 = celular1;
            this.dddcelular2 = dddcelular2;
            this.celular2 = celular2;
            this.senha = senha;
            this.digitaldireita1 = digitaldireita1;
            this.digitaldireita2 = digitaldireita2;
            this.digitaldireita3 = digitaldireita3;
            this.digitaldireita4 = digitaldireita4;
            this.digitaldireita5 = digitaldireita5;
            this.digitalesquerda1 = digitalesquerda1;
            this.digitalesquerda2 = digitalesquerda2;
            this.digitalesquerda3 = digitalesquerda3;
            this.digitalesquerda4 = digitalesquerda4;
            this.digitalesquerda5 = digitalesquerda5;
            this.ativo = ativo;
            this.restrito = restrito;
            this.horaentrada = horaentrada;
            this.horasaida = horasaida;
        }
        public Aluno(){}

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
        public string Nome{
            get{
                return nome;
            }
            set{
                nome = value;
            }
        }
        public int Cpf{
            get{
                return cpf;
            }
            set{
                cpf = value;
            }
        }
        public int Rg{
            get{
                return rg;
            }
            set{
                rg = value;
            }
        }
        public byte[] Foto{
            get{
                return foto;
            }
            set{
                foto = value;
            }
        }
        public DateTime Dtnascimento{
            get{
                return dtnascimento;
            }
            set{
                dtnascimento = value;
            }
        }
        public int Cep{
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
        public int Dddcelular1{
            get{
                return dddcelular1;
            }
            set{
                dddcelular1 = value;
            }
        }
        public int Celular1{
            get{
                return celular1;
            }
            set{
                celular1 = value;
            }
        }
        public int Dddcelular2{
            get{
                return dddcelular2;
            }
            set{
                dddcelular2 = value;
            }
        }
        public int Celular2{
            get{
                return celular2;
            }
            set{
                celular2 = value;
            }
        }
        public int Senha{
            get{
                return senha;
            }
            set{
                senha = value;
            }
        }
        public byte[] Digitaldireita1{
            get{
                return digitaldireita1;
            }
            set{
                digitaldireita1 = value;
            }
        }
        public byte[] Digitaldireita2{
            get{
                return digitaldireita2;
            }
            set{
                digitaldireita2 = value;
            }
        }
        public byte[] Digitaldireita3{
            get{
                return digitaldireita3;
            }
            set{
                digitaldireita3 = value;
            }
        }
        public byte[] Digitaldireita4{
            get{
                return digitaldireita4;
            }
            set{
                digitaldireita4 = value;
            }
        }
        public byte[] Digitaldireita5{
            get{
                return digitaldireita5;
            }
            set{
                digitaldireita5 = value;
            }
        }
        public byte[] Digitalesquerda1{
            get{
                return digitalesquerda1;
            }
            set{
                digitalesquerda1 = value;
            }
        }
        public byte[] Digitalesquerda2{
            get{
                return digitalesquerda2;
            }
            set{
                digitalesquerda2 = value;
            }
        }
        public byte[] Digitalesquerda3{
            get{
                return digitalesquerda3;
            }
            set{
                digitalesquerda3 = value;
            }
        }
        public byte[] Digitalesquerda4{
            get{
                return digitalesquerda4;
            }
            set{
                digitalesquerda4 = value;
            }
        }
        public byte[] Digitalesquerda5{
            get{
                return digitalesquerda5;
            }
            set{
                digitalesquerda5 = value;
            }
        }
        public int Ativo{
            get{
                return ativo;
            }
            set{
                ativo = value;
            }
        }
        public int Restrito{
            get{
                return restrito;
            }
            set{
                restrito = value;
            }
        }
        public TimeSpan Horaentrada{
            get{
                return horaentrada;
            }
            set{
                horaentrada = value;
            }
        }
        public TimeSpan Horasaida{
            get{
                return horasaida;
            }
            set{
                horasaida = value;
            }
        }
    }
}
