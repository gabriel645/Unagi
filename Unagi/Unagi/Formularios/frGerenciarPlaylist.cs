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
using Unagi.Classes;
using Unagi.Metodos;
using System.IO;

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
            lbPlaylist.Items.Add(lbMidias.SelectedItem.ToString());
        }

        private void lbPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Playlists novaPlaylist = new Playlists();
            novaPlaylist.NomePlaylist = txtNomePlaylist.Text;

           /* string[] auxiliar;
            //Environment.NewLine + txtNomePlaylist.Text + "|" + lbPlaylist.Items;
            
            for (int i = 0; i < 5 i++)
            {
                lbPlaylist.Items.CopyTo(auxiliar, i);
            }

            if ((!File.Exists("playlists.txt")))
            {
                File.Create("playlists.txt");
                File.AppendAllText("playlists.txt", auxiliar);
            }
            else
                File.AppendAllText("playlists.txt", auxiliar);
           */
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lbPlaylist.Items.Remove(lbPlaylist.SelectedItem);
        }
    }
}
