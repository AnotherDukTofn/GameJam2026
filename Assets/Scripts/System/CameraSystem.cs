using Unity.VisualScripting;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    [SerializeField] private Vector3 currentPos;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float smoothSpeed;

    private void Awake() {
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
            currentPos = Vector3.Lerp(currentPos, targetPos, Time.deltaTime * smoothSpeed);
        }
        else currentPos = targetPos;

        transform.position = currentPos; 
    }
}