using EasyInnerSDK.Entity;
using EasyInnerSDK.UI;
using NBioBSPCOMLib;
using NITGEN.SDK.NBioBSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcademia{
    public class ConnectionTopDataDevices{

        public static byte[] capturarDigital(){
            NBioAPI m_NBioAPI = new NBioAPI();
            NBioAPI.Type.FIR NewFIR;
            NBioAPI.Type.HFIR hNewFIR;

            inicializarDispositivo(m_NBioAPI);

            m_NBioAPI.Capture(out hNewFIR);
            m_NBioAPI.GetFIRFromHandle(hNewFIR, out NewFIR);

            FecharDispositivo(m_NBioAPI);

            return NewFIR.Data;
        }

        public static void inicializarDispositivo(NBioAPI m_NBioAPI) {
            uint ret = m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            if (!(ret == NBioAPI.Error.NONE)) MessageBox.Show("Não foi possível inicializar o leitor.");
        }

        public static void FecharDispositivo(NBioAPI m_NBioAPI) {
            uint ret = m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            if (!(ret == NBioAPI.Error.NONE)) MessageBox.Show("Não foi possível finalizar o leitor.");
        }

        public static bool compararDigitais(byte[] digital1, byte[] digital2) {
            bool result = false;
            NBioAPI m_NBioAPI = new NBioAPI();
            NBioAPI.Type.FIR_PAYLOAD myPayload = new NBioAPI.Type.FIR_PAYLOAD();

            NBioAPI.Type.FIR NewFIR1 = new NBioAPI.Type.FIR();
            NewFIR1.Data = digital1;

            NBioAPI.Type.FIR NewFIR2 = new NBioAPI.Type.FIR();
            NewFIR2.Data = digital1;

            uint retVerifica = m_NBioAPI.VerifyMatch(NewFIR1, NewFIR2, out result, myPayload);

            if (retVerifica != NBioAPI.Error.NONE){
                MessageBox.Show("Erro na verificação!");
                return false;
            }

            if (result){
                MessageBox.Show("Digitais conferem");
                return true;
            } else {
                MessageBox.Show("Digitais não conferem");
                return false;
            }
        }
        
        #region Importação das funções da dll EasyInner.dll
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirTipoConexao(byte Tipo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte AbrirPortaComunicacao(int Porta);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern void FecharPortaComunicacao();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirPadraoCartao(byte Padrao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte AcionarRele1(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte AcionarRele2(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarComandoAcessoNegado(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ManterRele1Acionado(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ManterRele2Acionado(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DesabilitarRele1(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DesabilitarRele2(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte AcionarBipCurto(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte AcionarBipLongo(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte Ping(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LigarBackLite(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DesligarBackLite(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LigarBipIntermitente(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DesligarBipIntermitente(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LiberarCatracaEntrada(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LiberarCatracaSaida(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LiberarCatracaEntradaInvertida(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LiberarCatracaSaidaInvertida(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LiberarCatracaDoisSentidos(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DevolverCartao(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitorProximidadeHIDAbaTrack2();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitorProximidadeMotorolaAbaTrack2();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitorProximidadeWiegand();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitorProximidadeSmartCard();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitorProximidadeAcura();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitorProximidadeWiegandFacilityCode();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitorProximidadeSmartCardAcura();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarInnerOffLine();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarInnerOnLine();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte HabilitarTeclado(byte Habilita, byte Ecoar);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarAcionamento1(byte Funcao, byte Tempo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarAcionamento2(byte Funcao, byte Tempo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarTipoLeitor(byte Tipo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitor1(byte Operacao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarLeitor2(byte Operacao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirCodigoEmpresa(int Codigo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirNivelAcesso(byte Nivel);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte UtilizarSenhaAcesso(byte Utiliza);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirTipoListaAcesso(byte Tipo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirQuantidadeDigitosCartao(byte Quantidade);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte AvisarQuandoMemoriaCheia(byte Avisa);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirPorcentagemRevista(byte Porcentagem);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte RegistrarAcessoNegado(byte TipoRegistro);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte CartaoMasterLiberaAcesso(byte Libera);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirLogicaRele(byte Logica);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DesabilitarBloqueioCatracaMicroSwitch(byte Desabilita);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirFuncaoDefaultLeitoresProximidade(byte Funcao);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirNumeroCartaoMaster(string Master);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirFormasPictogramasMillenium(byte Forma);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DesabilitarBipCatraca(byte Desabilita);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirEventoSensor(byte Sensor, byte Evento, byte Tempo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte PermitirCadastroInnerBioVerid(byte Permite);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberDataHoraDadosOnLine(byte Recebe);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte InserirQuantidadeDigitoVariavel(byte Digito);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarWiegandDoisLeitores(byte Habilita, byte ExibirMensagem);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirFuncaoDefaultSensorBiometria(byte Funcao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarConfiguracoes(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarRelogio(int Inner, byte Dia, byte Mes, byte Ano, byte Hora, byte Minuto, byte Segundo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberRelogio(int Inner, ref byte Dia, ref byte Mes, ref byte Ano, ref byte Hora, ref byte Minuto, ref byte Segundo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarHorarioVerao(int Inner, byte DiaInicio, byte MesInicio, byte AnoInicio, byte HoraInicio, byte MinutoInicio, byte DiaFim, byte MesFim, byte AnoFim, byte HoraFim, byte MinutoFim);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ApagarHorariosAcesso(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte InserirHorarioAcesso(byte Horario, byte DiaSemana, byte FaixaDia, byte Hora, byte Minuto);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarHorariosAcesso(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ApagarListaAcesso(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte InserirUsuarioListaAcesso(string Cartao, byte Horario);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarListaAcesso(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarMensagemPadraoOnLine(int Inner, byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarMensagemTemporariaOnLine(int Inner, byte ExibirData, string Mensagem, byte Tempo);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirMensagemEntradaOffLine(byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirMensagemSaidaOffLine(byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirMensagemPadraoOffLine(byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirMensagemFuncaoOffLine(string Mensagem, byte Funcao, byte Habilitada);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte HabilitarScoreMensagemOffLine(int Inner, byte Tipo, byte Habilitar);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarMensagensOffLine(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ApagarMensagensOffLine(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ApagarHorariosSirene(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte InserirHorarioSirene(byte Hora, byte Minuto, byte Segunda, byte Terca, byte Quarta, byte Quinta, byte Sexta, byte Sabado, byte DomingoFeriado);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarHorariosSirene(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte ColetarBilhete(int Inner, ref byte Tipo, ref byte Dia, ref byte Mes, ref byte Ano, ref byte Hora, ref byte Minuto, StringBuilder Cartao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarFormasEntradasOnLine(int Inner, byte QtdeDigitosTeclado, byte
            EcoTeclado, byte FormaEntrada, byte TempoTeclado, byte PosicaoCursorTeclado);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberDadosOnLine(int Inner, ref byte Origem, ref byte Complemento, StringBuilder Cartao, ref byte Dia, ref byte Mes, ref byte Ano, ref byte Hora, ref byte Minuto, ref byte Segundo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LerSensoresInner(int Inner, ref byte StatusSensor1, ref byte StatusSensor2, ref byte StatusSensor3);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarMensagemImpressora00(int Inner, string Mensagem);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarMensagemImpressoraFF(int Inner, string Mensagem);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte HabilitarMudancaOnLineOffLine(byte Habilita, byte Tempo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirEntradasMudancaOffLine(byte Teclado, byte Leitor1, byte Leitor2, byte Catraca);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirMensagemPadraoMudancaOffLine(byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirMensagemPadraoMudancaOnLine(byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirEntradasMudancaOnLine(byte Entrada);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirConfiguracaoTecladoOnLine(byte Digitos, byte EcoDisplay, byte Tempo, byte PosicaoCursor);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarConfiguracoesMudancaAutomaticaOnLineOffLine(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte HabilitarScoreFuncoes(int Funcao, byte Score);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte DefinirConfiguracoesFuncoes(byte Funcao, byte Catraca, byte Rele1, byte Rele2, byte Lista, byte Biometria);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarConfiguracoesFuncoes(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarModeloBio(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberModeloBio(int Inner, byte OnLine, ref int Modelo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarVersaoBio(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberVersaoBio(int Inner, byte OnLine, ref int VersaoAlta, ref int VersaoBaixa);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarQuantidadeUsuariosBio(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberQuantidadeUsuariosBio(int Inner, byte OnLine, ref int Quantidade);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern void InicializarColetaListaUsuariosBio();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarListaUsuariosBio(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberPacoteListaUsuariosBio(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberUsuarioLista(int Inner, StringBuilder Usuario);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern int TemProximoUsuario();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern int TemProximoPacote();
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern void SetarBioLight(int Light);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarUsuarioCadastradoBio(int Inner, string Usuario);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberUsuarioCadastradoBio(int Inner, byte OnLine, byte[] Template);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarExclusaoUsuario(int Inner, string Usuario);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte UsuarioFoiExcluido(int Inner, byte OnLine);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte InserirUsuarioLeitorBio(int Inner, byte Tipo, string Usuario);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoInsercaoUsuarioLeitorBio(int Inner, byte OnLine);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte FazerVerificacaoBiometricaBio(int Inner, string Usuario);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoVerificacaoBiometrica(int Inner, byte OnLine);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte FazerIdentificacaoBiometricaBio(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoIdentificacaoBiometrica(int Inner, byte OnLine, StringBuilder Usuario);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarTemplateLeitor(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberTemplateLeitor(int Inner, byte OnLine, byte[] Template);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarBio(int Inner, byte HabilitaIdentificacao, byte HabilitaVerificacao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoConfiguracaoBio(int Inner, byte OnLine);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarUsuarioBio(int Inner, Byte[] Template);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte UsuarioFoiEnviado(int Inner, byte OnLine);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte CompararDigitalLeitor(int Inner, Byte[] Template);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoComparacaoDigitalLeitor(int Inner, byte OnLine);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte IncluirUsuarioSemDigitalBio(string Cartao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarListaUsuariosSemDigitalBio(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern int EnviarStringInicializacaoModem(string Str);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern int LerByteModem();
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern int ConectarModem(int Porta, string Str, int Tom, string Telefone, int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern void SetarInnerOld(int Old);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte ReceberVersaoFirmware(int Inner, ref byte Linha, ref short Variacao, ref byte VersaoAlta, ref byte VersaoBaixa, ref byte VersaoSufixo, ref byte InnerAcessoBio);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarAjustesSensibilidadeBio(int Inner, byte Ganho, byte Brilho, byte Contraste);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarAjustesQualidadeBio(int Inner, byte Registro, byte Verificacao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarAjustesSegurancaBio(int Inner, byte Identificacao, byte Verificacao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarCapturaAdaptativaBio(int Inner, byte Capturar, byte Total, byte Tempo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarFiltroBio(int Inner, byte Habilitar);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarAjustesBio(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoEnvioAjustesBio(int Inner, byte OnLine);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte IncluirUsuarioVerid(int Inner, Byte[] Template);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoInclusaoUsuarioVerid(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte CompararTemplateVerid(int Inner, Byte[] Template);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoComparacaoTemplateVerid(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte CriarUsuarioLeitorVerid(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoInclusaoUsuarioLeitorVerid(int Inner, Byte[] Template);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte SolicitarTotalUsuariosVerid(int Inner, byte Modo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberTotalUsuariosVerid(int Inner, ref int Total);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LocalizarPrimeiroUsuarioVerid(int Inner, byte Modo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte LocalizarProximoUsuarioVerid(int Inner, byte Modo);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte LocalizarUsuarioVerid(int Inner, byte Modo, byte Digitos, string Cartao);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte ReceberUsuarioVerid(int Inner, byte Modo, ref byte Digitos, Byte[] Template, string Cartao);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte ApagarUsuarioVerid(int Inner, string Cartao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoExclusaoUsuarioVerid(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte ApagarTodosUsuariosVerid(int Inner, string SenhaAdm);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoExclusaoTodosUsuariosVerid(int Inner);
            [DllImport("EasyInner.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Winapi)]
            private static extern byte CompararPINVerid(int Inner, string Cartao);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoComparacaoPINVerid(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ConfigurarRedeVerid(int Inner, byte Envia, byte Recebe, byte BroadCast);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte ResultadoConfiguracaoRedeVerid(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte PreencherBufferTLM(string Caminho);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte EnviarBufferTLM(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            private static extern byte HabilitarCriptografia(byte Tipo);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte HabilitaMudancaEventoSeta(byte Habilita);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte DefinirMensagemApresentacaoEntrada(byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte DefinirMensagemApresentacaoSaida(byte ExibirData, string Mensagem);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte EnviarBufferEventosMudancaAuto(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte InserirHorarioMudancaEntrada(byte Hora1, byte Minuto1, byte Hora2, byte Minuto2, byte Hora3, byte Minuto3);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte InserirHorarioMudancaSaida(byte Hora1, byte Minuto1, byte Hora2, byte Minuto2, byte Hora3, byte Minuto3);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte LigarLedVermelho(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern byte DesligarLedVermelho(int Inner);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern int ReceberQuantidadeBilhetes(int Inner, int[] QtdeBilhetes);
            [DllImport("EasyInner.dll", CallingConvention = CallingConvention.Winapi)]
            public static extern int DefinirEntradasMudancaOffLineComBiometria(int Inner);
        #endregion
    }
}
