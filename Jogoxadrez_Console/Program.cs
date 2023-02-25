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
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tab);

                Console.Write("Origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();

                Console.Write("Destino: ");
                Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                partida.ExecutaMovimento(origem, destino);
            }
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadLine();
    }
}