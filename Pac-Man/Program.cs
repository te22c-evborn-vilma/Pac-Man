using Raylib_cs;
using System.CodeDom.Compiler;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Random generator = new Random();

Raylib.InitWindow(800, 640, "Pac-Man");
Raylib.SetTargetFPS(60);

Vector2 movement = new Vector2(0, 0);

Rectangle charRect = new Rectangle(10, 292, 24, 24);
Rectangle gate = new Rectangle(352, 224, 128, 5);
Rectangle door = new Rectangle(768, 288, 32, 32);



// ------ändra så att de har olika färg --------------------------------------------
List<Rectangle> enemies = new();
enemies.Add(new Rectangle(352, 256, 32, 32)); //röd fiende
enemies.Add(new Rectangle(416, 256, 32, 32)); //turkos fiende
enemies.Add(new Rectangle(384, 288, 32, 32)); //rosa fiende




List<Rectangle> coins = new(); //
coins.Add(new Rectangle(416, 32, 32, 32));
coins.Add(new Rectangle(96, 96, 32, 32));
coins.Add(new Rectangle(640, 160, 32, 32));
coins.Add(new Rectangle(32, 544, 32, 32));
coins.Add(new Rectangle(320, 512, 32, 32));
coins.Add(new Rectangle(608, 416, 32, 32));

// Vector2 midPoint = new Vector2(20, 320);
// Texture2D characterIMG = Raylib.LoadTexture("pic.png");

List<Rectangle> walls = new();
// horisontell
walls.Add(new Rectangle(0, 0, 800, 32));
walls.Add(new Rectangle(0, 608, 800, 32));
walls.Add(new Rectangle(32, 256, 160, 32));
walls.Add(new Rectangle(32, 320, 160, 32));
walls.Add(new Rectangle(608, 256, 160, 32));
walls.Add(new Rectangle(608, 320, 160, 32));
walls.Add(new Rectangle(64, 64, 64, 32));
walls.Add(new Rectangle(160, 64, 64, 64));
walls.Add(new Rectangle(320, 64, 160, 32));
walls.Add(new Rectangle(576, 64, 64, 64));
walls.Add(new Rectangle(672, 64, 64, 32));
walls.Add(new Rectangle(64, 128, 64, 32));
walls.Add(new Rectangle(672, 128, 64, 32));
walls.Add(new Rectangle(288, 160, 64, 32));
walls.Add(new Rectangle(448, 160, 64, 32));
walls.Add(new Rectangle(128, 192, 64, 32));
walls.Add(new Rectangle(608, 192, 64, 32));
walls.Add(new Rectangle(288, 224, 64, 32));
walls.Add(new Rectangle(448, 224, 64, 32));
walls.Add(new Rectangle(288, 352, 224, 32));
walls.Add(new Rectangle(128, 384, 96, 32));
walls.Add(new Rectangle(576, 384, 96, 32));
walls.Add(new Rectangle(128, 480, 96, 32));
walls.Add(new Rectangle(576, 480, 96, 32));
walls.Add(new Rectangle(64, 544, 160, 32));
walls.Add(new Rectangle(320, 544, 160, 32));
walls.Add(new Rectangle(576, 544, 160, 32));

