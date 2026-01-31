using UnityEngine;

public class Door : MonoBehaviour, IInteractable {
    [SerializeField] private BoxCollider2D collider2D;
    [SerializeField] private bool isOpen;
    [SerializeField] private bool interact;

    private void Awake() {
        collider2D = GetComponent<BoxCollider2D>();
        isOpen = false;
    }

    private void Update() {
        if (interact) {
            isOpen = true;
            Interact();
        }
    }

    public void Interact() {
        if (!isOpen) return;
        else collider2D.enabled = false;
    }
}
