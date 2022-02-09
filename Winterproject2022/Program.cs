using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Winter project: Raylib");
Raylib.SetTargetFPS(60);


Texture2D playerImage = Raylib.LoadTexture("TopDownZombie.png");
Rectangle playerRect = new Rectangle(10, 10, 32, 32);

while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();


    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawRectangleRec(playerRect, Color.LIME);
    Raylib.DrawTexture(playerImage, 45, 70, Color.WHITE);
    Raylib.EndDrawing();
}