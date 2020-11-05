using System;
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

            while (!Raylib.WindowShouldClose())
            {
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

                xDistance = xDistance + xSpeed;
                yDistance = yDistance + ySpeed;

                if (xSpeed > 0)
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

                if (moving == true)
                {
                    Raylib.DrawTexture(walter2, (int)xDistance, (int)yDistance, Color.WHITE);
                }
                else
                {
                    Raylib.DrawTexture(walter, (int)xDistance, (int)yDistance, Color.WHITE);
                }


                Raylib.EndDrawing();

            }
        }
    }
}
