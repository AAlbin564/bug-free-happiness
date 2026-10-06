using Raylib_cs;
using System.Numerics;

using WizardsWithSpells.Entities;

namespace WizardsWithSpells;

internal static class Program
{
    // Required if you ever deploy with NativeAOT on Windows
    [System.STAThread]
    public static void Main()
    {
        //instatiate the playercharacter and the window
        Raylib.InitWindow(800, 480, "Wizards with Spells");
        Player pWizard = new Player(new Vector2(400,240));

        // Game loop: process input, update, render
        while (!Raylib.WindowShouldClose())
        {
            float deltaTime = Raylib.GetFrameTime();
            //process input
            if(Raylib.IsKeyDown(KeyboardKey.W)){
                pWizard.MoveUp(deltaTime);
            }
            if(Raylib.IsKeyDown(KeyboardKey.S)){
                pWizard.MoveDown(deltaTime);
            }
            if(Raylib.IsKeyDown(KeyboardKey.A)){
                pWizard.MoveLeft(deltaTime);
            }
            if(Raylib.IsKeyDown(KeyboardKey.D)){
                pWizard.MoveRight(deltaTime);
            }

            //update
            

            //render
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            pWizard.Draw();
            Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}