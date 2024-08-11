using Godot;
using System;
using System.Data;

public partial class HurtboxComponent : Area2D
{
    [Export]
    HealthComponent myHealthComponenet;

    [Signal]
    public delegate void HitByProjectileEventHandler();

    public void OnHitByProjectile(Projectile projectile){

        myHealthComponenet.Damage(projectile.Damage);

        GD.Print(myHealthComponenet.CurrentHealth);

        EmitSignal(SignalName.HitByProjectile);
    }

    private void OnAreaEntered(Area2D area){
        if(area is Projectile projectile){
            OnHitByProjectile(projectile);
        }
    }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Connect("area_entered", new Callable(this, nameof(OnAreaEntered)));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
