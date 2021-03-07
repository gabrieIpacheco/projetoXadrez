using tabuleiro;

namespace Xadrez
{
    class Cavalo:Peca
    {
        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
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

            //cima - esquerda
            aux.DefinirValores(Pos.Linha - 2, Pos.Coluna - 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //cima - direita
            aux.DefinirValores(Pos.Linha - 2, Pos.Coluna + 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //direita - esquerda
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna + 2);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //direita - direita
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna + 2);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //baixo - direita
            aux.DefinirValores(Pos.Linha + 2, Pos.Coluna + 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //baixo - esquerda
            aux.DefinirValores(Pos.Linha + 2, Pos.Coluna - 1);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //esquerda - direita
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna - 2);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }
            //esquerda - esquerda
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna - 2);
            if (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
            }

            return mat;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
