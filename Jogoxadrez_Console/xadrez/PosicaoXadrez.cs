using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class PosicaoXadrez
    {
        public int Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(int coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
