using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez Partida;
        public Rei(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }

        private bool TesteTorreRoque(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdeMovimentos == 0;
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao aux = new Posicao(0, 0);

            //cima
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //cima - direita
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna + 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //direita
            aux.DefinirValores(Pos.Linha, Pos.Coluna + 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //baixo - direita
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna + 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //baixo
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //baixo - esquerda
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna - 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //esquerda
            aux.DefinirValores(Pos.Linha, Pos.Coluna - 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //cima - esquerda
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna - 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }


            if (QtdeMovimentos == 0 && !Partida.Xeque)
            {
                //#jogadasEspecial - roque pequeno
                Posicao posTorre1 = new Posicao(Pos.Linha, Pos.Coluna + 3);
                if (TesteTorreRoque(posTorre1))
                {
                    Posicao p1 = new Posicao(Pos.Linha, Pos.Coluna + 1);
                    Posicao p2 = new Posicao(Pos.Linha, Pos.Coluna + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[Pos.Linha, Pos.Coluna + 2] = true;
                    }
                }
                //#jogadaEspecial - roque grande
                Posicao posTorre2 = new Posicao(Pos.Linha, Pos.Coluna - 4);
                if (TesteTorreRoque(posTorre2))
                {
                    Posicao p1 = new Posicao(Pos.Linha, Pos.Coluna - 1);
                    Posicao p2 = new Posicao(Pos.Linha, Pos.Coluna - 2);
                    Posicao p3 = new Posicao(Pos.Linha, Pos.Coluna - 3);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        mat[Pos.Linha, Pos.Coluna - 2] = true;
                    }
                }
            }




            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
