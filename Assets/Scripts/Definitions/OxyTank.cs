using UnityEngine;

public class OxyTank : MonoBehaviour, IInteractable {
    [SerializeField] private int maxOxyTank = 3;

    public bool Interact(PlayerManager pm) {
        bool picked = pm.Damage.Oxy.TryAddTank(maxOxyTank);
        if (picked) {
            Debug.Log("[OxyTank] Picked up");
            Destroy(gameObject);
        }
        return picked;
    }
}
