using System.Numerics;
using Raylib_cs;
using WizardsWithSpells.Entities;

public class Fireball{

    public Vector2 Pos {get;set;}
    float Speed {get;set;} = 400;
    public float  Radius {get;set;} = 25;

    public Player Owner {get;set;}

    public Vector2 CastingDirection {get;set;}


    public Fireball(Player owner, Vector2 castingDirection, Vector2 origin)
    {
        if(castingDirection == Vector2.Zero)
        {
            this.CastingDirection = new Vector2(1,0);
        }
        else
        {
            this.CastingDirection = Vector2.Normalize(castingDirection);
        }


        

        this.Owner = owner;

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

}