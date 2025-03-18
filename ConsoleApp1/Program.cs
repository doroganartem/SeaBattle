class Program{
    static void PlayerTurn()
    {
        int x, y;
        Console.Write("Введіть координати пострілу (x y): ");
        x = int.Parse(Console.ReadLine());
        y = int.Parse(Console.ReadLine());
        if (computerBoard[x, y] == 'S')
        {
            Console.WriteLine("Влучання!");
            computerBoard[x, y] = 'X';
        }
        else
        {
            Console.WriteLine("Мимо!");
            computerBoard[x, y] = 'O';
        }
    }

    static void ComputerTurn()
    {
        int x, y;
        do
        {
            Random rand = new Random();
            x = rand.Next(1,12);
            y = rand.Next(1,10);

        } while (playerBoard[x, y] == 'X' || playerBoard[x, y] == 'O');

        if (playerBoard[x, y] == 'S')
        {
            Console.WriteLine($"Бот влучив у ({x}, {y})!");
            playerBoard[x, y] = 'X';
        }
        else
        {
            Console.WriteLine($"Бот промахнувся в ({x}, {y}).");
            playerBoard[x, y] = 'O';
        }
    }
}