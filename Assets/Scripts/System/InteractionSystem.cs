using Unity.VisualScripting;
using UnityEngine;

public class InteractionSystem : MonoBehaviour {
    [SerializeField] private PlayerManager pm;
    private IInteractable _currentInteractable;

    public bool HasInteractable => _currentInteractable != null;

    public void OnTriggerEnter2D(Collider2D collision) {
        IInteractable interact = collision.GetComponent<IInteractable>();
        if (interact != null) {
            _currentInteractable = interact;
            Debug.Log("[InteractionSystem] Interactable found: " + collision.gameObject.name);
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        IInteractable interact = collision.GetComponent<IInteractable>();
        if (interact != null && interact == _currentInteractable) {
            _currentInteractable = null;
            Debug.Log("[InteractionSystem] Interactable left: " + collision.gameObject.name);
        }
    }

    public bool TryInteract() {
        if (_currentInteractable != null) {
            bool success = _currentInteractable.Interact(pm);
            Debug.Log("[InteractionSystem] Interacted! Success: " + success);
            return success;
        }
        return false;
    }
}