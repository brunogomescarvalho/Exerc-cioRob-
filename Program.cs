Console.Clear();
bool continuar = true;

System.Console.WriteLine("--- Robô InterEspacial ---\n");

System.Console.Write("Informe a posição inicial X do robô: ");
int X = int.Parse(Console.ReadLine()!);

System.Console.Write("Informe a posição inicial Y do robô: ");
int Y = int.Parse(Console.ReadLine()!);

System.Console.Write("Informe a direção cardial do robô: ");
char direcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

do
{
    Console.Clear();
    System.Console.WriteLine(Coordenandas());
    System.Console.Write("Informe as coordenadas:\n => ");
    string coordenadas = Console.ReadLine()!;

    foreach (var instrucao in coordenadas.ToUpper())
    {
        switch (instrucao)
        {
            case 'D':
                Direita();
                break;

            case 'E':
                Esquerda();
                break;

            case 'M':
                Mover();
                break;

            default:
                System.Console.WriteLine("Opção inválida");
                Console.ReadKey();
                break;
        }
    }

    System.Console.WriteLine(Coordenandas());

} while (continuar);


string Coordenandas()
{
    return $"A coordenada atual do robô é:\n\nX = {X}\nY = {Y}\nDireção = {direcao}\n";
}

void Direita()
{
    if (direcao == 'N')
    {
        direcao = 'L';
    }
    else if (direcao == 'L')
    {
        direcao = 'S';
    }
    else if (direcao == 'S')
    {
        direcao = 'O';
    }
    else if (direcao == 'O')
    {
        direcao = 'N';
    }
}

void Esquerda()
{
    if (direcao == 'N')
    {
        direcao = 'O';
    }
    else if (direcao == 'O')
    {
        direcao = 'S';
    }
    else if (direcao == 'S')
    {
        direcao = 'L';
    }
    else if (direcao == 'L')
    {
        direcao = 'N';
    }
}

void Mover()
{
    if (direcao == 'N')
    {
        Y += 1;
    }
    else if (direcao == 'S')
    {
        Y -= 1;
    }
    else if (direcao == 'L')
    {
        X += 1;
    }
    else if (direcao == 'O')
    {
        X -= 1;
    }
}







