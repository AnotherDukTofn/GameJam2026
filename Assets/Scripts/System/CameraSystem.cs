using Unity.VisualScripting;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    [SerializeField] private Vector2 currentPos;
    [SerializeField] private Vector2 targetPos;
    [SerializeField] private float smoothSpeed;

    private void Awake() {
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        currentPos = transform.position;
    }

    private void Update() {
        if (currentPos != targetPos) {
            MoveCamera();
        }
    }

    public void SetTargetPos(Vector3 target) {
        targetPos = target;
    }

    private void MoveCamera() {
        if (Vector3.SqrMagnitude(currentPos - targetPos) > 0.01f) {
            currentPos = Vector2.Lerp(currentPos, targetPos, Time.deltaTime * smoothSpeed);
        }
        else currentPos = targetPos;

        transform.position = new Vector3(currentPos.x, currentPos.y, transform.position.z);
    }
}