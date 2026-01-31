using UnityEngine;

public class GasManager : MonoBehaviour {
    [SerializeField] private int poisonID;
    private Poison poison;

    private void Awake() {
        switch (poisonID) {
            case 0:
                poison = new GreenPoison();
                break;
            case 1: 
                poison = new YellowPoison();
                break;
            case 2:
                poison = new PurplePoison();
                break;
            default:
                poison = new GreenPoison();
                Debug.LogWarning("[GasManager] Invalid poisonID, defaulting to Green");
                break;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;
        
        PlayerManager pm = collision.GetComponent<PlayerManager>();
        if (pm == null) return;
        
        Debug.Log("[GasManager] Enter Range: " + collision.gameObject.name);
        pm.CurrentPoison = poison;
        pm.ModifyMoveSpeed(-poison.SlowFactor);
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) return;
        
        PlayerManager pm = collision.GetComponent<PlayerManager>();
        if (pm == null) return;
        
        Debug.Log("[GasManager] Exit Range: " + collision.gameObject.name);
        pm.CurrentPoison = null;
        pm.ResetMoveSpeed();
    }
}