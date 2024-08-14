using Godot;
using System;
using System.Linq.Expressions;

public partial class EnemySpawnManager : Node
{
    [Export]
    PackedScene enemyType;

    // DEBUG, just testing/prototyping.
    // TODO: Make this properly.
    public void SpawnEnemies(){
        var view = GetViewport();
        var rect = view.GetVisibleRect();
        var cam = GetNode<Camera2D>("../Camera2D");
    
        var camPos = cam.GlobalPosition;

        RandomNumberGenerator rng = new RandomNumberGenerator();
        var spawnSide = (rng.RandiRange(0,1) > 0)?1:-1;
        GD.Print(spawnSide);
        var newPos = new Vector2(spawnSide*(camPos.X - ((rect.Size.X/cam.Zoom.X)/2) + 32*spawnSide), camPos.Y);

        var newEnemy = EntitySpawner.Instance.SpawnEntity(enemyType) as CharacterBody2D;
        newEnemy.GlobalPosition = newPos;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if(Input.IsActionJustPressed("ui_accept")){
            SpawnEnemies();
        }
	}
}
