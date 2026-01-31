using Unity.VisualScripting;
using UnityEngine;

public class Room : MonoBehaviour {
    [SerializeField] private Camera mainCam;

    private void Awake() {
        mainCam ??= Camera.main;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            CameraSystem cam = mainCam.GetComponent<CameraSystem>();
            cam.SetTargetPos(transform.position);
        }
    }
}
