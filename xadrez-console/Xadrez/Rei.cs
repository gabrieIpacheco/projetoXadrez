using tabuleiro;

namespace Xadrez
{
    class Rei:Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

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
            if(Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //cima - direita
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna +1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //direita
            aux.DefinirValores(Pos.Linha , Pos.Coluna + 1);
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

            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
