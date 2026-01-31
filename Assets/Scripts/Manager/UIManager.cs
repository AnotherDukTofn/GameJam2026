using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("Interaction UI")]
    [SerializeField] private GameObject interactPrompt;

    [Header("Pause UI")]
    [SerializeField] private GameObject pausePanel;
    private bool _isPaused = false;

    
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
        pm.Interaction.OnInteractableEnter += ShowInteractPrompt;
        pm.Interaction.OnInteractableExit += HideInteractPrompt;
        pm.Input.OnPausePressed += TogglePause;
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
        pm.Interaction.OnInteractableEnter -= ShowInteractPrompt;
        pm.Interaction.OnInteractableExit -= HideInteractPrompt;
        pm.Input.OnPausePressed -= TogglePause;
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

    private void ShowInteractPrompt() {
        interactPrompt.SetActive(true);
    }

    private void HideInteractPrompt() {
        interactPrompt.SetActive(false);
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void TogglePause() {
        _isPaused = !_isPaused;
        pausePanel.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;
    }

    public void Resume() {
        _isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    #endregion
}
