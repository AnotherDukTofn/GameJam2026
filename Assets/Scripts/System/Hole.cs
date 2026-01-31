using UnityEngine;
using System;

public class Hole : MonoBehaviour, IInteractable {
    public event Action<Transform> OnPlayerInteract;

    public bool Interact(PlayerManager pm) {
        if (pm != null) {
            OnPlayerInteract?.Invoke(pm.transform);
            Debug.Log("[Hole] Player entered hole");
            return true;
        }
        return false;
    }
}