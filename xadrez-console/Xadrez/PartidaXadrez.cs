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

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turnos++;
            MudarJogador();
        }

        public void MudarJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }

        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if(Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição");
            }
            if(JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para essa peça");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição invalida!");
            }
        }
        private void ColocarPecas()
        {
            
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('a', 1).ToPosicao());
            //Tab.ColocarPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('b', 1).ToPosicao());
            //Tab.ColocarPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('c', 1).ToPosicao());
            //Tab.ColocarPeca(new Dama(Cor.Branca, Tab), new PosicaoXadrez('d', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('e', 1).ToPosicao());
            //Tab.ColocarPeca(new Bispo(Cor.Branca, Tab), new PosicaoXadrez('f', 1).ToPosicao());
            //Tab.ColocarPeca(new Cavalo(Cor.Branca, Tab), new PosicaoXadrez('g', 1).ToPosicao());
            //Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('h', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('a', 8).ToPosicao());
            //Tab.ColocarPeca(new Cavalo(Cor.Preta, Tab), new PosicaoXadrez('b', 8).ToPosicao());
            //Tab.ColocarPeca(new Bispo(Cor.Preta, Tab), new PosicaoXadrez('c', 8).ToPosicao());
            //Tab.ColocarPeca(new Dama(Cor.Preta, Tab), new PosicaoXadrez('d', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Cor.Preta, Tab), new PosicaoXadrez('e', 8).ToPosicao());
            //Tab.ColocarPeca(new Bispo(Cor.Preta, Tab), new PosicaoXadrez('f', 8).ToPosicao());
            //Tab.ColocarPeca(new Cavalo(Cor.Preta, Tab), new PosicaoXadrez('g', 8).ToPosicao());
            //Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('h', 8).ToPosicao());


        }
    }
}
