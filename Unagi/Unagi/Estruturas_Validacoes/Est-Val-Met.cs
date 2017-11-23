using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
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

                void addMusica(string[] M)
                {
                    Musica obj = new Musica();
                    obj.Id = Convert.ToInt32(M[1]);
                    obj.Descricao = M[2];
                    obj.Duracao = Convert.ToDouble(M[3]);
                    obj.Volume = Convert.ToInt32(M[4]);
                    obj.ArquivoMidia = M[5];

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
                }
                void addVideo(string[] V)
                {
                    Video obj = new Video();
                    obj.Id = Convert.ToInt32(V[1]);
                    obj.Descricao = V[2];
                    obj.PossuiLegenda = Convert.ToBoolean(V[3]);
                    obj.AnoDeLancamento = Convert.ToInt32(V[4]);
                    obj.ArquivoMidia = V[5];

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


            public object RemoverDaPosicao(int posicao)
            {
                if (posicao >= qtde || posicao < 0 || qtde == 0)
                    throw new Exception("Não é possível remover.");

                object valor = "";
                qtde--;

                if (qtde == 0)
                {
                    valor = primeiro.Dado;
                    primeiro = ultimo = null;
                    return valor;
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

                    return valor;
                }
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

            
        }
    }




    namespace Estrutura
    {

    }


}