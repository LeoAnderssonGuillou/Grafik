﻿using System;
using Raylib_cs;

namespace Grafik_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Grafiktest");
            int cycle = 0;
            int green = 0;
            int more = 1;

            Texture2D walter = Raylib.LoadTexture("walter.png");
            Texture2D walter2 = Raylib.LoadTexture("walter2.png");

            float xDistance = 0;
            float yDistance = 0;
            float xSpeed = 0;
            float ySpeed = 0;
            float acc = 0.0002f;
            bool moving = true;

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

                    //Borders
                    if (xDistance > 698)
                    {
                        xDistance = 698;
                        xSpeed = 0f;
                    }
                    if (xDistance < 0)
                    {
                        xDistance = 0;
                        xSpeed = 0f;
                    }
                    if (yDistance > 480)
                    {
                        yDistance = 480;
                        ySpeed = 0f;
                    }
                    if (yDistance < 0)
                    {
                        yDistance = 0;
                        ySpeed = 0f;
                    }

                    //Friction
                    if (xDistance <= 800)
                    {
                        xSpeed = xSpeed - 0.00005f;
                    }
                    if (xSpeed < 0)
                    {
                        xSpeed = xSpeed + 0.00005f;
                    }
                    if (ySpeed > 0)
                    {
                        ySpeed = ySpeed - 0.00005f;
                    }
                    if (ySpeed < 0)
                    {
                        ySpeed = ySpeed + 0.00005f;
                    }

                    //Draw Walter
                    if (moving == true)
                    {
                        Raylib.DrawTexture(walter2, (int)xDistance, (int)yDistance, Color.WHITE);
                    }
                    else
                    {
                        Raylib.DrawTexture(walter, (int)xDistance, (int)yDistance, Color.WHITE);
                    }
                }
                Raylib.EndDrawing();
            }
        }
    }
}
