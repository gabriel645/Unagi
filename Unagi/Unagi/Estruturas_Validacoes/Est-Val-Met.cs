﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Unagi.Classes;

namespace Unagi
{
    namespace Metodos
    {
        public static class Efeitos
        {
            public static void mouseHovering(Button B, bool hovering)
            {

                if (hovering && B.Width < 310)
                    B.Width += 5;
                else if (!hovering && B.Width > 300)
                    B.Width -= 5;
            }
        }
        public static class Arquivo
        {
            public static void CarregaMidias(Estrutura.Lista L)
            {
                if (!File.Exists("Banco.txt"))
                {
                    File.Create("Banco.txt");
                    return;
                }

                string[] arquivo = File.ReadAllLines("Banco.txt");
                foreach (string s in arquivo)
                {
                    string[] linha = s.Split('|');
                    switch (linha[0])
                    {
                        case "Musica":
                            addMusica(linha);
                            break;
                        case "Foto":
                            addFoto(linha);
                            break;
                        case "Video":
                            addVideo(linha);
                            break;

                    }
                }
                foreach (string s in arquivo)
                {
                    string[] linha = s.Split('|');
                    if (linha[0] == "Playlist")
                    {
                        addPlaylist(linha);
                    }
                }

                void addMusica(string[] M)
                {
                    Musica obj = new Musica();
                    obj.Id = Convert.ToInt32(M[1]);
                    obj.Descricao = M[2];
                    obj.Duracao = Convert.ToDouble(M[3]);
                    obj.Volume = Convert.ToInt32(M[4]);
                    obj.Formato = M[5];
                    obj.ArquivoMidia = M[6];

                    L.InserirNoFim(obj);
                    Musica.ListaMusicas.InserirNoFim(obj);
                }
                void addFoto(string[] F)
                {
                    Foto obj = new Foto();
                    obj.Id = Convert.ToInt32(F[1]);
                    obj.Descricao = F[2];
                    obj.Localizacao = F[3];
                    obj.MegaPixels = Convert.ToDouble(F[4]);
                    obj.TempoDeExibicao = Convert.ToInt32(F[5]);
                    obj.AnoDeLancamento = Convert.ToInt32(F[6]);
                    obj.ArquivoMidia = F[7];

                    L.InserirNoFim(obj);
                    Foto.ListaFotos.InserirNoFim(obj);
                }
                void addVideo(string[] V)
                {
                    Video obj = new Video();
                    obj.Id = Convert.ToInt32(V[1]);
                    obj.Descricao = V[2];
                    obj.Formato = V[3];
                    obj.Idioma = V[4];
                    obj.PossuiLegenda = Convert.ToBoolean(V[5]);
                    obj.AnoDeLancamento = Convert.ToInt32(V[6]);

                    obj.ArquivoMidia = V[7];

                    L.InserirNoFim(obj);
                    Video.ListaVideos.InserirNoFim(obj);

                }
                void addPlaylist(string[] P)
                {
                    Playlists obj = new Playlists();
                    obj.nomePlaylist = P[1];
                    for (int i = 2; i < P.Length - 1; i++)
                    {
                        foreach (Midia item in Midia.tMidias)
                        {
                            if (item.Id.ToString() == P[i])
                            {
                                obj.itens.InserirNoFim(item);
                            }
                        }
                    }
                    L.InserirNoFim(obj);

                }
            }

            public static void SalvarMidias(Estrutura.Lista L)
            {
                if (!File.Exists("Banco.txt"))
                {
                    File.Create("Banco.txt").Close();
                }

                File.WriteAllText("Banco.txt", string.Empty);

                StreamWriter Writer = File.AppendText("Banco.txt");
                foreach (Midia obj in L)
                {
                    Writer.WriteLine(obj.ToString());
                }

                Writer.Close();

            }


        }


    }

    namespace Estrutura
    {
        public class Nodo
        {
            object dado;

            public object Dado
            {
                get { return dado; }
                set { dado = value; }
            }
            Nodo proximo;

            public Nodo Proximo
            {
                get { return proximo; }
                set { proximo = value; }
            }

            Nodo anterior;

            public Nodo Anterior
            {
                get { return anterior; }
                set { anterior = value; }
            }