// vertikal288, 32, 64
walls.Add(new Rectangle(0, 32, 32, 256));
walls.Add(new Rectangle(768, 32, 32, 256));
walls.Add(new Rectangle(256, 64, 32, 64));
walls.Add(new Rectangle(512, 64, 32, 64));
walls.Add(new Rectangle(384, 96, 32, 96));
walls.Add(new Rectangle(320, 128, 32, 32));
walls.Add(new Rectangle(448, 128, 32, 32));
walls.Add(new Rectangle(64, 160, 32, 64));
walls.Add(new Rectangle(160, 160, 32, 32));
walls.Add(new Rectangle(224, 160, 32, 96));
walls.Add(new Rectangle(544, 160, 32, 96));
walls.Add(new Rectangle(608, 160, 32, 32));
walls.Add(new Rectangle(704, 160, 32, 64));
walls.Add(new Rectangle(288, 256, 32, 96));
walls.Add(new Rectangle(480, 256, 32, 96));
walls.Add(new Rectangle(224, 288, 32, 64));
walls.Add(new Rectangle(544, 288, 32, 64));
walls.Add(new Rectangle(0, 320, 32, 320));
walls.Add(new Rectangle(768, 320, 32, 320));
walls.Add(new Rectangle(64, 384, 32, 128));
walls.Add(new Rectangle(704, 384, 32, 128));
walls.Add(new Rectangle(192, 416, 32, 32));
walls.Add(new Rectangle(256, 416, 32, 64));
walls.Add(new Rectangle(320, 416, 32, 96));
walls.Add(new Rectangle(384, 416, 32, 128));
walls.Add(new Rectangle(448, 416, 32, 96));
walls.Add(new Rectangle(512, 416, 32, 64));
walls.Add(new Rectangle(576, 416, 32, 32));
walls.Add(new Rectangle(128, 448, 32, 32));
walls.Add(new Rectangle(640, 448, 32, 32));
walls.Add(new Rectangle(256, 512, 32, 96));
walls.Add(new Rectangle(512, 512, 32, 96));


float speed = 3;
string scene = "start";

static void PlaceCoins()
{
    int i = 0;

    while (i < 10)
    {
        //placera coins på flera ställen
        i++;
    }
}
static void CatchCoins()
{
    // om spelaren rör ett mynt:
    //      + 1 poäng
    //      myntet försvinner/eller byter plats (ny metod?)
    // if (Raylib.CheckCollisionRecs(charRect, coin))
    // {

    // }
}


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
        movement = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            movement.X = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            movement.X = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        {
            movement.Y = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        {
            movement.Y = 1;
        }
        if (movement.Length() > 0)
        {
        movement = Vector2.Normalize(movement) * speed;
        }
   
        charRect.x += movement.X;
        charRect.y += movement.Y;

        bool undoX = false;     //ångra
        bool undoY = false;

        // Kolla kollisioenr

        if (Raylib.CheckCollisionRecs(charRect, door))
        {
            Console.WriteLine("YES");
            scene = "finished";
            // points++;
        }

        // Raylib.GetMousePosition vector circle

        foreach(Rectangle wall in walls)
        {
            if (Raylib.CheckCollisionRecs(charRect, wall))
                {
                    // scene = "finished";
                    undoX = true;
                    undoY = true;
                }
        }
        
        if (undoX == true)
        {
            charRect.x -= movement.X;
        }
        if (undoY == true)
        {
            charRect.y -= movement.Y;
        }

        PlaceCoins();

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
        Raylib.DrawText("press space to start", 280, 305, 32, Color.BLUE);
        Raylib.DrawText("press space to start", 275, 300, 32, Color.WHITE);

    }
    else if (scene == "room1")
    {
        Raylib.ClearBackground(Color.BLACK);
        
        Raylib.DrawRectangleRec(charRect, Color.YELLOW); //player
        Raylib.DrawRectangleRec(gate, Color.WHITE); //gate with the enemies
        Raylib.DrawRectangleRec(door, Color.MAGENTA); //door that leads to the next level

        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.DARKBLUE);
        }
        foreach (Rectangle coin in coins)
        {
            Raylib.DrawRectangleRec(coin, Color.GOLD);
        }
        foreach (Rectangle enemy in enemies)
        {
            Raylib.DrawRectangleRec(enemy, Color.RED);
        }
    }
    else if (scene == "gameOver")
    {
        Raylib.ClearBackground(Color.RED);

        Raylib.DrawText("you lost", 275, 300, 32, Color.WHITE);
    }
    else if (scene == "finished")
    {
        Raylib.ClearBackground(Color.WHITE);

        Raylib.DrawText("congratulations!\nyou finished", 275, 300, 32, Color.BLACK);
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
