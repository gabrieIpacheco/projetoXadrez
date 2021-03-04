using tabuleiro;

namespace Xadrez
{
    class Torre:Peca
    {
       public Torre( Cor cor, Tabuleiro tab):base( cor, tab)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
