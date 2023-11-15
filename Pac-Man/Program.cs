using Raylib_cs;
using System.CodeDom.Compiler;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Random generator = new Random();

Raylib.InitWindow(800, 600, "Pac-Man");
Raylib.SetTargetFPS(60);

int [,] snow = new int[10, 10];

snow[0, 0] = 8;
snow[5, 0] = 8;
snow[5, 1] = 8;
snow[5, 2] = 8;

int space = 2;


for (int y = 0; y < snow.GetLength(1); y++)
{
    for (int x = 0; x < snow.GetLength(0); x++)
    {
        Console.SetCursorPosition(x * space, y * space);
        
        Console.Write(snow[x, y]);
    }
}

float speed = 5;
int coins = 0;
string scene = "start";

while (!Raylib.WindowShouldClose())
{
    if (scene == "start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "room1";
        }
    }
    else if (scene == "room1")
    {

    }
    else if (scene == "gameOver")
    {

    }
    else if (scene == "finished")
    {

    }

    //--------------------------------------------------------------------------------
    //              DRAWING
    //--------------------------------------------------------------------------------
    
    Raylib.BeginDrawing();
    if (scene == "start")
    {
        Raylib.ClearBackground(Color.BLACK);    

    }
    else if (scene == "room1")
    {
        Raylib.ClearBackground(Color.BLACK);
    }
    else if (scene == "gameOver")
    {
        Raylib.ClearBackground(Color.GOLD);
    }
    else if (scene == "finished")
    {
        Raylib.ClearBackground(Color.BLACK);
    }
    Raylib.EndDrawing();
}

// using System;
// using System.CodeDom.Compiler;
// using System.Linq.Expressions;
// using System.Numerics;
// using System.Security.Cryptography.X509Certificates;
// Console.OutputEncoding = System.Text.Encoding.UTF8;


// Console.BackgroundColor = ConsoleColor.Black;
// Console.ForegroundColor = ConsoleColor.White;

// //spelplan
// int [,] board = new int[16, 12];

// board[0, 0] = 8;
// board[5, 0] = 8;
// board[5, 1] = 8;
// board[5, 2] = 8;

// int space = 2;


// for (int y = 0; y < board.GetLength(1); y++)
// {
//     for (int x = 0; x < board.GetLength(0); x++)
//     {
//         Console.SetCursorPosition(x * space, y * space);
        
//         Console.Write(board[x, y]);
//     }
// }

// Console.ReadLine();

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


// Console.CursorVisible = false;
// int x = 0;
// int y = 0;
// Console.SetCursorPosition(x, y);

// while (true)
// {
//     ConsoleKey key = Console.ReadKey().Key;

//     Console.SetCursorPosition(x, y);
//     Console.Write(" ");

//     if (key == ConsoleKey.RightArrow) x++;
//     if (key == ConsoleKey.LeftArrow) x--;
//     if (key == ConsoleKey.DownArrow) y++;
//     if (key == ConsoleKey.UpArrow) x--;

//     Console.SetCursorPosition(x, y);
//     Console.Write("💀");
//     Console.ReadLine();
// }
