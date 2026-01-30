using UnityEngine;

public class MoveController : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    public void Move(Vector2 moveInput) {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }
}
