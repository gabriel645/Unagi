﻿using System;
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
using Unagi.Metodos;

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

            lBMusicas.DisplayMember = "Descricao";

            this.components = new Container();
            this.timer1 = new Timer(this.components);
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.timer1.Interval = 1;




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

        static string RetornaDiretorio() //Retorna o diretório para o txt e faz uma cópia na pasta Midia do executável
        {
            string fullPath = "";
            OpenFileDialog FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                fullPath = Path.GetFullPath(FD.FileName);
            }

            string fileName = "Midia";
            string targetPath = @"Midias"; //cria a pasta nova
            string destFile = Path.Combine(targetPath, fileName);

            if (!Directory.Exists("Midias")) //verifica se existe
            {
                Directory.CreateDirectory("Midias");
                //Directory.CreateFolder(targetPath); //cria se não existe
            }

            File.Copy(fullPath, destFile, true);
            return fullPath;
        }


        #region Timer(Animações/Atualiza)
        private Timer timer1;

        bool CLOSE = false;

        private bool telaAumenta = false;
        private bool telaDiminui = false;
        private Button B = new Button();
        private bool btnDeforma = false;
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            #region Animações
            if (telaAumenta)
                if (this.Width < 1250)
                    this.Width += 50;
            if (telaDiminui)
                if (this.Width > 389)
                    this.Width -= 50;

            Efeitos.mouseHovering(B, btnDeforma);
            #endregion

            #region Atualização
            atualizaLista();
            #endregion           


        }
        #endregion

        private bool atualizaLista()
        {
            foreach (Musica M in Musica.ListaMusicas)
                if (!lBMusicas.Items.Contains(M))
                    lBMusicas.Items.Add(M);

            foreach (Musica M in lBMusicas.Items)
                if (!Musica.ListaMusicas.Existe(M))
                {
                    lBMusicas.Items.Remove(M);
                    break;
                }
            return true;
        }

        #region Configurações da Tela       

        private void btnCadastroMusica_Click_1(object sender, EventArgs e)
        {

            //this.Width = 1214;            
            if (telaAumenta)
            { telaAumenta = false; telaDiminui = true; }
            else
            { telaAumenta = true; telaDiminui = false; }

            panelMusica.Visible = true;
            panelAlbum.Visible = false;
            panelVideo.Visible = false;
            txtAnoFoto.Visible = false;

        }

        private void btnCadastroAlbum_Click_1(object sender, EventArgs e)
        {
            if (telaAumenta)
            { telaAumenta = false; telaDiminui = true; }
            else
            { telaAumenta = true; telaDiminui = false; }
            panelMusica.Visible = false;
            panelAlbum.Visible = true;
            panelVideo.Visible = false;
            txtAnoFoto.Visible = false;
        }

        private void bntCadastroVideo_Click_1(object sender, EventArgs e)
        {
            if (telaAumenta)
            { telaAumenta = false; telaDiminui = true; }
            else
            { telaAumenta = true; telaDiminui = false; }
            panelMusica.Visible = false;
            panelAlbum.Visible = false;
            panelVideo.Visible = true;
            txtAnoFoto.Visible = false;
        }

        private void btnCadastroFoto_Click_1(object sender, EventArgs e)
        {
            if (telaAumenta)
            { telaAumenta = false; telaDiminui = true; }
            else
            { telaAumenta = true; telaDiminui = false; }
            panelMusica.Visible = false;
            panelAlbum.Visible = false;
            panelVideo.Visible = false;
            txtAnoFoto.Visible = true;
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            //SALVAR AS OUTRAS MIDIAS TAMBÉM            
            Lista.comparDel(Midia.tMidias, Musica.ListaMusicas);
            Lista.comparaAdd(Musica.ListaMusicas, Midia.tMidias);
            Arquivo.SalvarMidias(Musica.tMidias);
            this.Close();

        }

        #endregion

        #region Cadastrando Música
        private void btnSalvarMusica_Click(object sender, EventArgs e)
        {
            Musica M = new Musica();
            M.Id = Convert.ToInt32(txtIdMusica.Text);
            M.Descricao = txtDescMusica.Text;
            M.Volume = Convert.ToInt32(txtVolumeMusica.Text);
            M.Duracao = Convert.ToDouble(txtDuracaoMusica.Text);
            M.Formato = cbFormatoMusica.SelectedItem.ToString();
            M.ArquivoMidia = txtDiretorioMusica.Text;


            M.Incluir(M);
        }
        private void btnDiretorioMusica_Click(object sender, EventArgs e) //Retorna diretorio da musica
        {
            txtDiretorioMusica.Text = RetornaDiretorio();
            string formato = Path.GetExtension(txtDiretorioMusica.Text).Substring(1).ToUpper();
            cbFormatoMusica.SelectedIndex = (int)((Musica.EnumFormato)Enum.Parse(typeof(Musica.EnumFormato), formato));
        }
        private void btnConsultarMusica_Click(object sender, EventArgs e) //Chama a lista de Musica
        {
            Musica M = (Musica)lBMusicas.SelectedItem;

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

        #region Efeitos Nos Botões
        private void btnCadastroMusica_MouseHover(object sender, EventArgs e)
        {
            if (B.Width <= 300)
            {
                B = btnCadastroMusica;
                btnDeforma = true;
            }
        }

        private void btnCadastroMusica_MouseLeave(object sender, EventArgs e)
        {
            btnDeforma = false;
        }

        private void btnCadastroMusica_MouseEnter(object sender, EventArgs e)
        {
            if (B.Width <= 300)
            {
                B = btnCadastroMusica;
                btnDeforma = true;

            }
        }

        private void btnCadastroAlbum_MouseEnter(object sender, EventArgs e)
        {
            if (B.Width <= 300)
            {
                B = btnCadastroAlbum;
                btnDeforma = true;
            }
        }

        private void btnCadastroAlbum_MouseLeave(object sender, EventArgs e)
        {
            btnDeforma = false;
        }

        private void bntCadastroVideo_MouseEnter(object sender, EventArgs e)
        {
            if (B.Width <= 300)
            {
                B = bntCadastroVideo;
                btnDeforma = true;
            }
        }

        private void bntCadastroVideo_MouseLeave(object sender, EventArgs e)
        {
            btnDeforma = false;
        }

        private void btnCadastroFoto_MouseEnter(object sender, EventArgs e)
        {
            if (B.Width <= 300)
            {
                B = btnCadastroFoto;
                btnDeforma = true;
            }
        }

        private void btnCadastroFoto_MouseLeave(object sender, EventArgs e)
        {
            btnDeforma = false;
        }

        private void btnCadastroAlbum_MouseHover(object sender, EventArgs e)
        {
            if (B.Width <= 300)
            {
                B = btnCadastroAlbum;
                btnDeforma = true;
            }
        }

        private void bntCadastroVideo_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnCadastroFoto_MouseHover(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnExcluirMusica_Click(object sender, EventArgs e)
        {
            Musica.ListaMusicas.RemoverObjeto(lBMusicas.SelectedItem);
        }
    }
}