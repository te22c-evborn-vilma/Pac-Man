using System;
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Console.BackgroundColor = ConsoleColor.Black;
// Console.ForegroundColor = ConsoleColor.White;

// Start();
// Room1();
// GameOver();
// Finished();

// static void Start()
// { 
//     Console.WriteLine("PAC-MAN");
//     Console.ReadLine();
// }

// // första rummet
// static void Room1()
// {

// }

// static void GameOver()
// {

// }

// static void Finished()
// {

// }


Console.CursorVisible = false;
int x = 0;
int y = 0;
Console.SetCursorPosition(x, y);

while (true)
{
    ConsoleKey key = Console.ReadKey().Key;

    Console.SetCursorPosition(x, y);
    Console.Write(" ");

    if (key == ConsoleKey.RightArrow) x++;
    if (key == ConsoleKey.LeftArrow) x--;
    if (key == ConsoleKey.DownArrow) y++;
    if (key == ConsoleKey.UpArrow) x--;

    Console.SetCursorPosition(x, y);
    Console.Write("💀");
}
