using UnityEngine;
public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[TriggerTest] Something entered: " + collision.gameObject.name);
    }
}