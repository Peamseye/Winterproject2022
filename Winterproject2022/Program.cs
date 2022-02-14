using System;
using Raylib_cs;

//Spelfönster
Raylib.InitWindow(800, 600, "Winter project: Raylib");
Raylib.SetTargetFPS(60);


//Spelarens Startposition
Texture2D playerImage = Raylib.LoadTexture("TopDownPlayer.png");
Rectangle playerRect = new Rectangle(220, 90, playerImage.width, playerImage.height);


//Zombiens Startposition
Texture2D zombieImage = Raylib.LoadTexture("TopDownZombie.png");
Rectangle zombieRect = new Rectangle(100, 100, zombieImage.width, zombieImage.height);

//Bakgrundens Texturer
Texture2D houseImage = Raylib.LoadTexture("TopDownHouse.png");
Texture2D outsideImage = Raylib.LoadTexture("TopDownOut.png");




//Avmarkering för kollision (Vägg, Sovrummet)
Rectangle bedwallRect1 = new Rectangle(190, 70, 10, 60);
Rectangle bedwallRect2 = new Rectangle(190, 70, 140, 10);
Rectangle bedwallRect3 = new Rectangle(320, 70, 10, 60);
Rectangle bedwallRect4 = new Rectangle(190, 130, 60, 10);
Rectangle bedwallRect5 = new Rectangle(290, 130, 40, 10);
Rectangle bedwallRect6 = new Rectangle(245, 130, 10, 30);
Rectangle bedwallRect7 = new Rectangle(285, 130, 10, 30);




//Avmarkering för kollision (Vägg, Hallen)
Rectangle hallwallRect1 = new Rectangle(75, 345, 445, 10);
Rectangle hallwallRect2 = new Rectangle(515, 185, 45, 10);
Rectangle hallwallRect3 = new Rectangle(560, 145, 10, 50);
Rectangle hallwallRect4 = new Rectangle(515, 185, 10, 65);
Rectangle hallwallRect5 = new Rectangle(515, 295, 10, 60);
Rectangle hallwallRect6 = new Rectangle(525, 240, 20, 10);
Rectangle hallwallRect7 = new Rectangle(525, 295, 20, 10);
Rectangle hallwallRect8 = new Rectangle(560, 145, 135, 10);
Rectangle hallwallRect9 = new Rectangle(685, 70, 10, 75);
Rectangle hallwallRect10 = new Rectangle(445, 70, 250, 10);
Rectangle hallwallRect11 = new Rectangle(445, 70, 10, 175);
Rectangle hallwallRect12 = new Rectangle(425, 235, 20, 10);
Rectangle hallwallRect13 = new Rectangle(415, 235, 10, 25);
Rectangle hallwallRect14 = new Rectangle(320, 250, 100, 10);
Rectangle hallwallRect15 = new Rectangle(285, 240, 35, 10);
Rectangle hallwallRect16 = new Rectangle(205, 240, 50, 20);
Rectangle hallwallRect17 = new Rectangle(165, 240, 50, 10);
Rectangle hallwallRect18 = new Rectangle(135, 240, 30, 20);

//Rectangle hallwallRect19 = new Rectangle(135, 240, 30, 20);
//Rectangle hallwallRect20 = new Rectangle(135, 240, 30, 20);
//Rectangle hallwallRect21 = new Rectangle(135, 240, 30, 20);
//Rectangle hallwallRect22 = new Rectangle(135, 240, 30, 20);
//Rectangle hallwallRect23 = new Rectangle(135, 240, 30, 20);
//Rectangle hallwallRect24 = new Rectangle(135, 240, 30, 20);




//Avmarkering för kollision (Vägg, Vardagsrummet)





//Avmarkering för trigger (Förflyttning mellan rum)
Rectangle triggerRect1 = new Rectangle(255, 155, 30, 5);   //Sovrummet -> Hallen
Rectangle triggerRect2 = new Rectangle(255, 240, 30, 5);   //Hallen -> Sovrummet
Rectangle triggerRect3 = new Rectangle(540, 250, 5, 45);   //Hallen -> Förrådet
Rectangle triggerRect4 = new Rectangle(400, 430, 30, 5);   //Förrådet -> Hallen

while (!Raylib.WindowShouldClose())
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        playerRect.y -= 1;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
        playerRect.y += 1;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
        playerRect.x -= 1;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
        playerRect.x += 1;
    }


    if (Raylib.CheckCollisionRecs(triggerRect1, playerRect))
    {
        playerRect.x = 255;
        playerRect.y = 250;
    }

    if (Raylib.CheckCollisionRecs(triggerRect2, playerRect))
    {
        playerRect.x = 255;
        playerRect.y = 120;
    }


    if (Raylib.CheckCollisionRecs(triggerRect3, playerRect))
    {
        playerRect.x = 395;
        playerRect.y = 450;
    }

    if (Raylib.CheckCollisionRecs(triggerRect4, playerRect))
    {
        playerRect.x = 505;
        playerRect.y = 260;
    }


    Raylib.BeginDrawing();


    Raylib.ClearBackground(Color.BLUE);



    //Bakgrund Hus
    Raylib.DrawTexture(houseImage, 0, 0, Color.WHITE);

    //Spelare
    Raylib.DrawRectangleRec(playerRect, Color.BLANK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);


    //Kollision Sovrumsväggar
    Raylib.DrawRectangleRec(bedwallRect1, Color.LIME);
    Raylib.DrawRectangleRec(bedwallRect2, Color.LIME);
    Raylib.DrawRectangleRec(bedwallRect3, Color.LIME);
    Raylib.DrawRectangleRec(bedwallRect4, Color.LIME);
    Raylib.DrawRectangleRec(bedwallRect5, Color.LIME);
    Raylib.DrawRectangleRec(bedwallRect6, Color.LIME);
    Raylib.DrawRectangleRec(bedwallRect7, Color.LIME);

    //Kollision Hallväggar
    Raylib.DrawRectangleRec(hallwallRect1, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect2, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect3, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect4, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect5, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect6, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect7, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect8, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect9, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect10, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect11, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect12, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect13, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect14, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect15, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect16, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect17, Color.LIME);
    Raylib.DrawRectangleRec(hallwallRect18, Color.LIME);

    //Raylib.DrawRectangleRec(hallwallRect19, Color.LIME);
    //Raylib.DrawRectangleRec(hallwallRect20, Color.LIME);
    //Raylib.DrawRectangleRec(hallwallRect21, Color.LIME);
    //Raylib.DrawRectangleRec(hallwallRect22, Color.LIME);
    //Raylib.DrawRectangleRec(hallwallRect23, Color.LIME);
    //Raylib.DrawRectangleRec(hallwallRect24, Color.LIME);

    //Kollision Dörr (Sovrummet -> Hallen)
    Raylib.DrawRectangleRec(triggerRect1, Color.BLUE);

    //Kollision Dörr (Hallen -> Sovrummet)
    Raylib.DrawRectangleRec(triggerRect2, Color.BLUE);

    //Kollision Dörr (Hallen -> Vardagsrummet)
    Raylib.DrawRectangleRec(triggerRect3, Color.BLUE);

    //Kollision Dörr (Vardagsrummet -> Hallen)
    Raylib.DrawRectangleRec(triggerRect4, Color.BLUE);


    Raylib.EndDrawing();
}