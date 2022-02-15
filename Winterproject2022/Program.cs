using System;
using System.Numerics;
using Raylib_cs;



//Spelfönster
Raylib.InitWindow(800, 600, "Winter project: Raylib");
Raylib.SetTargetFPS(60);

//Nyckels Startposition
Texture2D keyImage = Raylib.LoadTexture("TopdownKey.png");
Rectangle keyRect = new Rectangle(260, 505, keyImage.width, keyImage.height);

//Spelarens Startposition
Texture2D playerImage = Raylib.LoadTexture("TopDownPlayer.png");
Rectangle playerRect = new Rectangle(220, 90, playerImage.width, playerImage.height);

//Zombiens Startposition
Texture2D zombieImage = Raylib.LoadTexture("TopDownZombie.png");

Rectangle zombieRect = new Rectangle(450, 260, zombieImage.width, zombieImage.height);
Rectangle zombieRect2 = new Rectangle(150, 310, zombieImage.width, zombieImage.height);
Rectangle zombieRect3 = new Rectangle(400, 540, zombieImage.width, zombieImage.height);
Rectangle zombieRect4 = new Rectangle(540, 110, zombieImage.width, zombieImage.height);


//Skapas efter nyckeln har plockats upp
Rectangle zombieRect5 = new Rectangle(0, 0, zombieImage.width, zombieImage.height);
Rectangle zombieRect6 = new Rectangle(0, 0, zombieImage.width, zombieImage.height);



//Bakgrundens Texturer
Texture2D houseImage = Raylib.LoadTexture("TopDownHouse.png");
Texture2D outsideImage = Raylib.LoadTexture("TopDownOut.png");


//-------------------------------------------------------------

//Avmarkering för kollision (Vägg, Sovrummet)
Rectangle bedwallRect1 = new Rectangle(180, 70, 10, 60);
Rectangle bedwallRect2 = new Rectangle(190, 70, 140, 10);
Rectangle bedwallRect3 = new Rectangle(330, 70, 10, 60);
Rectangle bedwallRect4 = new Rectangle(190, 130, 60, 10);
Rectangle bedwallRect5 = new Rectangle(295, 130, 35, 10);
Rectangle bedwallRect6 = new Rectangle(240, 130, 10, 30);
Rectangle bedwallRect7 = new Rectangle(295, 130, 10, 30);

//Avmarkering för kollision (Vägg, Hallen)
Rectangle hallwallRect1 = new Rectangle(85, 345, 435, 10);
Rectangle hallwallRect2 = new Rectangle(520, 185, 45, 10);
Rectangle hallwallRect3 = new Rectangle(565, 145, 10, 50);
Rectangle hallwallRect4 = new Rectangle(520, 185, 10, 65);
Rectangle hallwallRect5 = new Rectangle(520, 295, 10, 60);
Rectangle hallwallRect6 = new Rectangle(525, 240, 20, 10);
Rectangle hallwallRect7 = new Rectangle(525, 295, 20, 10);
Rectangle hallwallRect8 = new Rectangle(560, 145, 135, 10);
Rectangle hallwallRect9 = new Rectangle(695, 70, 10, 75);
Rectangle hallwallRect10 = new Rectangle(445, 70, 250, 10);
Rectangle hallwallRect11 = new Rectangle(440, 70, 10, 175);
Rectangle hallwallRect12 = new Rectangle(425, 235, 20, 10);
Rectangle hallwallRect13 = new Rectangle(410, 235, 10, 25);
Rectangle hallwallRect14 = new Rectangle(320, 250, 100, 10);
Rectangle hallwallRect15 = new Rectangle(295, 240, 35, 10);
Rectangle hallwallRect16 = new Rectangle(220, 240, 25, 20);
Rectangle hallwallRect17 = new Rectangle(220, 240, 20, 15);
Rectangle hallwallRect18 = new Rectangle(165, 240, 50, 10);
Rectangle hallwallRect19 = new Rectangle(135, 240, 30, 20);
Rectangle hallwallRect20 = new Rectangle(75, 250, 80, 20);
Rectangle hallwallRect21 = new Rectangle(70, 250, 10, 100);

