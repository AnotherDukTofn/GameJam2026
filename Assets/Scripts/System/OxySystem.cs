using System;
using UnityEngine;

public class OxySystem {
    public float MaxOxy { get; private set; }
    public float CurrentOxy { get; private set; }
    private int _oxyTankLeft;

    public event Action<int> OnTankChange;

    public OxySystem(float maxOxy) {
        MaxOxy = maxOxy;
        CurrentOxy = MaxOxy;
    }

    private void ChangeTank() {
        CurrentOxy = MaxOxy;
        _oxyTankLeft--;
        OnTankChange?.Invoke(_oxyTankLeft);
    }

    public void AddTank() {
        _oxyTankLeft++;  
        OnTankChange?.Invoke(_oxyTankLeft);
    }

    public void ModifyOxy(float amount) {
        CurrentOxy -= amount;
    }

    public bool OutOfOxy() => CurrentOxy <= 0 && _oxyTankLeft <= 0;
}
