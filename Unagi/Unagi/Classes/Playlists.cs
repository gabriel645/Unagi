using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unagi.Classes
{
    public class Playlists
    {
        public string nomePlaylist;
        public string[] items;

        public override string ToString()
        {
            return "Playlist" + base.ToString();
        }
    }
}
