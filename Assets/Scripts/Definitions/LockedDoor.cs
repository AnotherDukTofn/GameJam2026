using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable {
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private AudioManager audio;
    [SerializeField] private Sprite openSprite;
    
    private SpriteRenderer _sr;

    private void Awake() {
        doorCollider = GetComponent<BoxCollider2D>();
        doorCollider.enabled = true;
        _sr = GetComponent<SpriteRenderer>();
    }

    public bool Interact(PlayerManager pm) {
        if (pm.HasKey) {
            doorCollider.enabled = false;
            if (openSprite != null) _sr.sprite = openSprite;
            return true;
        }
        return false;
    }
}