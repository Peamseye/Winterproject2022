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
Rectangle zombieRect = new Rectangle(400, 450, zombieImage.width, zombieImage.height);

//Bakgrundens Texturer
Texture2D houseImage = Raylib.LoadTexture("TopDownHouse.png");
Texture2D outsideImage = Raylib.LoadTexture("TopDownOut.png");


//-------------------------------------------------------------

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
Rectangle hallwallRect19 = new Rectangle(75, 250, 70, 20);
Rectangle hallwallRect20 = new Rectangle(75, 250, 10, 100);

//Avmarkering för kollision (Stolar, Hallen)
Rectangle chairRect1 = new Rectangle(575, 120, 25, 25);
Rectangle chairRect2 = new Rectangle(630, 120, 25, 25);
Rectangle chairRect3 = new Rectangle(545, 145, 15, 40);

//Avmarkering för kollision (Vägg, Vardagsrummet)
Rectangle mainwallRect1 = new Rectangle(430, 430, 10, 50);
Rectangle mainwallRect2 = new Rectangle(390, 430, 10, 50);
Rectangle mainwallRect3 = new Rectangle(345, 470, 45, 10);
Rectangle mainwallRect4 = new Rectangle(315, 450, 30, 10);
Rectangle mainwallRect5 = new Rectangle(345, 450, 10, 20);
Rectangle mainwallRect6 = new Rectangle(305, 450, 10, 30);
Rectangle mainwallRect7 = new Rectangle(255, 470, 50, 10);
Rectangle mainwallRect8 = new Rectangle(245, 470, 10, 80);
Rectangle mainwallRect9 = new Rectangle(255, 540, 50, 10);
Rectangle mainwallRect10 = new Rectangle(305, 540, 10, 40);
Rectangle mainwallRect11 = new Rectangle(315, 570, 15, 20);
Rectangle mainwallRect12 = new Rectangle(330, 580, 130, 10);
Rectangle mainwallRect13 = new Rectangle(430, 470, 30, 10);
Rectangle mainwallRect14 = new Rectangle(460, 470, 10, 120);

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

    if (level == "start")
    {

        //Variabler för rörelse (Spelare)
        movement = ReadMovement(playerSpeed);

        playerRect.x += movement.X;
        playerRect.y += movement.Y;
    }

    if (level == "start")
    {
        if (Raylib.CheckCollisionRecs(playerRect, finishRect1))
        {
            level = "end";
        }
    }


    //Variabler för förflyttning (Dörr).
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


    if (undoX == true) playerRect.x -= movement.X;
    if (undoY == true) playerRect.y -= movement.Y;


    Raylib.BeginDrawing();

    if (level == "start" && level != "end")
    {

        Raylib.ClearBackground(Color.BLUE);


        if (key == 1)
    {
      //Kollision Slut-dörr 
      Raylib.DrawRectangleRec(finishRect1, Color.RED);
    }



        //Bakgrund Hus
        Raylib.DrawTexture(houseImage, 0, 0, Color.WHITE);

        //Spelare
        Raylib.DrawRectangleRec(playerRect, Color.BLANK);
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        //Zombie
        Raylib.DrawRectangleRec(zombieRect, Color.BLANK);
        Raylib.DrawTexture(zombieImage, (int)zombieRect.x, (int)zombieRect.y, Color.WHITE);


            //Variabel för att skapa nyckeln
            if (keyTaken == false)
    {
        //Nyckel
        Raylib.DrawRectangleRec(keyRect, Color.BLANK);
        Raylib.DrawTexture(keyImage, (int)keyRect.x, (int)keyRect.y, Color.WHITE);
    }


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
        Raylib.DrawRectangleRec(hallwallRect19, Color.LIME);
        Raylib.DrawRectangleRec(hallwallRect20, Color.LIME);


        //Kollision Stolar
        Raylib.DrawRectangleRec(chairRect1, Color.GOLD);
        Raylib.DrawRectangleRec(chairRect2, Color.GOLD);
        Raylib.DrawRectangleRec(chairRect3, Color.GOLD);


        //Kollision Vardagsrumsväggar
        Raylib.DrawRectangleRec(mainwallRect1, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect2, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect3, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect4, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect5, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect6, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect7, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect8, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect9, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect10, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect11, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect12, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect13, Color.LIME);
        Raylib.DrawRectangleRec(mainwallRect14, Color.LIME);

        //Kollision Dörr (Sovrummet -> Hallen)
        Raylib.DrawRectangleRec(triggerRect1, Color.BLUE);

        //Kollision Dörr (Hallen -> Sovrummet)
        Raylib.DrawRectangleRec(triggerRect2, Color.BLUE);

        //Kollision Dörr (Hallen -> Vardagsrummet)
        Raylib.DrawRectangleRec(triggerRect3, Color.BLUE);

        //Kollision Dörr (Vardagsrummet -> Hallen)
        Raylib.DrawRectangleRec(triggerRect4, Color.BLUE);



        //Informationstext
        Raylib.DrawText("Find The Key And Escape!", 520, 550, 20, Color.GOLD);


        //Variabel Zombie (Game Over)
        if (Raylib.CheckCollisionRecs(zombieRect, playerRect))
        {
            zombieRect.x = playerRect.x;
            zombieRect.y = playerRect.y;
            Raylib.DrawRectangle(0, 0, 800, 600, Color.DARKGRAY);

            Raylib.DrawText("You Died!", 140, 260, 110, Color.RED);
        }

    }
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