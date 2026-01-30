using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour {
    [Header("Oxy UI")]
    [SerializeField] private ProgressionBarView oxyBar;
    [SerializeField] private CountView oxyTank;
    
    [Header("Health UI")]
    [SerializeField] private ProgressionBarView healthBar;

    [Header("Mask UI")]
    [SerializeField] private MaskView maskView;
    
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
        pm.Damage.Mask.OnMaskChange += ModifyMaskView;
    }

    private void Start() {
        ModifyHealthBar(playerHealth.CurrentHealth, playerHealth.MaxHealth);
        ModifyTankCount(playerOxy.TankLeft);
    }

    private void OnDisable() {
        pm.Damage.Oxy.OnTankChange -= ModifyTankCount;
        pm.Damage.Health.OnHealthChange -= ModifyHealthBar;
        pm.Damage.Mask.OnMaskChange -= ModifyMaskView;
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

    private void ModifyMaskView(int id) {
        maskView.SetMaskView(id);
    }

    #endregion
}
