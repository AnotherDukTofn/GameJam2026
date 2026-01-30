public abstract class Poison {
    public int ID;
    public float Damage;
    public float Corrosion;
    public float SlowFactor;

    public Poison(int ID, float damage, float corrosion, float slowFactor) {
        this.ID = ID;
        Damage = damage;
        Corrosion = corrosion;
        SlowFactor = slowFactor;
    }
}

public class GreenPoison : Poison {
    public GreenPoison() : base(ID: 0, damage: 0.4f, corrosion: 0.025f, slowFactor: 0.5f) { }
}

public class YellowPoison : Poison {
    public YellowPoison() : base(ID: 1, damage: 0.267f, corrosion: 0.015f, slowFactor: 0.3f) { }
}

public class PurplePoison : Poison {
    public PurplePoison() : base(ID: 2, damage: 0.2f, corrosion: 0.015f, slowFactor: 0.5f) { }
}