using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

public partial class Projectile : Area2D, IProjectile
{
    [Export] private float damage;
    [Export] float speed;
    public Vector2 direction;

    public float Damage{
        get => damage;
    }

    public override void _PhysicsProcess(double delta)
    {
        this.Position += direction * speed;
    }

    public void OnSpawn()
    {
        throw new NotImplementedException();
    }

    public void OnHit()
    {
        throw new NotImplementedException();
    }

    public void OnDeath()
    {
        throw new NotImplementedException();
    }
}
