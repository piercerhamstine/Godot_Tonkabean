using Godot;
using System;

public partial class Goblin : CharacterBody2D
{
    [Export]
    HealthComponent myHealthComponent;
    [Export]
    VelocityComponent myVelocityComponent;
    
    private void HandleDeath(){
        GD.Print("Died");
        QueueFree();
    }

    public override void _Ready()
    {
        myHealthComponent.Death += HandleDeath;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Testing purpose only
        var target = GetNodeOrNull("../Player") as Node2D; 
        if(target != null)
            myVelocityComponent.Direction = target.GlobalPosition - this.GlobalPosition;

        myVelocityComponent.Move(this);
    }
}
