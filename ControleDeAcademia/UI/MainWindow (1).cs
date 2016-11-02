using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeAcademia{
    public partial class MainWindow : Form{
        private int widthScreen = Screen.PrimaryScreen.Bounds.Width;
        private int heightScreen = Screen.PrimaryScreen.Bounds.Height;

        public MainWindow(){
            InitializeComponent();
        }

        private void btnCadastrarAluno_Click(object sender, EventArgs e){
            CadastroAluno cadastroAluno = new CadastroAluno();
            cadastroAluno.ShowDialog();
        }

        private void btnCadastrarInstrutor_Click(object sender, EventArgs e){
            CadastroInstrutor cadastroInstrutor = new CadastroInstrutor();
            cadastroInstrutor.ShowDialog();
        }

        private void btnConsultaDeAlunos_Click(object sender, EventArgs e){
            ConsultaDeAlunos consultaAlunos = new ConsultaDeAlunos();
            consultaAlunos.ShowDialog();
        }

        private void btnConsultaDeInstrutores_Click(object sender, EventArgs e){
            ConsultaDeInstrutores consultaDeInstrutores = new ConsultaDeInstrutores();
            consultaDeInstrutores.ShowDialog();
        }

        private void btnCadastroDeDispositivos_Click(object sender, EventArgs e){
            CadastroDispositivos cadastroDispositivos = new CadastroDispositivos();
            cadastroDispositivos.ShowDialog();
        }

        private void btnCadastroDeUsuarios_Click(object sender, EventArgs e){
            CadastroUsuarios cadastroUsuarios = new CadastroUsuarios();
            cadastroUsuarios.ShowDialog();
        }

        private void btnCadastroDeCeps_Click(object sender, EventArgs e){
            CadastroCeps cadastroCeps = new CadastroCeps();
            cadastroCeps.ShowDialog();
        }

        private void paintSelectedButton(Button buttonToPaint){
            Button[] buttons = { btnModHome, btnModCadastros , btnModRelatorios, btnModConfig };

            for (int i=0; i < buttons.Length; i++){
                buttons[i].BackColor = Color.WhiteSmoke;
                buttons[i].FlatAppearance.BorderColor = SystemColors.WindowFrame;
                buttons[i].ForeColor = SystemColors.WindowFrame;
                buttons[i].UseVisualStyleBackColor = true;
            }

            buttonToPaint.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            buttonToPaint.FlatAppearance.BorderColor = Color.White;
            buttonToPaint.FlatAppearance.MouseDownBackColor = Color.Black;
            buttonToPaint.ForeColor = Color.White;
            buttonToPaint.UseVisualStyleBackColor = false;
        }

        private void MainWindow_Load(object sender, EventArgs e){
            Width = widthScreen;
            Height = Convert.ToInt32(heightScreen * 0.948);

            Location = new Point(0, 0);

            pbxHeader.Width = Width;
            pbxHeader.Controls.Add(lbTitle1);
            pbxHeader.Controls.Add(lbTitle2);

            lbTitle1.Location = new Point(0, Convert.ToInt32(pbxHeader.Height * 0.04));
            lbTitle2.Location = new Point(Convert.ToInt32(pbxHeader.Width * 0.10), Convert.ToInt32(pbxHeader.Height * 0.35));

        }

        private void btnModHome_Click(object sender, EventArgs e){
            paintSelectedButton(btnModHome);
        }

        private void btnModCadastros_Click(object sender, EventArgs e){
            paintSelectedButton(btnModCadastros);
        }

        private void btnModRelatorios_Click(object sender, EventArgs e){
            paintSelectedButton(btnModRelatorios);
        }

        private void btnModConfig_Click(object sender, EventArgs e){
            paintSelectedButton(btnModConfig);
        }

        private void btnSair_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
