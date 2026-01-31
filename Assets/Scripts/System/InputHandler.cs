using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour {
    public Vector2 MoveInput { get; private set; }
    public int SwitchMask { get; private set; }
    public bool Interact { get; private set; }
    public bool Heal { get; private set; }

    public event Action OnPausePressed;
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

    public void OnPause(InputAction.CallbackContext context) {
        if (context.performed) OnPausePressed?.Invoke();
    }

    public void ResetSwitchMask() {
        SwitchMask = 0;
    }

    public void OnInteract(InputAction.CallbackContext context) {
        if (context.performed) {
            Interact = true;
            Debug.Log("[InputHandler] Interact pressed");
        }
    }

    public void ResetInteract() {
        Interact = false;
    }

    public void OnHeal(InputAction.CallbackContext context) {
        if (context.performed) {
            Heal = true;
            Debug.Log("[InputHandler] Heal pressed");
        }
    }

    public void ResetHeal() {
        Heal = false;
    }
}
