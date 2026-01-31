using UnityEngine;

public class OneSideDoor : MonoBehaviour, IInteractable {
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private AudioManager audio;
    [SerializeField] private float openDir;
    [SerializeField] private Sprite openSprite;
    
    private SpriteRenderer _sr;

    private void Awake() {
        doorCollider = GetComponent<BoxCollider2D>();
        doorCollider.enabled = true;
        _sr = GetComponent<SpriteRenderer>();
    }

    public bool Interact(PlayerManager pm) {
        if ((pm.transform.position.x - transform.position.x) * openDir < 0) {
            return false;
        }
        
        doorCollider.enabled = false;
        if (openSprite != null) _sr.sprite = openSprite;
        return true;
    }
}
