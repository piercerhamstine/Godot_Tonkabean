using Godot;
using System;

public partial class LootDropComponent : Node2D
{
    [Export]
    Godot.Collections.Array<PackedScene> lootList;

    [Export]
    HealthComponent myHealthComponent;

    [Export]
    EntityDropComponent myEntityDropComponent;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        myEntityDropComponent.DroppableItems = lootList;
        myHealthComponent.Death += DropLoot;
    }

    private void DropLoot(){
        myEntityDropComponent.DropItem(this.GlobalPosition);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
