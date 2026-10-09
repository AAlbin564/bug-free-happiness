using System.Numerics;
using Raylib_cs;
using WizardsWithSpells.Entities;

public class Fireball{

    public Vector2 Pos {get;set;}
    float Speed {get;set;} = 400;
    public float  Radius {get;set;} = 25;

    public Player Owner {get;set;}

    public Vector2 CastingDirection {get;set;}

    public bool Exploding {get;set;} = false;


    public Fireball(Player owner, Vector2 castingDirection, Vector2 origin)
    {
        this.Owner = owner;

        this.CastingDirection = castingDirection;

        this.Pos = origin + CastingDirection*Radius;
    }

    public void Draw()
    {
        Raylib.DrawCircleV(Pos,Radius,Color.Red);
    }
    public void Update(float frTime)
    {
        this.Pos += CastingDirection*Speed*frTime;
    }

    public void HandleEdgeCollision(int screenHeight, int screenWidth)
    {
        if(screenWidth <= this.Pos.X+this.Radius || 0 >= this.Pos.X-this.Radius || screenHeight <= this.Pos.Y+this.Radius || 0 >= this.Pos.Y-this.Radius)
        {
            this.Exploding = true;
        }
        

    }

}