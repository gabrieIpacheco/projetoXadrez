using System;
using tabuleiro;

namespace Xadrez
{
    class PartidaXadrez
    {
        public int Turnos { get;private set; }
        public Tabuleiro Tab { get;private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminou { get; private set; }

        public PartidaXadrez()
        {
            Terminou = false;
            Tab = new Tabuleiro(8, 8);
            Turnos = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdeMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

        }

        private void ColocarPecas()
        {
            /*
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('a', 1).ToPosicao());
            Tab.ColocarPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('b', 1).ToPosicao());
            Tab.ColocarPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocarPeca(new Dama(Cor.Branca, Tab), new PosicaoXadrez('d', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('f', 1).ToPosicao());
            Tab.ColocarPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('g', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('h', 1).ToPosicao());
            */
            Tab.ColocarPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('e', 1).ToPosicao());

        }
    }
}
