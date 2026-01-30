using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {
    public Vector2 MoveInput { get; private set; }

    public void OnMove(InputAction.CallbackContext context) {
        MoveInput = context.ReadValue<Vector2>();
    }
}