//Avmarkering för kollision (Stolar, Hallen)
Rectangle chairRect1 = new Rectangle(580, 120, 10, 25);
Rectangle chairRect2 = new Rectangle(640, 120, 10, 25);
Rectangle chairRect3 = new Rectangle(560, 145, 15, 40);

//Avmarkering för kollision (Vägg, Vardagsrummet)
Rectangle mainwallRect1 = new Rectangle(435, 430, 10, 50);
Rectangle mainwallRect2 = new Rectangle(385, 430, 10, 50);
Rectangle mainwallRect3 = new Rectangle(350, 470, 40, 10);
Rectangle mainwallRect4 = new Rectangle(315, 450, 30, 10);
Rectangle mainwallRect5 = new Rectangle(350, 450, 10, 20);
Rectangle mainwallRect6 = new Rectangle(300, 450, 10, 30);
Rectangle mainwallRect7 = new Rectangle(255, 470, 50, 10);
Rectangle mainwallRect8 = new Rectangle(240, 470, 10, 80);
Rectangle mainwallRect9 = new Rectangle(255, 540, 50, 10);
Rectangle mainwallRect10 = new Rectangle(295, 540, 10, 40);
Rectangle mainwallRect11 = new Rectangle(305, 570, 15, 20);
Rectangle mainwallRect12 = new Rectangle(330, 590, 130, 10);
Rectangle mainwallRect13 = new Rectangle(440, 470, 30, 10);
Rectangle mainwallRect14 = new Rectangle(470, 470, 10, 120);

//Avmarkering för trigger (Förflyttning mellan rum)
Rectangle triggerRect1 = new Rectangle(255, 155, 30, 5);   //Sovrummet -> Hallen
Rectangle triggerRect2 = new Rectangle(255, 240, 30, 5);   //Hallen -> Sovrummet
Rectangle triggerRect3 = new Rectangle(540, 250, 5, 45);   //Hallen -> Vardagsrummet
Rectangle triggerRect4 = new Rectangle(400, 430, 30, 5);   //Vardagsrummet -> Hallen

//Avmarkering för trigger (Slut-dörren)
Rectangle finishRect1 = new Rectangle(80, 270, 5, 75);




//Variabel för startnivå
string level = "start";

//Variabel för nyckel

int key = 0;
bool keyTaken = false;

//Funktion för återställning av spelarens rörelse
bool undoX = false;
bool undoY = false;

Vector2 movement = new Vector2();



float playerSpeed = 1.2f;


