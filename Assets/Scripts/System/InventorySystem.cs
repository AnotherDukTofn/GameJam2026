using System;
using System.Collections.Generic;

public class InventorySystem {
    private int _oxyTankCount;
    private int _firstAidKitCount;
    private List<int> _masksCount;

    public event Action<int> OnTankChange;
    public event Action<int> OnKitChange;
    public event Action<int, int> OnMaskChange;  

    public void ModifyTank(int amount) {
        _oxyTankCount += amount;
        OnTankChange?.Invoke(_oxyTankCount);
    }

    public void ModifyKit(int amount) {
        _firstAidKitCount += amount;
        OnKitChange?.Invoke(_firstAidKitCount);
    }

    public void ModifyMask(int index, int amount) {
        _masksCount[index] += amount;
        OnMaskChange?.Invoke(index, _masksCount[index]);   
    }
}