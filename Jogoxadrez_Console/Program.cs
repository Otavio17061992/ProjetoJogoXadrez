using Jogoxadrez_Console;
using tabuleiro;
using xadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();

                    Console.WriteLine("Turno: " + partida.turno);
                    Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();

                    partida.ValidarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partida.tab.Peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();

                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                    partida.RealizaJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {

                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }


            }
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadLine();
    }
}