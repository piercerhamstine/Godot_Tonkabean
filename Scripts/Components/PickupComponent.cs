using Godot;
using System;

public partial class PickupComponent : Area2D
{
    [Signal]
    public delegate void OnPickupEventHandler();
    
    private void OnBodyEntered(Node2D area){
        if(area is CharacterController player){
            EmitSignal(SignalName.OnPickup);
            GD.Print(player.Name);
        }
    }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Connect("body_entered", new Callable(this, nameof(OnBodyEntered)));
	}
}