while (!Raylib.WindowShouldClose())
{

    undoX = false;
    undoY = false;


    if (level == "start")
    {
        //Variabler för rörelse (Spelare)
        movement = ReadMovement(playerSpeed);

        playerRect.x += movement.X;
        playerRect.y += movement.Y;
    }

    //Ångrar spelarens rörelse, vilket agerar som en "vägg" (Sovrummet)
    if (Raylib.CheckCollisionRecs(playerRect, bedwallRect1)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, bedwallRect2)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, bedwallRect3)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, bedwallRect4)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, bedwallRect5)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, bedwallRect6)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, bedwallRect7)) undoX = true;


    //Ångrar spelarens rörelse, vilket agerar som en "vägg" (Hallen)
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect1)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect2)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect3)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect4)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect5)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect6)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect7)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect8)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect9)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect10)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect11)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect12)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect13)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect14)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect15)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect16)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect17)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect18)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect19)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect20)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, hallwallRect21)) undoX = true;

    //Ångrar spelarens rörelse, vilket agerar som en "vägg" (Vardagsrummet)
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect1)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect2)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect3)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect4)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect5)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect6)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect7)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect8)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect9)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect10)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect11)) undoX = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect12)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect13)) undoY = true;
    if (Raylib.CheckCollisionRecs(playerRect, mainwallRect14)) undoX = true;

    //Ångrar spelarens rörelse, vilket agerar som en "vägg" (Stolar)
    if (Raylib.CheckCollisionRecs(playerRect, chairRect1))
    {
        undoY = true;
        undoX = true;
    }
    if (Raylib.CheckCollisionRecs(playerRect, chairRect2))
    {
        undoY = true;
        undoX = true;
    }
    if (Raylib.CheckCollisionRecs(playerRect, chairRect3))
    {
        undoY = true;
        undoX = true;
    }


    if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
    {
        undoX = true;
    }
    if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
    {
        undoY = true;
    }

    if (undoX == true) playerRect.x -= movement.X;
    if (undoY == true) playerRect.y -= movement.Y;

    //Variabel för att vinna spelet.
    if (level == "start")
    {
        if (Raylib.CheckCollisionRecs(playerRect, finishRect1) && key > 0)
        {
            level = "end";
        }
    }

    //Variabler för förflyttning (Dörr).
    if (level == "start")
    {

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

        //Variabel för aktivering av slut-dörren
        if (Raylib.CheckCollisionRecs(playerRect, keyRect) && keyTaken == false)
        {
            key++;
            keyTaken = true;
        }
    }
    Raylib.BeginDrawing();

    //Bakgrund Hus
    if (level == "start")
    {
        Raylib.DrawTexture(houseImage, 0, 0, Color.WHITE);
    }

    if (level == "start" && level != "end") Raylib.ClearBackground(Color.BLUE);  //Grundbakgrund
    if (key == 1) Raylib.DrawRectangleRec(finishRect1, Color.BLANK);   //Kollision Slut-dörr

    //Spelare
    Raylib.DrawRectangleRec(playerRect, Color.BLANK);
    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

    //Zombie
    Raylib.DrawRectangleRec(zombieRect, Color.BLANK);
    Raylib.DrawTexture(zombieImage, (int)zombieRect.x, (int)zombieRect.y, Color.WHITE);

    Raylib.DrawRectangleRec(zombieRect2, Color.BLANK);
    Raylib.DrawTexture(zombieImage, (int)zombieRect2.x, (int)zombieRect2.y, Color.WHITE);

    Raylib.DrawRectangleRec(zombieRect3, Color.BLANK);
    Raylib.DrawTexture(zombieImage, (int)zombieRect3.x, (int)zombieRect3.y, Color.WHITE);

    Raylib.DrawRectangleRec(zombieRect4, Color.BLANK);
    Raylib.DrawTexture(zombieImage, (int)zombieRect4.x, (int)zombieRect4.y, Color.WHITE);


    //Variabel för att skapa nyckeln
    if (keyTaken == false)
    {
        //Nyckel
        Raylib.DrawRectangleRec(keyRect, Color.BLANK);
        Raylib.DrawTexture(keyImage, (int)keyRect.x, (int)keyRect.y, Color.WHITE);
    }


    //Kollision Sovrumsväggar
    Raylib.DrawRectangleRec(bedwallRect1, Color.BLANK);
    Raylib.DrawRectangleRec(bedwallRect2, Color.BLANK);
    Raylib.DrawRectangleRec(bedwallRect3, Color.BLANK);
    Raylib.DrawRectangleRec(bedwallRect4, Color.BLANK);
    Raylib.DrawRectangleRec(bedwallRect5, Color.BLANK);
    Raylib.DrawRectangleRec(bedwallRect6, Color.BLANK);
    Raylib.DrawRectangleRec(bedwallRect7, Color.BLANK);

    //Kollision Hallväggar
    Raylib.DrawRectangleRec(hallwallRect1, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect2, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect3, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect4, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect5, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect6, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect7, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect8, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect9, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect10, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect11, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect12, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect13, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect14, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect15, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect16, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect17, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect18, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect19, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect20, Color.BLANK);
    Raylib.DrawRectangleRec(hallwallRect21, Color.BLANK);

    //Kollision Stolar
    Raylib.DrawRectangleRec(chairRect1, Color.BLANK);
    Raylib.DrawRectangleRec(chairRect2, Color.BLANK);
    Raylib.DrawRectangleRec(chairRect3, Color.BLANK);

    //Kollision Vardagsrumsväggar
    Raylib.DrawRectangleRec(mainwallRect1, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect2, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect3, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect4, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect5, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect6, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect7, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect8, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect9, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect10, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect11, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect12, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect13, Color.BLANK);
    Raylib.DrawRectangleRec(mainwallRect14, Color.BLANK);

    //Kollision Dörr (Sovrummet -> Hallen)
    Raylib.DrawRectangleRec(triggerRect1, Color.BLANK);
    //Kollision Dörr (Hallen -> Sovrummet)
    Raylib.DrawRectangleRec(triggerRect2, Color.BLANK);
    //Kollision Dörr (Hallen -> Vardagsrummet)
    Raylib.DrawRectangleRec(triggerRect3, Color.BLANK);
    //Kollision Dörr (Vardagsrummet -> Hallen)
    Raylib.DrawRectangleRec(triggerRect4, Color.BLANK);


    //Informationstext
    if (key == 0) Raylib.DrawText("Find The Key!", 520, 550, 35, Color.GOLD);
    else if (key == 1)
    {
        Raylib.DrawText("Get To The Exit!", 520, 550, 35, Color.GOLD);

        //Skapar zombier efter att nyckeln har plockats upp.
        Raylib.DrawRectangleRec(zombieRect5, Color.BLANK);
        Raylib.DrawTexture(zombieImage, (int)zombieRect5.x, (int)zombieRect5.y, Color.WHITE);
        zombieRect5.x = 250;
        zombieRect5.y = 250;

        Raylib.DrawRectangleRec(zombieRect6, Color.BLANK);
        Raylib.DrawTexture(zombieImage, (int)zombieRect6.x, (int)zombieRect6.y, Color.WHITE);
        zombieRect6.x = 330;
        zombieRect6.y = 300;
    }


    //Variabel Zombies (Game Over)
    if (Raylib.CheckCollisionRecs(zombieRect, playerRect))
    {
        zombieRect.x = playerRect.x;
        zombieRect.y = playerRect.y;

        level = "gameover";
    }
    if (Raylib.CheckCollisionRecs(zombieRect2, playerRect))
    {
        zombieRect2.x = playerRect.x;
        zombieRect2.y = playerRect.y;

        level = "gameover";
    }
    if (Raylib.CheckCollisionRecs(zombieRect3, playerRect))
    {
        zombieRect3.x = playerRect.x;
        zombieRect3.y = playerRect.y;

        level = "gameover";
    }
    if (Raylib.CheckCollisionRecs(zombieRect4, playerRect))
    {
        zombieRect4.x = playerRect.x;
        zombieRect4.y = playerRect.y;

        level = "gameover";
    }
    if (Raylib.CheckCollisionRecs(zombieRect5, playerRect))
    {
        zombieRect5.x = playerRect.x;
        zombieRect5.y = playerRect.y;

        level = "gameover";
    }
    if (Raylib.CheckCollisionRecs(zombieRect6, playerRect))
    {
        zombieRect6.x = playerRect.x;
        zombieRect6.y = playerRect.y;

        level = "gameover";
    }



    if (level == "gameover")
    {
        Raylib.DrawRectangle(0, 0, 800, 600, Color.DARKGRAY);

        Raylib.DrawText("You Died!", 140, 260, 110, Color.RED);
    }

    //Bestämmer slutet om du går ut ur huset (Vinner)
    if (level == "end")
    {

        Raylib.ClearBackground(Color.DARKBLUE);

        Raylib.DrawRectangleRec(playerRect, Color.BLANK);
        Raylib.DrawTexture(outsideImage, 0, 0, Color.WHITE);
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        Raylib.DrawText("You Survived!", 20, 330, 110, Color.WHITE);

        playerRect.x = 390;
        playerRect.y = 230;
    }

    Raylib.EndDrawing();
}


//Vektor för spelarens rörelse

static Vector2 ReadMovement(float playerSpeed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -playerSpeed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = playerSpeed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -playerSpeed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = playerSpeed;

    return movement;
}
