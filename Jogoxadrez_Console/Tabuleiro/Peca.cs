﻿

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab ,Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.qteMovimentos = 0;
            this.tab = tab;
        }


        public void incrementarQtMovimentos()
        {
            qteMovimentos++;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();

            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }

                }
            }
            return false;
        }


        public abstract bool[,] movimentosPossiveis();
    }
}
