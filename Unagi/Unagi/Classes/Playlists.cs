﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unagi.Classes
{
    public class Playlists
    {
        private string id;
        private string caminho;
        private string nomePlaylist;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Caminho
        {
            get { return caminho; }
            set { caminho = value; }
        }

        public string NomePlaylist
        {
            get { return nomePlaylist; }
            set { nomePlaylist = value; }
        }
    }
}
