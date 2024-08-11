using Godot;
using System;

public partial class HurtboxComponent : Area2D
{
    [Export]
    HealthComponent myHealthComponenet;

    [Signal]
    public delegate void HitByProjectile();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
