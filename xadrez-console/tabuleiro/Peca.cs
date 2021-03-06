using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Pos { get; set; }
        public Cor Cor { get; set; }
        public int QtdeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; set; }

        public Peca( Cor cor, Tabuleiro tab)
        {
            Pos = null;
            Cor = cor;
            Tab = tab;
            QtdeMovimentos = 0;
        }
        
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void IncrementarQtdeMovimentos()
        {
            QtdeMovimentos++;
        }

        public bool PodeMoverPara(Posicao p)
        {
            return MovimentosPossiveis()[p.Linha, p.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
