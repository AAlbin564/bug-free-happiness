using Raylib_cs;

namespace WizardsWithSpells;

internal static class Program
{
    // Required if you ever deploy with NativeAOT on Windows
    [System.STAThread]
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Wizards with Spells");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}