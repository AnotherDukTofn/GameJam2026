using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {
    public Vector2 MoveInput { get; private set; }
    public int SwitchMask { get; private set; }
    public void OnMove(InputAction.CallbackContext context) {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnSwitchGreen(InputAction.CallbackContext context) {
        if (context.performed) SwitchMask = 1;
    }

    public void OnSwitchYellow(InputAction.CallbackContext context) {
        if (context.performed) SwitchMask = 2;
    }

    public void OnSwitchPurple(InputAction.CallbackContext context) {
        if (context.performed) SwitchMask = 3;
    }

    public void ResetSwitchMask() {
        SwitchMask = 0;
    }
}
