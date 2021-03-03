using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Peca
    {
        public Posicao Pos { get; set; }
        public Cor Cor { get; set; }
        public int QtdeMovimentos { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca( Cor cor, Tabuleiro tab)
        {
            Pos = null;
            Cor = cor;
            Tab = tab;
            QtdeMovimentos = 0;
        }
    }
}
