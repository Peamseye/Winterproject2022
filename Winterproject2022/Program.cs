using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Winter project: Raylib");
Raylib.SetTargetFPS(60);

while ((!Raylib.WindowShouldClose()))
{

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.BLUE);

    Raylib.EndDrawing();
}