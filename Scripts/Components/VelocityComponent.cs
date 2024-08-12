using Godot;
using System;

public partial class VelocityComponent : Node
{
    private float currentSpeed;
    private float maxSpeed;
    private Vector2 direction;

    public Vector2 Direction{
        get => direction;
        set{
            direction = value.Normalized();
        }
    }

    [Export]
    public float MaxSpeed{
        get => maxSpeed;
        set{
            maxSpeed = value;
        }
    }

    public float CurrentSpeed{
        get => currentSpeed;
        set{
            currentSpeed = value;
            if(currentSpeed > maxSpeed){
                currentSpeed = maxSpeed;
            }
        }
    }

    public void Move(CharacterBody2D controller){
        controller.Velocity = Direction * CurrentSpeed;
        controller.MoveAndSlide();
    }

    private void InitCurrentHealth(){
        CurrentSpeed = MaxSpeed;
    }

    public override void _Ready()
    {
        CallDeferred(nameof(InitCurrentHealth));
    }
}
