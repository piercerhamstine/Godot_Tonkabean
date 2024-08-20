using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class EntityDropComponent : Node2D
{
    private Godot.Collections.Array<PackedScene> droppableItems;

    public Godot.Collections.Array<PackedScene> DroppableItems{
        get{
            return droppableItems;
        }

        set{
            droppableItems = value;
        }
    }

    [Signal]
    public delegate void ItemDropEventHandler();   
	
    public void DropItem(Vector2 spawnPos){
        CallDeferred(nameof(SpawnItems), spawnPos);
    }

    private void SpawnItems(Vector2 spawnPos){
        foreach(var item in droppableItems){
           var entity = EntitySpawner.Instance.SpawnEntity(item) as Node2D;
           entity.GlobalPosition = spawnPos;
           EmitSignal(SignalName.ItemDrop);
        }
    }
}