            /// <summary>
            /// Construtor parametrizado
            /// </summary>
            /// <param name="dado"></param>
            /// <param name="proximo"></param>
            public Nodo(object dado, Nodo proximo)
            {
                this.dado = dado;
                this.proximo = proximo;
            }

            /// <summary>
            /// construtor sem parâmetros
            /// </summary>
            public Nodo()
            {
                dado = null;
                proximo = null;
                anterior = null;
            }
        }
        public class Lista : IEnumerable, IEnumerator
        {
            Nodo primeiro = null;
            Nodo ultimo = null;
            int qtde = 0;


            private void InserirNaPosicao(Nodo anterior, object valor)
            {
                Nodo novo = new Nodo();
                novo.Dado = valor;

                if (anterior == null)
                {
                    if (qtde == 0)
                        primeiro = novo;
                    else
                    {
                        novo.Proximo = primeiro;
                        primeiro.Anterior = novo;
                        primeiro = novo;
                    }
                }
                else
                {
                    novo.Proximo = anterior.Proximo;
                    anterior.Proximo = novo;
                    novo.Anterior = anterior;
                    if (novo.Proximo != null)
                    {
                        novo.Proximo.Anterior = novo;
                    }
                }

                if (novo.Proximo == null)
                    ultimo = novo;

                qtde++;
            }

            public void InserirNoInicio(object valor)
            {
                InserirNaPosicao(null, valor);
            }
            public void InserirNoFim(object valor)
            {
                if (qtde == 0)
                {
                    InserirNoInicio(valor);
                }
                else
                {
                    InserirNaPosicao(ultimo, valor);
                }
            }

            /// <summary>
            /// Insere em uma posição, iniciando do 0
            /// </summary>
            /// <param name="valor">valor</param>
            /// <param name="posicao">posicao iniciando do 0</param>
            public void InserirNaPosicao(object valor, int posicao)
            {
                if (posicao > qtde || posicao < 0)
                    throw new Exception("Não é possível inserir.");

                if (posicao == 0)
                    InserirNoInicio(valor);
                else
                {
                    Nodo aux = primeiro;
                    for (int i = 1; i < posicao; i++)
                        aux = aux.Proximo;

                    InserirNaPosicao(aux, valor);
                }
            }


            public void RemoverDaPosicao(int posicao)
            {
                if (posicao >= qtde || posicao < 0 || qtde == 0)
                    throw new Exception("Não é possível remover.");

                object valor;
                qtde--;

                if (qtde == 0)
                {
                    valor = primeiro.Dado;
                    primeiro = ultimo = null;
                }
                else
                {
                    //nodoApagado irá armazenar o nodo será apagado.
                    Nodo nodoApagado = primeiro;
                    for (int i = 1; i <= posicao; i++)  // encontra o elemento anterior ao que será apagado
                        nodoApagado = nodoApagado.Proximo;

                    valor = nodoApagado.Dado;

                    if (nodoApagado.Proximo == null) // ajusta o último
                        ultimo = nodoApagado.Anterior;

                    if (nodoApagado.Anterior == null) // ajusta o primeiro
                        primeiro = nodoApagado.Proximo;

                    if (nodoApagado.Anterior != null)
                        nodoApagado.Anterior.Proximo = nodoApagado.Proximo;

                    if (nodoApagado.Proximo != null)
                        nodoApagado.Proximo.Anterior = nodoApagado.Anterior;

                }
            }

            /// <summary>
            /// Remove a lista um objeto passado, se existir.
            /// </summary>
            /// <param name="obj"></param>
            public void RemoverObjeto(object obj)
            {
                RemoverDaPosicao(RetornaPosicao(obj));
            }

            public bool Existe(object dado)
            {
                Nodo aux = primeiro;
                while (aux != null)
                {
                    if (aux.Dado == dado)
                        return true;
                    aux = aux.Proximo;
                }

                return false;
            }

            public void Clear()
            {
                primeiro = null;
            }

            #region Static Members
            /// <summary>
            /// Compara a com b e deleta objetos de a que nao estejam em b.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            public static void comparDel(Lista a, Lista b)
            {
                foreach (object o in a)
                {
                    if (!b.Existe(o) && o.GetType() == a.primeiro.GetType())
                        a.RemoverObjeto(o);
                }
            }

