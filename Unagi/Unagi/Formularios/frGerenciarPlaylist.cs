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
            originalWidth = this.Width;
            originalHeight = this.Height;
            CarregalbMidia();
            button6.Enabled = false;

        }

        public void CarregalbMidia()
        {
            foreach (Midia M in Midia.tMidias)
            {
                lbMidias.Items.Add(M);
                lbMidias.DisplayMember = "Descricao";
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Width = 1214;

        }

        private void lbMidias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPlaylist_Click(object sender, EventArgs e)
        {
            lbPlaylist.DisplayMember = "Descricao";
            lbPlaylist.Items.Add(lbMidias.SelectedItem.ToString());
        }

        private void lbPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Playlists P = new Playlists();
            P.nomePlaylist = txtNomePlaylist.Text;
            string[] auxiliar = new string[lbPlaylist.Items.Count];

            for (int i = 0; i < auxiliar.Length; i++)
            {

                auxiliar[i] += "|" + lbPlaylist.Text.ToString();


            }

            foreach (var item in lbPlaylist.Items)
            {
                int j = 0;

                P.items[j] += "|" + item.ToString();
                j++;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            lbPlaylist.Items.Remove(lbPlaylist.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Foto F in Midia.tMidias)
            {
                lbMidias.Items.Add(F);
                lbMidias.DisplayMember = "Descricao";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Video V in Midia.tMidias)
            {
                lbMidias.Items.Add(V);
                lbMidias.DisplayMember = "Descricao";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Musica M in Midia.tMidias)
            {
                lbMidias.Items.Add(M);
                lbMidias.DisplayMember = "Descricao";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbMidias.Sorted = true;
        }
    }
}
