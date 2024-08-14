using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class PlayerWeaponManager : Node
{
    [Signal]
    public delegate void OnWeaponFireEventHandler();
}
