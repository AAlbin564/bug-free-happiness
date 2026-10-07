using System.Numerics;
using Raylib_cs;

namespace WizardsWithSpells.Entities;


public class Player
{
    // struct used to store the two x and y values
    public Vector2 Pos {get;set;}
    //current speed of player
    float Speed {get;set;} = 200;
    public Vector2 Size {get;set;} = new Vector2(100,200);


    

    public Player(Vector2 startPos)
    {
        this.Pos = startPos;
    }

    public void Draw()
    {
    Vector2 topLeft = Pos - Size / 2;
    Raylib.DrawRectangleV(topLeft, Size, Color.Blue);
    }

    // public so they can be called from the game loop
    public void Move(float frTime, Vector2 direction)
    {
        this.Pos += direction*Speed*frTime;
    }

}