using UnityEngine;

public class AidSpray : MonoBehaviour, IInteractable {
    [SerializeField] private int maxAidSpray = 3;

    public bool Interact(PlayerManager pm) {
        bool picked = pm.Damage.Health.TryAddAidSpray(maxAidSpray);
        if (picked) {
            Debug.Log("[AidSpray] Picked up");
            Destroy(gameObject);
        }
        return picked;
    }
}
