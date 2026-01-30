using System;
using UnityEngine;

public class MaskSystem  {
    private Mask currentMask;
    [SerializeField] private string currentMaskName;
    private Mask green, yellow, purple;

    public event Action<string> OnMaskBroken;

    public void Init() {
        green = new GreenMask();
        yellow = new YellowMask();
        purple = new PurpleMask();
        SetMask(1);
    }

    private Mask FindByID(int id) {
        if (id == 0) return green;
        else if (id == 1) return yellow;
        else return purple;
    }

    public void SetMask(int id) {
        switch (id) {
            case 1: 
            currentMask = green;
            break;
            case 2: 
            currentMask = yellow;
            break;
            case 3: 
            currentMask = purple;
            break;
        }

        Debug.Log("[MaskSystem] Current Mask: " + currentMask.GetType().Name);
    }

    public bool MaskBlocked(Poison poison) {
        return CurrentMaskUsable() && ValidID(poison);
    }

    private bool CurrentMaskUsable() => currentMask.CurrentDurability > 0;

    private bool ValidID(Poison poison) => currentMask.PoisonID == poison.ID;
}