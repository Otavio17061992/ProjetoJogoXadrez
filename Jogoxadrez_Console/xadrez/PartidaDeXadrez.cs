using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public  Cor jogadorAtual { get; private set; }
        public bool terminada { get ; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            ColocarPecas();
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca pc = tab.RetirarPeca(origem);
            pc.incrementarQtMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(pc, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);

            turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.Peca(pos)  == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if(jogadorAtual != tab.Peca(pos).cor)
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }

            if (!tab.Peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não ha movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao orgiem,Posicao destino)
        {
            if(!tab.Peca(orgiem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino invalido!");
            }
        }


        public void MudaJogador()
        {
            if(jogadorAtual == Cor.Branca) 
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
    

        private void ColocarPecas()
        {
            // pecas brancas
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());


            // peças pretas
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }


    }
}
