using System.Linq;
namespace RoboTupiniquim
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            int robo1X = 0;
            int robo1Y = 0;
            char robo1Direcao = 'N';
            int robo2X = 0;
            int robo2Y = 0;
            char robo2Direcao = 'N';
            bool roboUm = true;
            char roboDaVez = '1';

            Console.Clear();
            Console.WriteLine("--- Robô InterEspacial ---\n");

            Console.WriteLine("Informe a medida do plano cartesiano separado por virgula: ex (5,5)");
            string plano = Console.ReadLine()!;

            var grid = plano.Split(",");
            var gridX = int.Parse(grid[0]);
            var gridY = int.Parse(grid[1]);
            bool coordenadasValidas = true;

            do
            {
                Console.Write("Informe em número inteiro a posição inicial X do robô 1: ");
                robo1X = int.Parse(Console.ReadLine()!);

                Console.Write("Informe em número inteiro a posição inicial Y do robô 1: ");
                robo1Y = int.Parse(Console.ReadLine()!);

                Console.Write("Informe a direção cardial do robô 1: [ N , S , L , O  ]: ");
                robo1Direcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

                Console.Clear();
                Console.Write("Informe em número inteiro a posição inicial X do robô 2: ");
                robo2X = int.Parse(Console.ReadLine()!);

                Console.Write("Informe em número inteiro a posição inicial Y do robô 2: ");
                robo2Y = int.Parse(Console.ReadLine()!);

                System.Console.Write("Informe a direção cardial do robô 2: [ N , S , L , O  ]: ");
                robo2Direcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

                coordenadasValidas = VerificaCoordenadas(gridX, gridY, robo1X, robo1Y, robo2X, robo2Y);
                if (!coordenadasValidas)
                {
                    Console.WriteLine($"Coordenadas fora do plano cartesiano do tamanho {plano}\n Tecle para continuar");
                    Console.ReadKey();
                    continue;
                }

            } while (!coordenadasValidas);


            Console.Clear();
            Console.WriteLine("Para movimentar o robô digite uma ou mais coordenadas. Ex: MMMEEDD\n" +
                   "Para avançar tecle M, para direita tecle D, para esquerda tecle E.\nTecle para iniciar.");
            Console.ReadKey();

            while (continuar)
            {
                int _robo1X = 0;
                int _robo1Y = 0;
                int _robo2X = 0;
                int _robo2Y = 0;

                roboDaVez = roboUm ? '1' : '2';
                Console.Clear();

                InformaCoordenadas(robo1X, robo1Y, robo1Direcao, robo2X, robo2Y, robo2Direcao, roboDaVez);
                Console.Write("Informe as coordenadas:\n => ");

                string coordenadas = Console.ReadLine()!;

                foreach (var instrucao in coordenadas.ToUpper())
                {
                    if (roboDaVez == '1')
                    {
                        switch (instrucao)
                        {
                            case 'D':
                                robo1Direcao = Direita(robo1Direcao);
                                break;

                            case 'E':
                                robo1Direcao = Esquerda(robo1Direcao);
                                break;

                            case 'M':
                                (_robo1X, _robo1Y) = Mover(robo1Direcao, robo1Y, robo1X);

                                robo1X = (_robo1X <= gridX && _robo1X >= 0) ? _robo1X : robo1X;
                                robo1Y = (_robo1Y <= gridY && _robo1Y >= 0) ? _robo1Y : robo1Y;
                                break;

                            default:
                                Console.WriteLine("Opção inválida");
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        switch (instrucao)
                        {
                            case 'D':
                                robo2Direcao = Direita(robo2Direcao);
                                break;

                            case 'E':
                                robo2Direcao = Esquerda(robo2Direcao);
                                break;

                            case 'M':
                                (_robo2X, _robo2Y) = Mover(robo2Direcao, robo2Y, robo2X);

                                robo2X = (_robo2X <= gridX && _robo2X >= 0) ? _robo2X : robo2X;
                                robo2Y = (_robo2Y <= gridY && _robo2Y >= 0) ? _robo2Y : robo2Y;
                                break;

                            default:
                                Console.WriteLine("Opção inválida");
                                Console.ReadKey();
                                break;
                        }
                    }
                }

                if ((_robo2X > gridX || _robo2Y > gridY) || (_robo2X < 0 || _robo2Y < 0) || (_robo1X > gridX || _robo1Y > gridY) || (_robo1Y < 0 || _robo1X < 0))
                {
                    Console.WriteLine($"Coordenadas no limite do plano cartesiano do tamanho {plano}\nTecle para continuar!");
                    Console.ReadKey();
                    roboUm = !roboUm;
                    continue;
                }

                InformaCoordenadasAposMover(robo1X, robo1Y, robo1Direcao, robo2X, robo2Y, robo2Direcao, roboDaVez);
                roboUm = !roboUm;
            }
        }



        static bool VerificaCoordenadas(int gridX, int gridY, int robo1X, int robo1Y, int robo2X, int robo2Y)
        {
            return (robo1Y > gridY || robo2Y > gridY ? false : robo1X > gridX || robo2X > gridX ? false : robo1X < 0 || robo2X < 0 ? false : robo1Y < 0 || robo2Y < 0 ? false : true);
        }


        static void InformaCoordenadas(int robo1X, int robo1Y, char robo1Direcao, int robo2X, int robo2Y, char robo2Direcao, char roboDaVez)
        {
            System.Console.WriteLine($"Você está controlando o robô [{roboDaVez}]\nSua atual posição é {(roboDaVez == '1' ? robo1X : robo2X, roboDaVez == '1' ? robo1Y : robo2Y, roboDaVez == '1' ? robo1Direcao : robo2Direcao)}");
        }


        static void InformaCoordenadasAposMover(int robo1X, int robo1Y, char robo1Direcao, int robo2X, int robo2Y, char robo2Direcao, char roboDaVez)
        {
            System.Console.WriteLine($"O robô [{roboDaVez}] foi para posição {(roboDaVez == '1' ? robo1X : robo2X, roboDaVez == '1' ? robo1Y : robo2Y, roboDaVez == '1' ? robo1Direcao : robo2Direcao)}");
            System.Console.Write("\nTecle para continuar");
            Console.ReadKey();
        }


        static char Direita(char direcao)
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
            return direcao;
        }


        static char Esquerda(char direcao)
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
            return direcao;
        }


        static (int, int) Mover(char direcao, int Y, int X)
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
            return (X, Y);
        }
    }
}