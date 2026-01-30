using UnityEngine;

public abstract class Mask {
    public float OxyCost { get; private set; }
    public int PoisonID { get; private set; }
    public float BaseDurability { get; private set; }
    public float CurrentDurability { get; private set; }

    public Mask(float cost, int id, float dura) {
        OxyCost = cost;
        PoisonID = id;
        CurrentDurability = dura;
    }

    public void Repair() {
        CurrentDurability = BaseDurability;
    }
}

public class GreenMask : Mask {
    public GreenMask() : base(cost: 2f, id: 0, dura: 100f) { }
}

public class YellowMask : Mask {
    public YellowMask() : base(cost: 2f, id: 1, dura: 100f) { }
}

public class PurpleMask : Mask {
    public PurpleMask() : base(cost: 2f, id: 2, dura: 100f) { }
}