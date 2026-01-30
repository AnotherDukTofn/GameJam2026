using UnityEngine;

public class HealthSystem {
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    private float _healAmount;

    public HealthSystem(float maxHealth, float healAmount) {
        MaxHealth = maxHealth;
        _healAmount = healAmount;
        CurrentHealth = MaxHealth;
    }

    public void Hurt(float amount) {
        CurrentHealth -= amount;
        if (CurrentHealth < 0) CurrentHealth = 0;
        Debug.Log("[HealthSystem] Current Health: " + CurrentHealth);
    }

    public void Heal() {
        CurrentHealth += _healAmount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }

    public bool isDead() => CurrentHealth <= 0;
}