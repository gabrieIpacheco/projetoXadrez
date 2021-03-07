using System;
using tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaXadrez
    {
        public int Turnos { get; private set; }
        public Tabuleiro Tab { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminou { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public Peca vulneravelEnPassant { get; private set; }
        public bool Xeque { get; private set; }

        public PartidaXadrez()
        {

            Tab = new Tabuleiro(8, 8);
            Turnos = 1;
            JogadorAtual = Cor.Branca;
            Terminou = false;
            Xeque = false;
            vulneravelEnPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQtdeMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            //#jogadaEspecial - roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca t = Tab.RetirarPeca(origemT);
                t.IncrementarQtdeMovimentos();
                Tab.ColocarPeca(t, destinoT);
            }

            //#jogadaEspecial - roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca t = Tab.RetirarPeca(origemT);
                t.IncrementarQtdeMovimentos();
                Tab.ColocarPeca(t, destinoT);
            }

            //#jogadaEspecial - en passant
            if (p is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada == null)
                {
                    Posicao posPeao;
                    if (p.Cor == Cor.Branca)
                    {
                        posPeao = new Posicao(destino.Linha + 1, destino.Coluna);

                    }
                    else
                    {
                        posPeao = new Posicao(destino.Linha - 1, destino.Coluna);
                    }

                    pecaCapturada = Tab.RetirarPeca(posPeao);
                    capturadas.Add(pecaCapturada);
                }
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQtdeMovimentos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);

            //#jogadaEspecial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca t = Tab.RetirarPeca(origemT);
                t.DecrementarQtdeMovimentos();
                Tab.ColocarPeca(t, destinoT);
            }

            //#jogadaEspecial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca t = Tab.RetirarPeca(origemT);
                t.DecrementarQtdeMovimentos();
                Tab.ColocarPeca(t, destinoT);
            }
            //#jogadaEspecial - en passant
            if (p is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada == vulneravelEnPassant)
                {
                    Peca peao = Tab.RetirarPeca(destino);
                    Posicao posPeao;
                    if(peao.Cor == Cor.Branca)
                    {
                        posPeao = new Posicao(3, destino.Coluna);
                    }
                    else
                    {
                        posPeao = new Posicao(4, destino.Coluna);
                    }

                    Tab.ColocarPeca(peao, posPeao);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode ficar em xeque!");
            }

            Peca p = Tab.Peca(destino);
            //#jogadaEspecial promocao
            if(p is Peao)
            {
                if((p.Cor == Cor.Branca && destino.Linha == 0)||(p.Cor == Cor.Preta && destino.Linha == 7))
                {
                    p = Tab.RetirarPeca(destino);
                    pecas.Remove(p);
                    char choice;

                    do { 
                        Console.Write("Escolha a peca da promoção(D/B/C/T): ");
                        choice = char.Parse(Console.ReadLine());
                        
                    } while (choice != 'd' && choice != 'b' && choice != 'c' && choice != 't');
                    Peca novaPeca = Promocao(choice, p);
                    Tab.ColocarPeca(novaPeca, destino);
                    pecas.Add(novaPeca);
                }
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (TesteXequeMate(Adversaria(JogadorAtual)))
            {
                Terminou = true;
            }
            else
            {
                Turnos++;
                MudarJogador();
            }

            
            //#jogadaEspecial en passant
            if (p is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2))
            {
                vulneravelEnPassant = p;
            }
            else
            {
                vulneravelEnPassant = null;
            }
        }
        public Peca Promocao(char c, Peca p)
        {
            Peca aux;
            switch (c)
            {
                
                case 'd':
                    aux = new Dama(p.Cor, Tab);
                    return aux;
                case 'D':
                    aux = new Dama(p.Cor, Tab);
                    return aux;

                case 'b':
                    aux = new Bispo(p.Cor, Tab);
                    return aux;
                case 'B':
                    aux = new Bispo(p.Cor, Tab);
                    return aux;

                case 'c':
                    aux = new Cavalo(p.Cor, Tab);
                    return aux;
                case 'C':
                    aux = new Cavalo(p.Cor, Tab);
                    return aux;

                case 't':
                    aux = new Torre(p.Cor, Tab);
                    return aux;
                case 'T':
                    aux = new Torre(p.Cor, Tab);
                    return aux;

                default:
                    throw new TabuleiroException("O jogo quebrou por favo reinicie!");
                    
            }

            
        }
        public void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }

        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para essa peça");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição invalida!");
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca obj in capturadas)
            {
                if (obj.Cor == cor)
                {
                    aux.Add(obj);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca obj in pecas)
            {
                if (obj.Cor == cor)
                {
                    aux.Add(obj);
                }

            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca obj in PecasEmJogo(cor))
            {
                if (obj is Rei)
                {
                    return obj;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("O jogo quebrou! por favor reinicie");
            }
            foreach (Peca obj in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = obj.MovimentosPossiveis();
                if (mat[R.Pos.Linha, R.Pos.Coluna])
                {
                    return true;
                }

            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca obj in PecasEmJogo(cor))
            {
                bool[,] mat = obj.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = obj.Pos;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca p)
        {
            Tab.ColocarPeca(p, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(p);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branca, Tab));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branca, Tab, this));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, Tab));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, Tab));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Tab));

            for (int i = 0; i < Tab.Colunas; i++)
            {
                ColocarNovaPeca(Convert.ToChar(i + 'a'), 2, new Peao(Cor.Branca, Tab, this));
            }

            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, Tab));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca('d', 8, new Dama(Cor.Preta, Tab));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preta, Tab, this));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, Tab));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, Tab));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Tab));

            for (int i = 0; i < Tab.Colunas; i++)
            {
                ColocarNovaPeca(Convert.ToChar(i + 'a'), 7, new Peao(Cor.Preta, Tab, this));
            }

        }
    }
}
