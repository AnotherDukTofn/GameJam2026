using UnityEngine;

public class Door : MonoBehaviour, IInteractable {
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private AudioManager audio;
    private bool isOpen = false;

    private void Awake() {
        doorCollider = GetComponent<BoxCollider2D>();
        doorCollider.enabled = true;
    }

    public void Interact(PlayerManager pm) {
        if (isOpen) return; 
        
        isOpen = true;
        doorCollider.enabled = false;
        if (audio != null) {
            audio.PlayAudioClip(audio.OpenDoorClip);
        }
        Debug.Log("[Door] Door opened");
    }
}
