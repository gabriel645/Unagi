using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unagi.Estrutura;
using Unagi.Metodos;
using System.IO;
using Unagi.Classes;


namespace Unagi
{
    public partial class frGerenciarPlaylist : Form
    {
        private int originalWidth;
        private int originalHeight;

        public frGerenciarPlaylist()
        {            
            InitializeComponent();
            this.Width = 620;
            originalWidth = this.Width;
            originalHeight = this.Height;
            CarregalbMidia();
            button6.Enabled = false;
            lbMidias.DisplayMember = "Descricao";
            lbPlaylist.DisplayMember = "Descricao";
        }

        public void CarregalbMidia()
        {
            foreach (Midia M in Midia.tMidias)
            {
                lbMidias.Items.Add(M);
            }

        }
               
        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Width = 1260;
        }

        private void lbMidias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPlaylist_Click(object sender, EventArgs e)
        {
            lbPlaylist.Items.Add(lbMidias.SelectedItem);
        }

        private void lbPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Playlists P = new Playlists();
            P.nomePlaylist = txtNomePlaylist.Text;
            //string[] auxiliar = new string[lbPlaylist.Items.Count];

            foreach (Midia item in lbPlaylist.Items) // e tentei assim tb
            {
                P.itens.InserirNoFim(item); 
            }

            P.Incluir(P);
            Midia.tMidias.InserirNoFim(P);
            Arquivo.SalvarMidias(Midia.tMidias);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            lbPlaylist.Items.Remove(lbPlaylist.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbMidias.Items.Clear();
            foreach (Midia F in Midia.tMidias)
            {
                if(F is Foto)                
                    lbMidias.Items.Add(F);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbMidias.Items.Clear();
            foreach (Midia V in Midia.tMidias)
            {
                if (V is Video)
                    lbMidias.Items.Add(V);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lbMidias.Items.Clear();
            foreach (Midia M in Midia.tMidias)
            {
                if (M is Musica)
                    lbMidias.Items.Add(M);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbMidias.Sorted = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lbMidias.Items.Clear();
            foreach (Midia M in Midia.tMidias)
            {                
                    lbMidias.Items.Add(M);
            }
        }

        private void btnFila_Click(object sender, EventArgs e)
        {

        }

        private void btnLista_Click(object sender, EventArgs e)
        {

        }
    }
}
