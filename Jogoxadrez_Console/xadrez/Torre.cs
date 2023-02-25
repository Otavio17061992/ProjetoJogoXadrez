using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);


            //norte
            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
                if(tab.Peca(pos)!= null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                else
                {
                    pos.Linha = pos.Linha - 1;
                }
            }

            // sul
            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                else
                {
                    pos.Linha = pos.Linha + 1;
                }
            }

            // leste
            pos.DefinirValores(posicao.Linha, posicao.Coluna +1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                else
                {
                    pos.Coluna = pos.Coluna + 1;
                }
            }

            // oeste
            pos.DefinirValores(posicao.Linha, posicao.Coluna-1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                else
                {
                    pos.Coluna = pos.Coluna - 1;
                }
            }


            return mat;
        }
    }
}
