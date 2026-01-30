using System;
using UnityEngine;

public class HealthSystem {
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    private float _healAmount;

    public event Action<float, float> OnHealthChange;

    public HealthSystem(float maxHealth, float healAmount) {
        MaxHealth = maxHealth;
        _healAmount = healAmount;
        CurrentHealth = MaxHealth;
    }

    public void Hurt(float amount) {
        float oldHealth = CurrentHealth;
        CurrentHealth -= amount;
        if (CurrentHealth < 0) CurrentHealth = 0;
        if (CurrentHealth != oldHealth) {
            OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
            Debug.Log("[HealthSystem] Current Health: " + CurrentHealth);
        }
    }
    public void Heal() {
        float oldHealth = CurrentHealth;
        CurrentHealth += _healAmount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        if (CurrentHealth != oldHealth) { 
            OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
            Debug.Log("[HealthSystem] Current Health: " + CurrentHealth);
        }
    }

    public bool isDead() => CurrentHealth <= 0;
}