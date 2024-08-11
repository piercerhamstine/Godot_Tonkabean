using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

public partial class Projectile : Area2D, IProjectile
{
    [Export] float damage;
    [Export] float speed;
    public Vector2 direction;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        this.Position += direction * speed;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
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
