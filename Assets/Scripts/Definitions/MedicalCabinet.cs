using UnityEngine;

public class MedicalCabinet : MonoBehaviour, IInteractable {
    [SerializeField] private int maxAidSpray = 3;
    [SerializeField] private int maxOxyTank = 3;

    public bool Interact(PlayerManager pm) {
        pm.Damage.Health.FullHeal();
        pm.Damage.Health.RefillAidSpray(maxAidSpray);
        pm.Damage.Oxy.RefillTank(maxOxyTank);
        Debug.Log("[MedicalCabinet] Player fully restored");
        return true;
    }
}
