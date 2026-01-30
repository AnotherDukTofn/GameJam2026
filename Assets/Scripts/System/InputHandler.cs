using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {
    public Vector2 MoveInput { get; private set; }
    public int SwitchMask { get; private set; }
    public void OnMove(InputAction.CallbackContext context) {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnSwitchGreen(InputAction.CallbackContext context) {
        if (context.performed) {
            SwitchMask = 1;
            Debug.Log("[InputHandler] SwitchGreen pressed");
        }
    }

    public void OnSwitchYellow(InputAction.CallbackContext context) {
        if (context.performed) {
            SwitchMask = 2;
            Debug.Log("[InputHandler] SwitchYellow pressed");
        }
    }

    public void OnSwitchPurple(InputAction.CallbackContext context) {
        if (context.performed) {
            SwitchMask = 3;
            Debug.Log("[InputHandler] SwitchPurple pressed");
        }
    }

    public void ResetSwitchMask() {
        SwitchMask = 0;
    }
}
