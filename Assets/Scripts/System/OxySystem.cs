using System;
using UnityEngine;

public class OxySystem {
    public float MaxOxy { get; private set; }
    public float CurrentOxy { get; private set; }
    private int _oxyTankLeft = 0;
    public int TankLeft => _oxyTankLeft;

    public event Action<int> OnTankChange;
    public event Action<float, float> OnOxyChange;
    public event Action<string> OnWarning;

    public OxySystem(float maxOxy) {
        MaxOxy = maxOxy;
        CurrentOxy = MaxOxy;
        Debug.Log("[OxySystem] Oxy System Initialized, Oxy Tank Left: " + _oxyTankLeft);
    }

    private void ChangeTank() {
        CurrentOxy = MaxOxy;
        _oxyTankLeft--;
        OnTankChange?.Invoke(_oxyTankLeft);
        OnOxyChange?.Invoke(CurrentOxy, MaxOxy);
    }

    public void AddTank() {
        _oxyTankLeft++;  
        OnTankChange?.Invoke(_oxyTankLeft);
    }

    public bool TryAddTank(int max) {
        if (_oxyTankLeft >= max) {
            OnWarning?.Invoke("Không thể nhặt thêm bình oxy!");
            Debug.Log("[OxySystem] Cannot pick up - Oxy Tank full: " + _oxyTankLeft + "/" + max);
            return false;
        }
        _oxyTankLeft++;
        OnTankChange?.Invoke(_oxyTankLeft);
        Debug.Log("[OxySystem] Oxy Tank picked up: " + _oxyTankLeft + "/" + max);
        return true;
    }

    public void RefillTank(int max) {
        _oxyTankLeft = max;
        CurrentOxy = MaxOxy;
        OnTankChange?.Invoke(_oxyTankLeft);
        OnOxyChange?.Invoke(CurrentOxy, MaxOxy);
        Debug.Log("[OxySystem] Tank Refilled: " + _oxyTankLeft + ", Oxy: " + CurrentOxy + "/" + MaxOxy);
    }

    public void ModifyOxy(float amount) {
        float oldOxy = CurrentOxy;
        CurrentOxy -= amount;
        Debug.Log("[OxySystem] Current Oxy: " + CurrentOxy + "/" + MaxOxy);
        if (CurrentOxy <= 0) {
            if (_oxyTankLeft > 0) {
                ChangeTank();
            } else {
                CurrentOxy = 0;
                OnWarning?.Invoke("Hết bình oxy!");
            }
        }
        
        if (CurrentOxy != oldOxy) {
            OnOxyChange?.Invoke(CurrentOxy, MaxOxy);
        }
    }

    public bool OutOfOxy() => CurrentOxy <= 0 && _oxyTankLeft <= 0;
}
