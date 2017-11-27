using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unagi.Estrutura;
namespace Unagi
{
    class AlbumMusical : Midia, ICatalogo
    {
        public static Lista Album = new Lista();  //add as musicas desse album na lista(criar metodo)

        Lista MPertencentes = new Lista();

        string artista;

        public string Artista
        {
            get { return artista; }
            set { artista = value; }
        }

        private int anoDeLancamento;

        public int AnoDeLancamento
        {
            get { return anoDeLancamento; }
            set { anoDeLancamento = value; }
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
    }
}
