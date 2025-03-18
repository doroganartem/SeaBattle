using System;
using System.Text;

Console.OutputEncoding = UTF8Encoding.UTF8;

Random random = new Random();

char[,] playerBoard = new char[10, 10];
char[,] computerBoard = new char[10, 10];
char[,] playerHits = new char[10, 10];
char[,] computerHits = new char[10, 10];

InitializeBoard(playerBoard);
InitializeBoard(computerBoard);
InitializeBoard(playerHits);
InitializeBoard(computerHits);


Console.WriteLine("# МОРСЬКИЙ БІЙ #");

void placeShips() {
    Console.WriteLine("Розсташуйте ваші кораблі: ");

}

static void InitializeBoard(char[,] board)
{
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            board[i, j] = '.';
        }
    }
}

static void DisplayBoard(char[,] board, string title)
{
    Console.WriteLine(title);
    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
    for (int i = 0; i < board.GetLength(0); i++)
    {
        Console.Write(i + " ");
        for (int j = 0; j < board.GetLength(1); j++)
        {
            Console.Write(board[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void PlayerTurn()
{
    int x, y;
    while (true)
    {
        Console.WriteLine("Введіть координати (рядок і стовпець) для вашого удару (пр. 2 3):");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');
        if (parts.Length == 2 && int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y) && x >= 0 && x < 10 && y >= 0 && y < 10)
        {
            if (computerHits[x, y] != '.')
            {
                Console.WriteLine("Ви ж вже сюди влучали! Ще раз...");
            }
            else
            {
                if (computerBoard[x, y] == 'S')
                {
                    Console.WriteLine("Пробито!");
                    computerHits[x, y] = 'H';
                }
                else
                {
                    Console.WriteLine("Промах.");
                    computerHits[x, y] = 'M';
                }
                break;
            }
        }
        else
        {
            Console.WriteLine("Не дійсні координати. Введіть ще раз: ");
        }
    }
}

void ComputerTurn()
{
    int x, y;
    do
    {
        x = random.Next(0, 10);
        y = random.Next(0, 10);
    } while (playerHits[x, y] != '.');

    if (playerBoard[x, y] == 'S')
    {
        Console.WriteLine($"Бот б'є ваш корабель у {x} {y}!");
        playerHits[x, y] = 'H';
    }
    else
    {
        Console.WriteLine($"Бот промахується у {x} {y}.");
        playerHits[x, y] = 'M';
    }
}