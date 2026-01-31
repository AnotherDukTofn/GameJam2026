using UnityEngine;

public class RepairTable : MonoBehaviour, IInteractable {
    public void Interact(PlayerManager pm) {
        pm.RepairMask();
        Debug.Log("[RepairTable] Repaired");
    }
}