using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Dama(Cor.Preta, tab), new Posicao(0, 0));
                tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(1, 0));
                tab.ColocarPeca(new Bispo(Cor.Preta, tab), new Posicao(2, 0));
                tab.ColocarPeca(new Dama(Cor.Branca, tab), new Posicao(0, 1));
                tab.ColocarPeca(new Rei(Cor.Branca, tab), new Posicao(1, 1));
                tab.ColocarPeca(new Bispo(Cor.Branca, tab), new Posicao(2, 1));

                Tela.ImprimirTabuleiro(tab);

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
