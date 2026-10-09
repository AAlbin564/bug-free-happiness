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
        List<Fireball> fireballs = new List<Fireball>();
        List<Fireball> currentlyExplodingFireballs = new List<Fireball>();

        // Game loop: process input, update, render
        while (!Raylib.WindowShouldClose())
        {
            Vector2 movementVector = Vector2.Zero;
            float deltaTime = Raylib.GetFrameTime();

            //process input
             if(Raylib.IsKeyDown(KeyboardKey.W)){
                movementVector += new Vector2(0,-1);
            }
            if(Raylib.IsKeyDown(KeyboardKey.S)){
                movementVector += new Vector2(0,1);
            }
            if(Raylib.IsKeyDown(KeyboardKey.A)){
                movementVector += new Vector2(-1,0);
            }
            if(Raylib.IsKeyDown(KeyboardKey.D)){
                movementVector += new Vector2(1,0);
            }

            if(Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 mousePos = Raylib.GetMousePosition();
                
                Fireball fBall = pWizard.CastFireball(mousePos);
                fireballs.Add(fBall);
            }

            //update
            if(movementVector != Vector2.Zero)
            {
                movementVector = Vector2.Normalize(movementVector);
                pWizard.Move(deltaTime,movementVector);
            }
            foreach (Fireball fBall in fireballs)
            {
                fBall.Update(deltaTime);
                fBall.HandleEdgeCollision(Raylib.GetScreenHeight(), Raylib.GetScreenWidth());
                if(fBall.Exploding)
                {
                    currentlyExplodingFireballs.Add(fBall);
                }
            }
            fireballs.RemoveAll(fb => fb.Exploding);   

            //render
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            pWizard.Draw();
            foreach (Fireball fBall in fireballs)
            {
                fBall.Draw();
            }  
            Raylib.DrawText($"Hello, world! {fireballs.Count} {currentlyExplodingFireballs.Count}", 12, 12, 20, Color.Black);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}