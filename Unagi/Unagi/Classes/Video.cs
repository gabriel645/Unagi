using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unagi.Estrutura;

namespace Unagi
{
    class Video : Midia, ILocal, ICatalogo
    {

        public static Lista ListaVideos = new Lista();
        public enum EnumIdioma
        {
            portugues,
            ingles,
            espanhol,
            outros
        }

        public enum EnumFormVideo
        {
            AVI,
            WMV,
            MKV,
            MP4,
            MPEG,
            outros
        }

        string formato;
        public string Formato
        {
            get { return formato; }
            set { formato = value; }
        }

        string idioma;
        public string Idioma
        {
            get { return idioma; }
            set { idioma = value; }
        }

        private string arquivoMidia;

        public string ArquivoMidia
        {
            get { return arquivoMidia; }
            set { arquivoMidia = value; }
        }
        private int anoDeLancamento;

        public int AnoDeLancamento
        {
            get { return anoDeLancamento; }
            set { anoDeLancamento = value; }
        }
        bool possuiLegenda;

        public bool PossuiLegenda
        {
            get { return possuiLegenda; }
            set { possuiLegenda = value; }
        }




        public override void Alterar()
        {
            throw new NotImplementedException();
        }

        public override void Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }
        public void Excluir(Video VPassado)
        {
            foreach (Video V in ListaVideos)
            {
                if (V.Id == VPassado.Id)
                {
                    ListaVideos.RemoverDaPosicao(ListaVideos.RetornaPosicao(V));
                }
            }
        }

        public override void Incluir()
        {
            throw new NotImplementedException();
        }
        public void Incluir(Video VPassado)
        {
            ListaVideos.InserirNoFim(VPassado);
        }

        public bool validaCaminho(string path)
        {
            return File.Exists(path);
        }
        public override string ToString()
        {
            return "Video" + "|" + base.ToString() + Formato.ToString() + "|" + Idioma.ToString() + "|" + PossuiLegenda.ToString() + "|" + anoDeLancamento.ToString() + "|" + ArquivoMidia;
        }
    }
}
