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
using Unagi.Classes;
using Unagi.Estrutura;

namespace Unagi.Formularios
{
    public partial class frPrincipal : Form
    {
        public frPrincipal()
        {
            InitializeComponent();
            Player();
            lbSelecPlaylist.DisplayMember = "nomePlaylist";


            foreach (Midia P in Midia.tMidias)
            {
                if (P is Playlists)
                {
                    lbSelecPlaylist.Items.Add(P);
                    lbSelecPlaylist.DisplayMember = "nomePlaylist";
                }
            }
        }

        public void Player()
        {
            //axWindowsMediaPlayer1.newPlaylist("foto", @"C:\Users\Sabrina\Downloads\ibagens\13254529_712710388831369_6742972320372427324_n");
            axMediaPlayer.URL = @"C:\Users\Sabrina\Music\Foster the People\Torches\02-Pumped Up Kicks.m4aC:\Users\Sabrina\Pictures\memes\choro1.jpg";
            axMediaPlayer.Ctlcontrols.play();
            axMediaPlayer.Ctlcontrols.stop();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pilha Pilha = new Pilha();
            Playlists P = (Playlists)lbSelecPlaylist.SelectedItem;
            foreach (Midia M in P.itens)
            {
                Pilha.Empilhar(M);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fila Fila = new Fila();
            Playlists P = (Playlists)lbSelecPlaylist.SelectedItem;
            foreach (Midia M in P.itens)
            {
                Fila.Emfileirar(M);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
