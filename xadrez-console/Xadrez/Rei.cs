using tabuleiro;

namespace Xadrez
{
    class Rei:Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
