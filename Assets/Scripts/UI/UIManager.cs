using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    [Header("Oxy UI")]
    [SerializeField] private ProgressionBarView oxyBar;
    [SerializeField] private CountView oxyTank;
    
    [Header("Health UI")]
    [SerializeField] private ProgressionBarView healthBar;
    [SerializeField] private CountView sprayCount;

    [Header("Mask UI")]
    [SerializeField] private MaskIconView maskIconView;

    [Header("Death UI")]
    [SerializeField] private CanvasGroup deathPanel;
    [SerializeField] private float fadeDuration = 2f;

    
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
        playerOxy.OnTankChange += ModifyTankCount;
        playerHealth.OnAidSprayChange += ModifySprayCount;
        playerHealth.OnHealthChange += ModifyHealthBar;
        playerHealth.OnPlayerDie += ShowDeathPanel;
        pm.Damage.Mask.OnMaskChange += ModifyMaskView;
    }

    private void Start() {
        ModifyHealthBar(playerHealth.CurrentHealth, playerHealth.MaxHealth);
        ModifyTankCount(playerOxy.TankLeft);
        ModifySprayCount(playerHealth.AidSprayLeft);
    }

    private void OnDisable() {
        playerOxy.OnTankChange -= ModifyTankCount;
        playerHealth.OnAidSprayChange -= ModifySprayCount;
        playerHealth.OnHealthChange -= ModifyHealthBar;
        playerHealth.OnPlayerDie -= ShowDeathPanel;
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

    private void ModifySprayCount(int value) {
        sprayCount.SetText(value.ToString());
    }

    private void ModifyMaskView(int id) {
        maskIconView.SetMaskView(id);
    }

    private void ShowDeathPanel() {
        StartCoroutine(FadeInDeathPanel());
    }

    private IEnumerator FadeInDeathPanel() {
        deathPanel.gameObject.SetActive(true);
        deathPanel.alpha = 0f;
        
        float elapsed = 0f;
        while (elapsed < fadeDuration) {
            elapsed += Time.deltaTime;
            deathPanel.alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            yield return null;
        }
        deathPanel.alpha = 1f;
    }

    #endregion
}
