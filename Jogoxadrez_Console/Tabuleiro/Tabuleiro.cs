

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int linhas,int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna) 
        {
            return Pecas[linha, coluna];
        }


        public void ColocarPeca(Peca p , Posicao pos)
        {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;
        }
    }
}
