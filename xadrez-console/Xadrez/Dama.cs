using tabuleiro;

namespace Xadrez
{
    class Dama:Peca
    {
        public Dama(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "D";
        }
    }
}
