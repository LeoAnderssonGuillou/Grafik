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

            Texture2D walter = Raylib.LoadTexture("walter.png");
            Texture2D walter2 = Raylib.LoadTexture("walter2.png");
            Texture2D floppa = Raylib.LoadTexture("floppa.png");

            float xDistance = 0;
            float yDistance = 0;
            float xSpeed = 0;
            float ySpeed = 0;
            float acc = 0.0004f;
            bool moving = true;

            float friction = 0.0001f;

            float xFloppSpeed = 0f;
            float yFloppSpeed = 0f;
            float floppAcc = 0.0002f;
            float xFloppLoc = 0;
            float yFloppLoc = 0;


            string gameState = "menu";
            while (!Raylib.WindowShouldClose())
            {
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
                    xDistance = xDistance + xSpeed;
                    yDistance = yDistance + ySpeed;


                    //Move Floppa towards Walter
                    if (xFloppLoc > xDistance)
                    {
                        xFloppSpeed = xFloppSpeed - floppAcc;
                    }
                    if (xFloppLoc < xDistance)
                    {
                        xFloppSpeed = xFloppSpeed + floppAcc;
                    }
                    if (yFloppLoc > yDistance)
                    {
                        yFloppSpeed = yFloppSpeed - floppAcc;
                    }
                    if (yFloppLoc < yDistance)
                    {
                        yFloppSpeed = yFloppSpeed + floppAcc;
                    }

                    xFloppLoc = xFloppLoc + xFloppSpeed;
                    yFloppLoc = yFloppLoc + yFloppSpeed;

                    //Walter borders
                    if (xDistance > 920)
                    {
                        xDistance = 920;
                        xSpeed = 0f;
                    }
                    if (xDistance < 0)
                    {
                        xDistance = 0;
                        xSpeed = 0f;
                    }
                    if (yDistance > 670)
                    {
                        yDistance = 670;
                        ySpeed = 0f;
                    }
                    if (yDistance < 0)
                    {
                        yDistance = 0;
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
                        Raylib.DrawTexture(walter2, (int)xDistance, (int)yDistance, Color.WHITE);
                    }
                    else
                    {
                        Raylib.DrawTexture(walter, (int)xDistance, (int)yDistance, Color.WHITE);
                    }

                    Raylib.DrawTexture(floppa, (int)xFloppLoc, (int)yFloppLoc, Color.WHITE);
                }
                Raylib.EndDrawing();
            }
        }
    }
}
