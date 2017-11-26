using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Unagi.Estrutura;

namespace Unagi.Formularios
{
    public partial class frCadastro : Form
    {
        private int originalWidth;
        private int originalHeight;
        public frCadastro()
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
        }
        void CarregaEnums()
        {
            foreach (var item in Enum.GetValues(typeof(Video.EnumFormVideo)))
            {
                cbFormatoVideo.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(Video.EnumIdioma)))
            {
                cbIdiomaVideo.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(Musica.EnumFormato)))
            {
                cbFormatoMusica.Items.Add(item);
            }
        }
        static string RetornaDiretorio()
        {
            string fullPath = "";
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                fullPath = Path.GetFullPath(FD.FileName);
            }
            return fullPath;
        }

        #region Configurações da Tela
        private void btnCadastroMusica_Click_1(object sender, EventArgs e)
        {
            this.Width = 1214;
            panelMusica.Visible = true;
            panelAlbum.Visible = false;
            panelVideo.Visible = false;
            txtAnoFoto.Visible = false;
        }

        private void btnCadastroAlbum_Click_1(object sender, EventArgs e)
        {
            this.Width = 1214;
            panelMusica.Visible = false;
            panelAlbum.Visible = true;
            panelVideo.Visible = false;
            txtAnoFoto.Visible = false;
        }

        private void bntCadastroVideo_Click_1(object sender, EventArgs e)
        {
            this.Width = 1214;
            panelMusica.Visible = false;
            panelAlbum.Visible = false;
            panelVideo.Visible = true;
            txtAnoFoto.Visible = false;
        }

        private void btnCadastroFoto_Click_1(object sender, EventArgs e)
        {
            this.Width = 1214;
            panelMusica.Visible = false;
            panelAlbum.Visible = false;
            panelVideo.Visible = false;
            txtAnoFoto.Visible = true;
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Cadastrando Música
        private void btnSalvarMusica_Click(object sender, EventArgs e)
        {
            Musica M = new Musica();
            M.Id = Convert.ToInt32(txtIdMusica.Text);
            M.Descricao = txtDescMusica.Text;
            M.ArquivoMidia = txtDiretorioMusica.Text;
            M.Volume = Convert.ToInt32(txtVolumeMusica.Text);
            M.Duracao = Convert.ToDouble(txtDuracaoMusica.Text);
            M.Formato = cbFormatoMusica.SelectedItem.ToString();
            M.Incluir(M);
        }
        private void btnDiretorioMusica_Click(object sender, EventArgs e) //Retorna diretorio da musica
        {
            txtDiretorioMusica.Text = RetornaDiretorio();
        }
        private void btnConsultarMusica_Click(object sender, EventArgs e) //Chama a lista de Musica
        {
            /*frLista telaLista = new frLista(Musica.ListaMusicas);
            telaLista.Location = new Point(321, 223);
            telaLista.Show();*/
            //seleciona a musica > clica > carrega os dados
        }
        #endregion

        #region Cadastrando Foto
        private void btnCadastrarFoto_Click(object sender, EventArgs e) //Salva os atributos da foto! Faltam as validações
        {
            Foto F = new Foto();
            F.Id = Convert.ToInt32(txtIdFoto.Text);
            F.Descricao = txtDescFoto.Text;
            F.ArquivoMidia = txtDiretorioFoto.Text;
            F.Localizacao = txtLocalFoto.Text;
            F.MegaPixels = Convert.ToInt32(txtMpFoto.Text);
            F.TempoDeExibicao = Convert.ToInt32(txtSegundosFoto.Text);
            F.Incluir(F);
            F.AnoDeLancamento = Convert.ToInt32(txtFotoAno.Text);
        }
        private void button8_Click(object sender, EventArgs e) //Retorna diretório da foto (dá pra fazer um método, não?)
        {
            txtDiretorioFoto.Text = RetornaDiretorio();
        }
        private void btnConsultaFoto_Click(object sender, EventArgs e) //Chama a lista de foto
        {
            frLista telaLista = new frLista(Foto.ListaFotos);
            telaLista.Location = new Point(321, 223);
            telaLista.Show();
        }
        #endregion

        #region Cadastrando Video
        private void btnSalvarVideo_Click(object sender, EventArgs e)
        {
            Video V = new Video();
            V.Id = Convert.ToInt32(txtIdVideo.Text);
            V.Descricao = txtIdVideo.Text;

            if (cbLegendaVideo.SelectedItem.ToString() == "sim")
                V.PossuiLegenda = true;
            else
                V.PossuiLegenda = false;

            V.Formato = cbFormatoMusica.SelectedItem.ToString();
            V.Idioma = cbIdiomaVideo.SelectedItem.ToString();
            V.AnoDeLancamento = Convert.ToInt32(txtAnoVideo.Text);
        }
        private void btnDiretorioVideo_Click(object sender, EventArgs e)
        {
            txtDiretorioVideo.Text = RetornaDiretorio();
        }
        private void btnAlterarVideo_Click(object sender, EventArgs e)
        {
            //seleciona a musica > clica > carrega os dados
        }

        #endregion

        #region Cadastrando Album


        #endregion

        private void lBMusicas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }


    }
}