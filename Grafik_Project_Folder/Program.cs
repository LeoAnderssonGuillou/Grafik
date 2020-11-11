using System;
using Raylib_cs;

namespace Grafik_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1000, 750, "Grafiktest");
            int cycle = 0;
            int green = 0;
            int more = 1;

            Texture2D walterT = Raylib.LoadTexture("walter.png");
            Texture2D walterT2 = Raylib.LoadTexture("walter2.png");
            Texture2D floppaT = Raylib.LoadTexture("floppa.png");

            Rectangle walter = new Rectangle(0, 0, 80, 80);
            float xDistance = 0;
            float yDistance = 0;
            float xSpeed = 0;
            float ySpeed = 0;
            float acc = 0.0012f;
            bool moving = true;

            float friction = 0.0003f;

            Rectangle floppa = new Rectangle(0, 0, 120, 120);
            float xFloppSpeed = 0f;
            float yFloppSpeed = 0f;
            float floppAcc = 0.0006f;
            float xFloppLoc = 0;
            float yFloppLoc = 0;


            string gameState = "menu";
            while (!Raylib.WindowShouldClose())
            {
                //Menu
                if (gameState == "menu")
                {
                    Color yellow = new Color(255, 255, 0, 255);
                    Raylib.ClearBackground(yellow);
                    Raylib.DrawText("WALTER GAME", 95, 20, 80, Color.BLACK);
                    Raylib.DrawText("WALTER GAME", 95, 490, 80, Color.BLACK);

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        gameState = "play";
                    }
                }

                if (gameState == "play")
                {
                    //Background
                    Raylib.BeginDrawing();
                    Color lit = new Color(255, green, 0, 255);
                    Raylib.ClearBackground(lit);
                    cycle++;
                    if (cycle == 10)
                    {
                        cycle = 0;
                        green = green + more;
                    }
                    if (green == 255) { more = -1; }
                    if (green == 0) { more = 1; }

                    //Increase speed based on input
                    moving = false;
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        xSpeed = xSpeed + acc;
                        moving = true;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        ySpeed = ySpeed + acc;
                        moving = true;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        xSpeed = xSpeed - acc;
                        moving = true;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        ySpeed = ySpeed - acc;
                        moving = true;
                    }

                    //Change Walter location with speed
                    walter.x += xSpeed;
                    walter.y += ySpeed;

                    //Move Floppa towards Walter
                    if (floppa.x > walter.x)
                    {
                        xFloppSpeed = xFloppSpeed - floppAcc;
                    }
                    if (floppa.x < walter.x)
                    {
                        xFloppSpeed = xFloppSpeed + floppAcc;
                    }
                    if (floppa.y > walter.y)
                    {
                        yFloppSpeed = yFloppSpeed - floppAcc;
                    }
                    if (floppa.y < walter.y)
                    {
                        yFloppSpeed = yFloppSpeed + floppAcc;
                    }

                    floppa.x += xFloppSpeed;
                    floppa.y += yFloppSpeed;

                    //Walter borders
                    if (walter.x > 920)
                    {
                        walter.x = 920;
                        xSpeed = 0f;
                    }
                    if (walter.x < 0)
                    {
                        walter.x = 0;
                        xSpeed = 0f;
                    }
                    if (walter.y > 670)
                    {
                        walter.y = 670;
                        ySpeed = 0f;
                    }
                    if (walter.y < 0)
                    {
                        walter.y = 0;
                        ySpeed = 0f;
                    }

                    //Floppa borders
                    if (xFloppLoc > 880)
                    {
                        xFloppLoc = 880;
                        xFloppSpeed = 0f;
                    }
                    if (xFloppLoc < 0)
                    {
                        xFloppLoc = 0;
                        xFloppSpeed = 0f;
                    }
                    if (yFloppLoc > 630)
                    {
                        yFloppLoc = 630;
                        yFloppSpeed = 0f;
                    }
                    if (yFloppLoc < 0)
                    {
                        yFloppLoc = 0;
                        yFloppSpeed = 0f;
                    }

                    //Walter friction
                    if (xSpeed > 0)
                    {
                        xSpeed = xSpeed - friction;
                    }
                    if (xSpeed < 0)
                    {
                        xSpeed = xSpeed + friction;
                    }
                    if (ySpeed > 0)
                    {
                        ySpeed = ySpeed - friction;
                    }
                    if (ySpeed < 0)
                    {
                        ySpeed = ySpeed + friction;
                    }

                    //Floppa friction
                    if (xFloppSpeed > 0)
                    {
                        xFloppSpeed = xFloppSpeed - 0.00005f;
                    }
                    if (xFloppSpeed < 0)
                    {
                        xFloppSpeed = xFloppSpeed + 0.00005f;
                    }
                    if (yFloppSpeed > 0)
                    {
                        yFloppSpeed = yFloppSpeed - 0.00005f;
                    }
                    if (yFloppSpeed < 0)
                    {
                        yFloppSpeed = yFloppSpeed + 0.00005f;
                    }

                    //Draw characters
                    if (moving == true)
                    {
                        Raylib.DrawTexture(walterT2, (int)walter.x, (int)walter.y, Color.WHITE);
                    }
                    else
                    {
                        Raylib.DrawTexture(walterT, (int)walter.x, (int)walter.y, Color.WHITE);
                    }

                    Raylib.DrawTexture(floppaT, (int)floppa.x, (int)floppa.y, Color.WHITE);
                }
                Raylib.EndDrawing();
            }
        }
    }
}
