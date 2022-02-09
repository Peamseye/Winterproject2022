﻿using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Winter project: Raylib");
Raylib.SetTargetFPS(60);


Texture2D playerImage = Raylib.LoadTexture("TopDownPlayer.png");
Texture2D zombieImage = Raylib.LoadTexture("TopDownZombie.png");

Texture2D houseImage = Raylib.LoadTexture("TopDownHouse.png");
Texture2D outsideImage = Raylib.LoadTexture("TopDownOut.png");


Rectangle wallRect1 = new Rectangle(160, 70, 10, 60);
Rectangle wallRect2 = new Rectangle(170, 70, 175, 10);
Rectangle wallRect3 = new Rectangle(345, 70, 10, 60);


while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();


    Raylib.ClearBackground(Color.BLUE);

    Raylib.DrawTexture(houseImage, 0, 0, Color.WHITE);
    Raylib.DrawTexture(playerImage, 220, 90, Color.WHITE);

    Raylib.DrawRectangleRec(wallRect1, Color.LIME);
    Raylib.DrawRectangleRec(wallRect2, Color.LIME);
    Raylib.DrawRectangleRec(wallRect3, Color.LIME);

    Raylib.EndDrawing();
}