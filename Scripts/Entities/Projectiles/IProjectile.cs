using Godot;
using System;

public partial interface IProjectile
{
    public void OnSpawn();
    public void OnHit();
    public void OnDeath();
}
