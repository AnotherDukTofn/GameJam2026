using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [Header("Oxy UI")]
    [SerializeField] private ProgressionBarView oxyBar;
    [SerializeField] private CountView oxyTank;
    
    [Header("Health UI")]
    [SerializeField] private ProgressionBarView healthBar;
    
    [Header("References")]
    [SerializeField] private PlayerManager pm;
    
    private OxySystem playerOxy;
    private HealthSystem playerHealth;

    #region Unity Lifecycles 

    private void Awake() {
        playerOxy = pm.Damage.Oxy;
        playerHealth = pm.Damage.Health;
    }

    private void OnEnable() {
        pm.Damage.Oxy.OnTankChange += ModifyTankCount;
        pm.Damage.Health.OnHealthChange += ModifyHealthBar;
    }

    private void Start() {
        // Khởi tạo giá trị ban đầu cho UI
        Debug.Log($"[UIManager] Start - CurrentHealth: {playerHealth.CurrentHealth}, MaxHealth: {playerHealth.MaxHealth}");
        ModifyHealthBar(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }

    private void OnDisable() {
        pm.Damage.Oxy.OnTankChange -= ModifyTankCount;
        pm.Damage.Health.OnHealthChange -= ModifyHealthBar;
    }

    private void Update() {
        oxyBar.ModifyFillAmount(playerOxy.CurrentOxy, playerOxy.MaxOxy);
    }

    #endregion

    #region ModifyUI 

    private void ModifyTankCount(int value) {
        oxyTank.SetText(value.ToString());
    }

    private void ModifyHealthBar(float currentHealth, float maxHealth) {
        healthBar.ModifyFillAmount(currentHealth, maxHealth);
    }

    #endregion
}
