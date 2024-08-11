using Godot;
using System;
using System.Reflection;

public partial class SmoothFollow : Camera2D
{
    [Export] float lerpWeight;
    [Export] Node2D target;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    float maxDistance = 15;
    float currSpeed = 1;
    float speedIncrease = 0.01f;
    public override void _PhysicsProcess(double delta)
    {
        float targetX = Mathf.Lerp(this.GlobalPosition.X, target.GlobalPosition.X, lerpWeight);
        float targetY = Mathf.Lerp(this.GlobalPosition.Y, target.GlobalPosition.Y, lerpWeight);

        GD.Print(target.GlobalPosition.X - this.GlobalPosition.X);
        
        this.GlobalPosition = new Vector2(targetX, -Mathf.Clamp(targetY, 40, 1000));
    }
}
