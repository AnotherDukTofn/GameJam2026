using UnityEngine;

public class MoveSystem {
    private Rigidbody2D _rb;
    private float _moveSpeed;

    public MoveSystem(Rigidbody2D rb, float moveSpeed) {
        _rb = rb;
        _moveSpeed = moveSpeed;
    }

    public void SetMoveSpeed(float value) {
        _moveSpeed = value;
    }

    public void Move(Vector2 moveInput) {
        _rb.linearVelocity = moveInput.normalized * _moveSpeed;
    }
}
