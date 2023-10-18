Xadres de Console


Índice
Sobre o projeto
Sobre o tabuleiro
Impressão do tabuleiro no console
A exceção tabuleiroException
Sobre as peças
Peças presentes no tabuleiro
Método para colocar as peças no tabuleiro
Como foi criada a restrição de movimento para cada peça
Validar posição de origem
Posição nula
Se a peça é do jogador
Se não existe movimentos possíveis
Validar posição de destino
Jogadas especiais
Roque pequeno
Roque grande
En Passant
Promoção
Baixar o jogo!
Contato
Sobre o projeto
Este foi um projeto desenvolvido durante o curso de C# do @acenelio. A proposta principal dele é aplicar nossos conhecimentos na linguagem C# para criar um jogo de Xadrez que rodasse via console. Ele pode parecer um projeto simples, porém ele é muito mais complicado do que você imagina.

Sobre o tabuleiro
Impressão do tabuleiro no console
A impressão do tabuleiro foi a parte mais simples desse projeto. Eu utilizei um for para criar "-" com um espaço entre eles no tamanho de oito por oito, totalizando sessenta e quatro casas (o tamanho padrão de um tabuleiro de Xadrez).

Código do método imprimirTabuleiro:
public static void imprimirTabuleiro(Tabuleiro tab)
{
            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux1;

                for (int j = 0; j < tab.colunas; j++)
                { 
                        imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux;
}
E o resultado final foi este:


A exceção tabuleiroException
Foi necessária a criação de uma exceção para o tabuleiro, ela ocorre quando uma casa invalida é selecionada.

Alguns exemplos de exceções:
throw new TabuleiroException("Não existe peça na posição de origem escolhida!"); 
throw new TabuleiroException("A peça na posição de origem escolhida não é sua!");          
throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida!");          
throw new TabuleiroException("Posição de destino invalida!");
Sobre as peças
Peças presentes no tabuleiro:
Rei (x1 Branco & x1 Preto), representado pela letra R;
Dama (x1 Branco & x1 Preto), representado pela letra D;
Bispo (x2 Branco & x2 Preto), representado pela letra B;
Cavalo (x1 Branco & x1 Preto), representado pela letra C;
Torre (x1 Branco & x1 Preto), representado pela letra T;
Peão (x8 Branco & x8 Preto), representado pela letra P.
Imagem do tabuleiro com as peças:


Método para colocar as peças no tabuleiro
Eu implementei um método para colocar as peças em determinada posição. Cada peça possui a sua letra especifica, o método que mostra essa letra é este:

Código:
public override string ToString()
{
           return "R";
}
Neste caso a letra R é retornada, pois, este pedaço do código é do Rei.

Então eu necessitava de um modo de colocar esta letra no tabuleiro, então na classe PartidaXadrez eu criei dois métodos:

Método colocarNovaPeca:
public void colocarNovaPeca(char coluna, int linha, Peca peca)
{
           tab.colocarPeca(new PosicaoXadrez(coluna, linha).toPosicao(), peca);
           pecas.Add(peca);
}
Este método recebe uma coluna em char e um número, e o método toPosicao() converte esses dados em uma posição valida na matriz.

Método colocarPecas:
Neste método eu criava uma peça com o colocarNovaPeca() deste modo:

colocarNovaPeca('a', 1, new Torre(tab, Cor.Branco));
Como foi criada a restrição de movimento para cada peça
Na classe PartidaXadrez foram criados dois métodos, o método validarPosicaoDeOrigem e o método validarPosicaoDeDestino.

Validar posição de origem:
Este método recebe uma posição informada pelo usuário (a coordenada de peça que ele quer mover). Ele foi dividido em tês if's.

1. Posição nula
Para testar se uma posição é nula eu utilizei a posição informada pelo usuário e a testei com o seguinte código:

if ( tab.peca(pos) == null)
{
    throw new TabuleiroException(" Não existe peça na posição de origem escolhida!");
}
2. Se a peça escolhida é do jogador
Eu tive que testar se a peça escolhida era da cor do jogador atual, para testar foi utilizado o seguinte código:

if (jogadorAtual != tab.peca(pos).cor)
{
     throw new TabuleiroException("Uma peça de origem escolhida não é sua!");
}
3. Se não existem movimentos possíveis
Eu testei se a peça selecionada possuía movimentos possíveis, caso fosse escolhida uma peça que não podia se mover ocorria uma exceção.

if ( !tab.peca(pos).existeMovimentosPossiveis())
{
         throw new TabuleiroException("Não há movimentos possíveis para uma peça de origem escolhida!");
}
Validando posição de destino
Este método recebe uma posição informada pelo usuário (a coordenada para onde ele quer ir). Para este método foi utilizado apenas um if.

if ( !tab.peca(origem).podeMoverPara(destino))
{
           throw new TabuleiroException ("Posição de destino invalida!");
}
Jogadas especiais
Neste tópico eu mencionarei as jogadas especiais implementadas no jogo.

1. Roque Pequeno
O roque pequeno ocorre quando o rei e uma torre não se moveram, e entre eles possuem duas casas vazias.

// #jogadaespecial roque pequeno
if (p is Rei && destino.Coluna == origem.Coluna + 2)
{
       Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
       Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
       Peca T = tab.retirarPeca(origemT);
       T.incrementarMovimentos();
       tab.colocarPeca(destinoT, T);
}
2. Roque Grande
O roque pequeno ocorre quando o rei e uma torre não se moveram, e entre eles têm que possuir quatro casas vazias.

// #jogadaespecial roque grande
if (p is Rei && destino.Coluna == origem.Coluna - 2)
{
       Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
       Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
       Peca T = tab.retirarPeca(origemT);
       T.incrementarMovimentos();
       tab.colocarPeca(destinoT, T);
}
3. En Passant
O En Passant ocorre quando um peão adversário avança duas casas no seu primeiro movimento na tentativa de evitar um confronto com um peão avançado (se for um peão branco na linha 5, se for um preto na linha 4) e um peão pode fazer a captura do mesmo modo.

Imagem ilustrativa


Imagem obtida neste site

Codigo
// #jogadaespecial en passant
if (p is Peao)
{
     if (origem.Coluna != destino.Coluna && pecaCapturada == null)
     {
           Posicao posP;
           if (p.cor == Cor.Branco)
           {
                      posP = new Posicao(destino.Linha + 1, destino.Coluna);
           }
           else
           {
                      posP = new Posicao(destino.Linha - 1, destino.Coluna);
           }
           pecaCapturada = tab.retirarPeca(posP);
           capturadas.Add(pecaCapturada);
     }
}
4. Promoção
A jogada promoção ocorre quando um peão chega no limite adversário do tabuleiro, então o peão pode se torna: Dama, Bispo, Cavalo e uma Torre. Para esta jogada especial foi necessário criar uma interação com o usuário para ele escolher qual peça ele quer tornar, e depois promover o peão.

Exemplo de promoção de um peão para um cavalo:
case 'C':
     Peca cavalo = new Cavalo(tab, p.cor);
     tab.colocarPeca(destino, cavalo);
     pecas.Add(cavalo);
     break;
case 'c':
     Peca cavalo1 = new Cavalo(tab, p.cor);
     tab.colocarPeca(destino, cavalo1);
     pecas.Add(cavalo1);
     break;
