using UnityEngine;

public class OneSideDoor : MonoBehaviour, IInteractable {
    [SerializeField] private BoxCollider2D doorCollider;

    [SerializeField] private Sprite visual;
    [SerializeField] private AudioManager audio;
    [SerializeField] private float openDir;

    private void Awake() {
        doorCollider = GetComponent<BoxCollider2D>();
        doorCollider.enabled = true;
        GetComponent<SpriteRenderer>().sprite = visual;
    }

    public bool Interact(PlayerManager pm) {
        if ((pm.transform.position.x - transform.position.x) * openDir < 0) {
            return false;
        }
        
        doorCollider.enabled = false;
        return true;
    }
}
