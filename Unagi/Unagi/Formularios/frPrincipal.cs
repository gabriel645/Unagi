using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace Unagi.Formularios
{
    public partial class frPrincipal : Form
    {
        public frPrincipal()
        {
            InitializeComponent();
            Player();

        }

        static void Atualizar()
        {
           // if (File.Exists("playlists.txt")) // primeiro verifica se ele existew
             //   string[] linhas = File.ReadAllLines("C:\\dados.txt"); //tudo lido num vetor (cada linha numa posicao)

        }

        public void Player()
        {
            //axWindowsMediaPlayer1.newPlaylist("foto", @"C:\Users\Sabrina\Downloads\ibagens\13254529_712710388831369_6742972320372427324_n");
            axWindowsMediaPlayer1.URL = @"C:\Users\Sabrina\Music\Foster the People\Torches\02-Pumped Up Kicks.m4a";
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.Ctlcontrols.stop();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            frCadastro telaCadastro = new frCadastro();
            telaCadastro.Location = new Point(77, 137);
            telaCadastro.ShowDialog();
        }

        private void frPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frGerenciarPlaylist telaPlaylist = new frGerenciarPlaylist();
            telaPlaylist.Location = new Point(77, 137);
            telaPlaylist.ShowDialog();
        }

        private void bFDFD_Click(object sender, EventArgs e)
        {
            frSobre telaSobre = new frSobre();
            telaSobre.Location = new Point(77, 137);
            telaSobre.ShowDialog();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
        }
    }
}
