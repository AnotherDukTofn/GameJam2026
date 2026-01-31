using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable {
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private Sprite visual;
    [SerializeField] private AudioManager audio;

    private void Awake() {
        doorCollider = GetComponent<BoxCollider2D>();
        doorCollider.enabled = true;
        GetComponent<SpriteRenderer>().sprite = visual;
    }

    public bool Interact(PlayerManager pm) {
        if (pm.HasKey) {
            doorCollider.enabled = false;
            return true;
        }
        return false;
    }
}