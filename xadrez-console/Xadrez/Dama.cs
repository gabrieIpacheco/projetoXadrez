using tabuleiro;

namespace Xadrez
{
    class Dama:Peca
    {
        public Dama(Cor cor, Tabuleiro tab) : base(cor, tab)
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
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Linha = aux.Linha - 1;
            }

            //direita
            aux.DefinirValores(Pos.Linha, Pos.Coluna + 1);
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Coluna = aux.Coluna + 1;
            }

            //baixo
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna);
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Linha = aux.Linha + 1;
            }

            //esquerda
            aux.DefinirValores(Pos.Linha, Pos.Coluna - 1);
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Coluna = aux.Coluna - 1;
            }

            //cima - direita
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna + 1);
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Linha = aux.Linha - 1;
                aux.Coluna = aux.Coluna + 1;
            }

            //Cima - esquerda
            aux.DefinirValores(Pos.Linha - 1, Pos.Coluna - 1);
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Coluna = aux.Coluna - 1;
                aux.Linha = aux.Linha - 1;
            }

            //baixo - direita
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna + 1);
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Linha = aux.Linha + 1;
                aux.Coluna = aux.Coluna + 1;
            }

            //baixo - esquerda
            aux.DefinirValores(Pos.Linha + 1, Pos.Coluna - 1);
            while (Tab.PosicaoValida(aux) && PodeMover(aux))
            {
                mat[aux.Linha, aux.Coluna] = true;
                if (Tab.Peca(aux) != null && Tab.Peca(aux).Cor != Cor)
                {
                    break;
                }

                aux.Coluna = aux.Coluna - 1;
                aux.Linha = aux.Linha + 1;
            }


            return mat;
        }
        public override string ToString()
        {
            return "D";
        }
    }
}
