﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab,cor) { }

        public override string ToString()
        {
            return "C";
        }

        private bool podeMover(Posicao pos) 
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna - 2);
            if(tab.PosicaoValida(pos) && podeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha - 2, posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha - 2, posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha - 1, posicao.Coluna + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha + 2, posicao.Coluna + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha + 2, posicao.Coluna - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(posicao.Linha + 1, posicao.Coluna - 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
