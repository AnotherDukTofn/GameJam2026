using UnityEngine;

public class DamageSystem {
    public MaskSystem Mask { get; private set; }
    public HealthSystem Health { get; private set; }
    public OxySystem Oxy { get; private set; }

    public void Init(float baseHealth, float healAmount, float baseOxy) {
        Health = new HealthSystem(baseHealth, healAmount);
        Oxy = new OxySystem(baseOxy);
        Mask = new MaskSystem();
        Mask.Init();
    }

    public void ApplyDamage(Poison poison) {
        if (!Oxy.OutOfOxy()) {
            Oxy.ModifyOxy(Mask.GetCurrentMaskOxyCost());
        }

        if (!Mask.MaskBlocked(poison) || Oxy.OutOfOxy()) {
            Health.Hurt(poison.Damage);
        }
    }
}