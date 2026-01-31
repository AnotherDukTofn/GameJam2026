using UnityEngine;

public class RepairTable : MonoBehaviour, IInteractable {
    public bool Interact(PlayerManager pm) {
        pm.RepairMask();
        Debug.Log("[RepairTable] Repaired");
        return true;
    }
}