            /// <summary>
            /// Compara a com b e adciona (em b) objetos de a que nao estejam em b.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            public static void comparaAdd(Lista a, Lista b)
            {
                foreach (object o in a)
                {
                    if (!b.Existe(o))
                        b.InserirNoFim(o);
                }
            }
            #endregion

            public int RetornaPosicao(object dado)
            {
                int pos = 0;
                Nodo aux = primeiro;
                while (aux != null)
                {
                    if (aux.Dado == dado)
                        return pos;
                    aux = aux.Proximo;
                    pos++;
                }
                pos = -1;
                return pos;
            }



            public Nodo RetornaPrimeiro()
            {
                return primeiro;
            }


            #region So Foreach can work
            public bool MoveNext()
            {
                if (nodoAtualParaForEach == null)
                    nodoAtualParaForEach = RetornaPrimeiro();
                else
                    nodoAtualParaForEach = nodoAtualParaForEach.Proximo;

                return nodoAtualParaForEach != null;
            }

            Nodo nodoAtualParaForEach;
            public void Reset()
            {
                nodoAtualParaForEach = new Nodo();
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }

            object IEnumerator.Current
            {
                get
                {
                    return nodoAtualParaForEach.Dado;
                }
            }
            #endregion

        }
    }




    namespace Estrutura
    {
        /// <summary>
        /// Classe que irá representar 1 elemento na pilha
        /// </summary>
        class NodoPilha
        {
            private string valor;
            private NodoPilha anterior;
            /// <summary>
            /// Valor que será armazenado
            /// </summary>
            public string Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            /// <summary>
            /// Endereço do NodoPilha anterior na pilha
            /// </summary>
            public NodoPilha Anterior
            {
                get { return anterior; }
                set { anterior = value; }
            }
        }
        /// <summary>
        /// Classe Pilha Dinâmica
        /// </summary>
        class Pilha
        {
            //Representa o topo da pilha
            private NodoPilha topo = null;
            // quantidade de elementos na pilha
            int quantidade = 0;
            public int Quantidade
            {
                get { return quantidade; }
            }
            /// <summary>
            /// Método para empilhar strings
            /// </summary>
            /// <param name="valor"></param>
            public void Empilhar(string valor)
            {
                NodoPilha novoNodoPilha = new NodoPilha();
                novoNodoPilha.Valor = valor;
                novoNodoPilha.Anterior = topo;
                topo = novoNodoPilha;
                quantidade++;
            }

            /// <summary>
            /// Desempilhar elementos da pilha
            /// </summary>
            /// <returns></returns>
            public string Desempilhar()
            {
                if (quantidade == 0)
                    throw new Exception("A pilha está vazia!");
                else
                {
                    string retorno = topo.Valor;
                    topo = topo.Anterior;
                    quantidade--;
                    return retorno;
                }
            }
            /// <summary>
            /// Método para retornar o topo da pilha
            /// </summary>
            /// <returns></returns>
            public string RetornaTopo()
            {
                if (quantidade == 0)
                    throw new Exception("A pilha está vazia!");
                else
                {
                    return topo.Valor;
                }
            }
        }

        namespace Estrutura
        {
            class Fila
            {
                public Fila(int capacidade)
                {
                    CAPACIDADE = capacidade;
                }
                int CAPACIDADE = 5; // capacidade máxima da fila
                private int quantidade = 0; // qtde de elementos enfileirados
                private int inicio = 0; // indica qual a primeira posição da fila
                private int fim = 0; // indica a próxima posição
                private string[] dados = new string[CAPACIDADE]; // armazenar os dados da fila
                                                                 // retorna o tamanho da fila
                public int Tamanho()
                {
                    return quantidade;
                }
                // enfileira um valor string
                public void Enfileirar(string p_valor)
                {
                    if (Tamanho() == CAPACIDADE)
                    {
                        throw new Exception("A fila está cheia!!!!");
                    }
                    else
                    {
                        dados[fim] = p_valor;
                        fim = (fim + 1) % CAPACIDADE;
                        quantidade++;
                    }
                }
                // remove o primeiro elemento da fila e devolve.
                public string Desenfileira()
                {
                    if (Tamanho() == 0)
                    {
                        throw new Exception("A fila está vazia!");
                    }
                    else
                    {
                        string valor = dados[inicio];
                        inicio = (inicio + 1) % CAPACIDADE;
                        quantidade--;
                        return valor;
                    }
                }
            }
        }
    }


}