using System.Collections;
using UnityEngine;

public class AnimationSystem : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private float healDuration = 1f;
    
    private bool _isHealing = false;
    public bool IsHealing => _isHealing;

    private void Awake() {
        if (animator == null) {
            animator = GetComponent<Animator>();
        }
    }

    public void UpdateMovement(Vector2 moveInput) {
        if (animator == null || _isHealing) return;
        
        bool isMoving = moveInput.sqrMagnitude > 0.01f;
        if (isMoving) {
            animator.Play("Run");
        } else {
            animator.Play("Idle");
        }
    }

    public void PlayHeal() {
        if (animator == null || _isHealing) return;
        StartCoroutine(HealCoroutine());
    }

    private IEnumerator HealCoroutine() {
        _isHealing = true;
        animator.Play("Heal");
        Debug.Log("[AnimationSystem] Heal animation started");
        
        yield return new WaitForSeconds(healDuration);
        
        _isHealing = false;
        Debug.Log("[AnimationSystem] Heal animation finished");
    }
}
