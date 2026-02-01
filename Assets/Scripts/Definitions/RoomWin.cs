using UnityEngine;

public class RoomWin : MonoBehaviour {
    [SerializeField] private UIManager uiManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            uiManager.ShowWinPanel();
        }
    }
}
