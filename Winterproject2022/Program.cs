using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Winter project: Raylib");
Raylib.SetTargetFPS(60);


Rectangle playerRect = new Rectangle(10, 10, 32, 32);




while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();

   // Raylib.DrawRectangle(10, 10, 32, 32, Color.WHITE);


    Raylib.ClearBackground(Color.BLUE);

    Raylib.DrawRectangleRec(playerRect, Color.BLACK);

    Raylib.EndDrawing();
}