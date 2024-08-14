using Godot;
using System;
using System.Reflection.Metadata.Ecma335;

public partial class EntitySpawner : Node
{
    public static EntitySpawner Instance {get; private set;}

	public override void _Ready()
	{
        Instance = this;
	}

    public Node SpawnEntity(PackedScene scene){
        var newEntity = scene.Instantiate();
        GetTree().CurrentScene.AddChild(newEntity);
        return newEntity;
    }
}
