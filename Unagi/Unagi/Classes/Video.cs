using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unagi.Estrutura;

namespace Unagi
{
    class Video : Midia, ILocal, ICatalogo
    {

        public static Lista ListaMVideos = new Lista();
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

        public override void Incluir()
        {
            throw new NotImplementedException();
        }

        public bool validaCaminho(string path)
        {
            throw new NotImplementedException();
        }
    }
}
