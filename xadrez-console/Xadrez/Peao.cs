using tabuleiro;

namespace Xadrez
{
    class Peao:Peca
    {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
