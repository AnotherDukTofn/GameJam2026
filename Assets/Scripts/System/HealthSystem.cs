using System;
using UnityEngine;

public class HealthSystem {
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    public int AidSprayLeft { get; private set; }
    private float _healAmount;

    public event Action<float, float> OnHealthChange;
    public event Action OnInventoryFull;

    public HealthSystem(float maxHealth, float healAmount) {
        MaxHealth = maxHealth;
        _healAmount = healAmount;
        CurrentHealth = MaxHealth;
        AidSprayLeft = 3;
    }

    public void Hurt(float amount) {
        float oldHealth = CurrentHealth;
        CurrentHealth -= amount;
        if (CurrentHealth < 0) CurrentHealth = 0;
        if (CurrentHealth != oldHealth) {
            OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
            Debug.Log("[HealthSystem] Current Health: " + CurrentHealth + "/" + MaxHealth);
        }
    }
    public void Heal() {
        if (AidSprayLeft <= 0) return;
        float oldHealth = CurrentHealth;
        CurrentHealth += _healAmount;
        AidSprayLeft--;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        if (CurrentHealth != oldHealth) { 
            OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
            Debug.Log("[HealthSystem] Current Health: " + CurrentHealth + "/" + MaxHealth);
        }
    }

    public void AddAidSpray() {
        AidSprayLeft++;
    }

    public bool TryAddAidSpray(int max) {
        if (AidSprayLeft >= max) {
            OnInventoryFull?.Invoke();
            Debug.Log("[HealthSystem] Cannot pick up - Aid Spray full: " + AidSprayLeft + "/" + max);
            return false;
        }
        AidSprayLeft++;
        Debug.Log("[HealthSystem] Aid Spray picked up: " + AidSprayLeft + "/" + max);
        return true;
    }

    public void FullHeal() {
        CurrentHealth = MaxHealth;
        OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
        Debug.Log("[HealthSystem] Full Heal - Current Health: " + CurrentHealth + "/" + MaxHealth);
    }

    public void RefillAidSpray(int max) {
        AidSprayLeft = max;
        Debug.Log("[HealthSystem] Aid Spray Refilled: " + AidSprayLeft);
    }

    public bool isDead() => CurrentHealth <= 0;
}