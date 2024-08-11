using Godot;
using System;

public partial class WeaponRanged : Node2D, IWeapon
{
    [Export] CharacterBody2D owner;

    [Export] PackedScene projectileType;

    [Export] float projectileCount;

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        Vector2 mousePos = ((Node2D)this.GetParent()).GetLocalMousePosition() - this.Position;
        this.RotationDegrees = Mathf.RadToDeg(mousePos.Normalized().Angle())+90;

        if(Input.IsActionJustPressed("action_fire")){
            for(int i = 0; i < projectileCount; ++i){
                float angle = 0;
                if(projectileCount > 1)
                    angle = ((i / (projectileCount-1)) - 0.5f) * (30*projectileCount);

                SpawnProjectile(angle);
            }
        }
	}

    public void OnFire()
    {
        throw new NotImplementedException();
    }

    private void SpawnProjectile(float rot){
        var _projectile = this.projectileType.Instantiate() as Projectile;
        _projectile.GlobalPosition = ((Node2D)this.GetChild(0)).GlobalPosition;
        _projectile.direction = (((Node2D)this.GetParent()).GetLocalMousePosition() - this.Position).Normalized().Rotated(Mathf.DegToRad(rot));
        GetTree().Root.AddChild(_projectile);
    }
}
