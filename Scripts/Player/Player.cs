using Godot;
using System;

public partial class Player : Node
{
    public static Player Instance {get; private set;}

    public override void _Ready()
    {
        Instance = this;
    }

    public PlayerGoldManager goldManager;
    public PlayerWeaponManager weaponManager;
    public PlayerRelicManager relicManager;
}
