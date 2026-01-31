using System;
using UnityEngine;

public class MaskSystem  {
    private Mask currentMask;
    [SerializeField] private string currentMaskName;
    private Mask green, yellow, purple;

    public event Action<string> OnMaskBroken;
    public event Action<int> OnMaskChange;

    public void Init() {
        green = new GreenMask();
        yellow = new YellowMask();
        purple = new PurpleMask();
        SetMask(0);
    }

    private Mask FindByID(int id) {
        if (id == 0) return green;
        else if (id == 1) return yellow;
        else return purple;
    }

    public void SetMask(int id) {
        switch (id) {
            case 0: 
            currentMask = green;
            break;
            case 1: 
            currentMask = yellow;
            break;
            case 2: 
            currentMask = purple;
            break;
        }

        OnMaskChange?.Invoke(id);
        Debug.Log("[MaskSystem] Current Mask: " + currentMask.GetType().Name);
    }

    public void RepairMask() {
        Debug.Log("[MaskSystem] Before Repair - Green: " + green.CurrentDurability + ", Yellow: " + yellow.CurrentDurability + ", Purple: " + purple.CurrentDurability);
        green.Repair();
        yellow.Repair();
        purple.Repair();
        Debug.Log("[MaskSystem] After Repair - Green: " + green.CurrentDurability + ", Yellow: " + yellow.CurrentDurability + ", Purple: " + purple.CurrentDurability);
    }

    public bool MaskBlocked(Poison poison) {
        return CurrentMaskUsable() && ValidID(poison);
    }

    public float GetCurrentMaskOxyCost() {
        return currentMask != null ? currentMask.OxyCost : 0f;
    }

    private bool CurrentMaskUsable() => currentMask.CurrentDurability > 0;

    private bool ValidID(Poison poison) => currentMask.PoisonID == poison.ID;
}