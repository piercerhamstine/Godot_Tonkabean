using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class EntityDropComponent : Node2D
{
    [Export]
    Godot.Collections.Array<PackedScene> droppableItems;

    [Signal]
    public delegate void ItemDropEventHandler();   
	
    public void DropItem(){
        foreach(var item in droppableItems){
            EntitySpawner.Instance.SpawnEntity(item);
            EmitSignal(SignalName.ItemDrop);
        }
    }
}
