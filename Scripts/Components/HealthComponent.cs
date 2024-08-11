using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class HealthComponent : Node
{
    [Signal]
    public delegate void HealthChangedEventHandler();
    [Signal]
    public delegate void DeathEventHandler();

    private float currentHealth;
    private float maxHealth;

    public float CurrentHealth{
        get => currentHealth;
        private set{
            currentHealth = Math.Clamp(value, 0, MaxHealth);

            EmitSignal(SignalName.HealthChanged);

            if(!IsAlive){
                EmitSignal(SignalName.Death);
            }
        }
    }

    [Export]
    public float MaxHealth{
        get => maxHealth;
        private set{
            maxHealth = value;
            if(CurrentHealth > maxHealth){
                CurrentHealth = maxHealth;
            }
        }
    }

    private bool IsAlive{
        get{
            return !Mathf.IsEqualApprox(CurrentHealth, 0f);
        }
    }

    public void Damage(float value){
        CurrentHealth -= value;
    }

    public void Heal(float value){
        Damage(-value);
    }

    private void InitCurrentHealth(){
        CurrentHealth = MaxHealth;
    }

	public override void _Ready()
	{
        CallDeferred(nameof(InitCurrentHealth));
	}
}
