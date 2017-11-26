using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unagi.Estrutura;

namespace Unagi.Classes
{
    public class Playlists : Midia
    {

        public string nomePlaylist;
        public Lista itens = new Lista();
        public static Lista ListaPlaylist = new Lista();

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

        public void Incluir(Playlists PPassada)
        {
            ListaPlaylist.InserirNoFim(PPassada);
        }

        public override string ToString()
        {
            string auxiliar = "";
            foreach (Midia a in this.itens)
            {
                auxiliar += a.Id + "|";
            }
            return "Playlist" + "|" + this.nomePlaylist  + "|" + auxiliar;
        }
    }
}
