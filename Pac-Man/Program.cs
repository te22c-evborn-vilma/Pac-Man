using Raylib_cs;
using System.CodeDom.Compiler;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Raylib.InitWindow(800, 700, "Pac-Man");
Raylib.SetTargetFPS(60);

//movement för spelaren
Vector2 movement = new Vector2(0, 0);

Rectangle charRect = new Rectangle(10, 292, 24, 24);
Rectangle gate = new Rectangle(352, 224, 128, 5);
Rectangle door = new Rectangle(768, 288, 32, 32);

// ------ändra så att de har olika färg --------------------------------------------
// List<Rectangle> enemies = new();
// enemies.Add(new Rectangle(352, 256, 32, 32)); //röd fiende
// enemies.Add(new Rectangle(416, 256, 32, 32)); //turkos fiende
// enemies.Add(new Rectangle(384, 288, 32, 32)); //rosa fiende

List<Rectangle> coins = new(); //
coins.Add(new Rectangle(416, 32, 32, 32));
coins.Add(new Rectangle(96, 96, 32, 32));
coins.Add(new Rectangle(640, 160, 32, 32));
coins.Add(new Rectangle(32, 544, 32, 32));
coins.Add(new Rectangle(320, 512, 32, 32));
coins.Add(new Rectangle(608, 416, 32, 32));


// jdet var enkelt att addera alla positioner för varje ruta och man kan hitta kollisioner mellan objekten i listan och spelarens karaktär
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

// vertikal
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

// bestämmmer hastigheten för spelaren så fort speed används (se längre ned)
float speed = 3;

// scenen är "start" från början, sen byts den till andra scener under spelets gång
string scene = "start";

// startpoängen för spelaren - int eftersom det är ett tal
int points = 0;

Vector2 startU = new Vector2(395, 0);
Vector2 endD = new Vector2(395, 700);

Vector2 startL = new Vector2(0, 345);
Vector2 endR = new Vector2(800, 345);

static void CatchCoins()
 {
    CoinsDisappear();
    // om spelaren rör ett mynt:
    //      + 1 poäng
    //      myntet försvinner/eller byter plats (ny metod?)
    // if (Raylib.CheckCollisionRecs(charRect, coin))
    // {

    // }
}
static void CoinsDisappear()
{
        
}


while (!Raylib.WindowShouldClose())
{
    // ------------------------------------------------------------------------------
    //          SPELETS LOGIK
    // ------------------------------------------------------------------------------

    // startscenen - tryck på space-knappen för att gå vidare till nästa scen i spelet
    if (scene == "start")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "info";
        }
    }

    // information - instruktioner till spelaren
    else if (scene == "info")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            scene = "room1";
        }
    }
    
    // "rum 1" - ser till spelaren kan röra sig i labyrinten och bestämmer vad som händer när spelaren kolliderar med olika objekt i spelet
    else if (scene == "room1")
    {
        movement = Vector2.Zero;
        
        // beroende på vilken tangent som är nedtryckt kommer spelaren moevement - rörelse - ändras
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
        
        // när movements position förändras så ändras också karaktärens position
        charRect.x += movement.X;
        charRect.y += movement.Y;

        bool undoCharX = false;     //ångra
        bool undoCharY = false;
        
        //-------------------------------------------
        // KOLLISIONER - room1
        //-------------------------------------------
        
        // spelet byter scen och spelaren får 50 poäng om den når dörren på andra sidan
        if (Raylib.CheckCollisionRecs(charRect, door))
        {
            scene = "finished";
            points += 50;
        }

        // ser till så att spelaren inte kan gå igenom väggar
        foreach(Rectangle wall in walls)
        {
            if (Raylib.CheckCollisionRecs(charRect, wall) || Raylib.CheckCollisionRecs(charRect, gate))
                {
                    undoCharX = true;
                    undoCharY = true;
                }
        }
        
        if (undoCharX == true)
        {
            charRect.x -= movement.X;
        }
        if (undoCharY == true)
        {
            charRect.y -= movement.Y;
        }
        
        
        foreach(Rectangle coin in coins)
        {
            if (Raylib.CheckCollisionRecs(charRect, coin))
            {
                points++;
                // ta bort myntet/byt plats (random) - se till att man bara får ett poäng
            }
        }
        // Enemies rör på sig, antingen random eller fram och tillbaka
        // foreach(Rectangle enemy in enemies)
        // {
        //     if (Raylib.CheckCollisionRecs(charRect, enemy))
        //     {
        //         scene = "gameOver";
        //     }
        // }

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
    // start - scenen som dyker upp när spelaren startar spelets
    if (scene == "start")
    {
        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawText("press space to start", 280, 305, 32, Color.BLUE);
        Raylib.DrawText("press space to start", 275, 300, 32, Color.WHITE);
    }

    // info-scenen ger instruktioner till spelaren
    else if (scene == "info")
    {
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawText("move your player by pressing the arrows on the keyboard", 50, 300, 24, Color.WHITE);
        Raylib.DrawText("look out for the enemies!", 50, 600, 24, Color.WHITE);
        Raylib.DrawLineEx(startU, endD, 10, Color.WHITE);
        Raylib.DrawLineEx(startL, endR, 10, Color.WHITE);
    }

    //room1 = nivå 1 - här är själva spelet - med mer tid kan fler nivåer läggas tid
    else if (scene == "room1")
    {
        Raylib.ClearBackground(Color.BLACK);
        
        Raylib.DrawText($"points: {points}", 50, 654, 32, Color.WHITE);

        Raylib.DrawRectangleRec(charRect, Color.YELLOW); //spelarens karaktär
        Raylib.DrawRectangleRec(gate, Color.WHITE); //gate - bara fienden kan passera här
        
        //door - når spelaren dörren kan den gå vidare, i det här fallet till "finished"-scenen
        Raylib.DrawRectangleRec(door, Color.MAGENTA); 
        
        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.DARKBLUE);
        }
        foreach (Rectangle coin in coins)
        {
            Raylib.DrawRectangleRec(coin, Color.GOLD);
        }
        // foreach (Rectangle enemy in enemies)
        // {
        //     Raylib.DrawRectangleRec(enemy, Color.RED);
        // }
    }

    // om spelaren rör en fiende förlorar spelaren - game over-scenen dyker upp
    else if (scene == "gameOver")
    {
        Raylib.ClearBackground(Color.RED);

        Raylib.DrawText("you lost", 250, 300, 32, Color.WHITE);
    }

    // finished-scenen kommer upp när spelaren har nått sista dörren, i det här fallet finns det bara en 
    else if (scene == "finished")
    {
        Raylib.ClearBackground(Color.WHITE);

        Raylib.DrawText($"congratulations!\nyou finished\nwith {points} point(s)", 275, 300, 32, Color.BLACK);
    }
    Raylib.EndDrawing();
}

// förbättringar:
// - spelaren har ett visst antal liv, förlorar ett liv varje gång den stöter på en fiende
// - finns speciella mynt som ger mer poäng eller ett extra hjärta
// - fler nivåer: efter rum 1 kommer rum 2 osv - bygger på poängen från varje nivå
// - high score sparas om man vill köra en ny runda
// - ökad svårighetsgrad vid högre nivåer: fler fiender och nya hinder