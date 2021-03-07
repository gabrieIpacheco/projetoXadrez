using tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        private PartidaXadrez Partida;
        public Peao(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);
            if (Cor == Cor.Branca)
            {
                //cima
                pos.DefinirValores(Pos.Linha - 1, Pos.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //cima - primeira jogada
                pos.DefinirValores(Pos.Linha - 2, Pos.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //cima - direita - capturar inimigo
                pos.DefinirValores(Pos.Linha - 1, Pos.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                //cima - esquerda - capturar inimigo
                pos.DefinirValores(Pos.Linha - 1, Pos.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }

                //#jogadaEspecial - en passant
                if (Pos.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Pos.Linha, Pos.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.vulneravelEnPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Pos.Linha, Pos.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.vulneravelEnPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                //baixo
                pos.DefinirValores(Pos.Linha + 1, Pos.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //baixo - primeira jogada
                pos.DefinirValores(Pos.Linha + 2, Pos.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //baixo - direita - capturar inimigo
                pos.DefinirValores(Pos.Linha + 1, Pos.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                //baixo - esquerda - capturar inimigo
                pos.DefinirValores(Pos.Linha + 1, Pos.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;

                }
                //#jogadaEspecial - en passant
                if (Pos.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Pos.Linha, Pos.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.Peca(esquerda) == Partida.vulneravelEnPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Pos.Linha, Pos.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.Peca(direita) == Partida.vulneravelEnPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
