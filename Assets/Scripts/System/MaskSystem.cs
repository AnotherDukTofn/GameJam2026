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
        currentMask = green;
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
    }

    public bool MaskBlocked(Poison poison) {
        return CurrentMaskUsable() && ValidID(poison);
    }

    private bool CurrentMaskUsable() => currentMask.CurrentDurability > 0;

    private bool ValidID(Poison poison) => currentMask.PoisonID == poison.ID;
}