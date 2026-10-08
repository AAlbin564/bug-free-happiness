using System.Numerics;
using Raylib_cs;
using WizardsWithSpells.Entities;

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

    public Fireball castFireball( Vector2 mousePos)
    {

        Vector2 Edge = FindEdge(castingDirection);

    }
    public Vector2 FindEdge(Vector2 castingDirection)
    {
        float halfWidth = Size.X / 2;
        float halfHeight = Size.Y / 2;

    
        float distToSide = halfWidth / MathF.Abs(direction.X);
        float distToTopBottom = halfHeight / MathF.Abs(direction.Y);

        
        float distance = MathF.Min(distToSide, distToTopBottom);

        return Pos + direction * distance;
    }

}