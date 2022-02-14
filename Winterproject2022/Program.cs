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
Rectangle hallwallRect1 = new Rectangle(100, 250, 50, 10);


//Avmarkering för trigger (Förflyttning mellan rum)
Rectangle triggerRect1 = new Rectangle(255, 155, 30, 5);   //Sovrummet -> Hallen


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

    Raylib.DrawRectangleRec(triggerRect1, Color.BLUE);


    Raylib.EndDrawing();
}