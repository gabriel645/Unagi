using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unagi.Formularios
{
    public partial class frPrincipal : Form
    {
        public frPrincipal()
        {
            InitializeComponent();
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
    }
}
