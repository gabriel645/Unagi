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
using System.Diagnostics;

namespace Unagi.Formularios
{
    public partial class frPrincipal : Form
    {
        public frPrincipal()
        {
            InitializeComponent();
            lbSelecPlaylist.DisplayMember = "nomePlaylist";

            this.components = new Container();
            this.timer1 = new Timer(this.components);
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.timer1.Interval = 1;

            foreach (Midia P in Midia.tMidias)
            {
                if (P is Playlists)
                {
                    lbSelecPlaylist.Items.Add(P);
                    lbSelecPlaylist.DisplayMember = "nomePlaylist";
                }
            }
        }

        private Timer timer1;
        Stopwatch fotoTimer = new Stopwatch();
        private int tempoFoto = 0;

        bool proximo = true;
        int indice = 0;
        object pATocar;
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (axMediaPlayer.playState == WMPPlayState.wmppsStopped)
            {
                //axMediaPlayer.Ctlcontrols.play();
                proximo = true;                
            }
            if (proximo)
            {
                playProximo(pATocar);
                indice++;
                proximo = false;
            }
            if (fotoTimer.IsRunning)
                axMediaPlayer.Ctlcontrols.pause();
            if (fotoTimer.Elapsed.Seconds >= tempoFoto && fotoTimer.IsRunning)
            {
                axMediaPlayer.Ctlcontrols.stop();
                fotoTimer.Stop();
                fotoTimer.Reset();
            }


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
            Pilha pilha = new Pilha();
            Playlists P = (Playlists)lbSelecPlaylist.SelectedItem;
            foreach (Midia M in P.itens)
            {
                pilha.Empilhar(M);
            }

            pATocar = pilha;
            indice = 0;
            proximo = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fila fila = new Fila();
            Playlists P = (Playlists)lbSelecPlaylist.SelectedItem;
            foreach (Midia M in P.itens)
            {
                fila.Emfileirar(M);
            }
            pATocar = fila;
            indice = 0;
            proximo = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pATocar = (Playlists)lbSelecPlaylist.SelectedItem;
            indice = 0;
            proximo = true;
        }

        int qtd = 0;
        public void playProximo(object P)
        {
            if (P is Playlists)
            {
                if (indice >= (P as Playlists).itens.Tamanho())
                    indice = 0;

                Midia item = (Midia)(P as Playlists).itens.RetornaDaPosicao(indice);

                setURL(item);

            }
            if(P is Pilha)
            {

                //Pilha aux = new Pilha();                
                if (indice == 0)
                    qtd = (P as Pilha).Quantidade;
                if (indice >= qtd)
                    return;
                Midia item = (Midia)(P as Pilha).Desempilhar();
                setURL(item);
                
            }
            if(P is Fila)
            {
                //Pilha aux = new Pilha();

                if (indice == 0)
                    qtd = (P as Fila).Quantidade;
                if (indice >= qtd)
                    return;
                Midia item = (Midia)(P as Fila).Desemfilerar();
                setURL(item);
            }
            axMediaPlayer.Ctlcontrols.play();
        }
        public void setURL(Midia item)
        {
            if (item is Musica)
            {
                axMediaPlayer.URL = (item as Musica).ArquivoMidia;
            }

            else if (item is Foto)
            {
                axMediaPlayer.URL = (item as Foto).ArquivoMidia;
                tempoFoto = (item as Foto).TempoDeExibicao;
                fotoTimer.Start();
            }

            else if (item is Video)
            {
                axMediaPlayer.URL = (item as Video).ArquivoMidia;
            }
        }
    }

}

