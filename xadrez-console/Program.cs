using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez part = new PartidaXadrez();

                while (!part.Terminou)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(part.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + part.Turnos);
                        Console.WriteLine("Aguardando Jogada: " + part.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        part.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = part.Tab.Peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(part.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        part.ValidarPosicaoDestino(origem, destino);

                        part.RealizaJogada(origem, destino);
                    }catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.ReadLine();

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
