using System.Collections;
using UnityEngine;

public class Tunnel : MonoBehaviour {
    [Header("Holes")]
    [SerializeField] private Hole holeA;
    [SerializeField] private Hole holeB;

    [Header("Animation Settings")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float fallDuration;
    [SerializeField] private float travelSpeed;
    [SerializeField] private float riseDuration;

    private bool _isTeleporting = false;

    private void OnEnable() {
        if (holeA != null) holeA.OnPlayerInteract += (t) => StartCoroutine(TeleportSequence(t, holeA, holeB));
        if (holeB != null) holeB.OnPlayerInteract += (t) => StartCoroutine(TeleportSequence(t, holeB, holeA));
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private IEnumerator TeleportSequence(Transform player, Hole from, Hole to) {
        if (_isTeleporting || to == null) yield break;
        _isTeleporting = true;

        PlayerManager pm = player.GetComponent<PlayerManager>();
        pm.IsInvincible = true;

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        Vector3 startPos = player.position;
        Vector3 holePos = from.transform.position;
        Vector3 targetPos = to.transform.position;

        float elapsed = 0f;
        Vector3 jumpPeak = new Vector3(holePos.x, holePos.y + jumpHeight, holePos.z);
        while (elapsed < jumpDuration) {
            elapsed += Time.deltaTime;
            float t = elapsed / jumpDuration;
            player.position = Vector3.Lerp(startPos, jumpPeak, t);
            yield return null;
        }

        elapsed = 0f;
        Vector3 fallPos = holePos;
        while (elapsed < fallDuration) {
            elapsed += Time.deltaTime;
            float t = elapsed / fallDuration;
            player.position = Vector3.Lerp(jumpPeak, fallPos, t);
            yield return null;
        }

        if (sr != null) sr.enabled = false;
        
        float distance = Vector3.Distance(holePos, targetPos);
        float travelDuration = distance / travelSpeed;
        elapsed = 0f;
        while (elapsed < travelDuration) {
            elapsed += Time.deltaTime;
            float t = elapsed / travelDuration;
            player.position = Vector3.Lerp(fallPos, targetPos, t);
            yield return null;
        }

        if (sr != null) sr.enabled = true;
        
        elapsed = 0f;
        Vector3 risePos = new Vector3(targetPos.x, targetPos.y + jumpHeight, targetPos.z);
        while (elapsed < riseDuration) {
            elapsed += Time.deltaTime;
            float t = elapsed / riseDuration;
            player.position = Vector3.Lerp(targetPos, risePos, t);
            yield return null;
        }

        player.position = targetPos;

        _isTeleporting = false;
        pm.IsInvincible = false;
        pm.CurrentPoison = null;
        pm.ResetMoveSpeed();
        Debug.Log("[Tunnel] Teleport sequence complete");
    }
}
