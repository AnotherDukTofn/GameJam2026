using UnityEngine;
using UnityEngine.UI;

public class ProgressionBarView : MonoBehaviour {
    [SerializeField] private Image fillImage;
    [SerializeField] private float fillRatio;

    public void ModifyFillAmount(float fillAmount, float baseAmount) {
        CalculateFillRatio(fillAmount, baseAmount);
        fillImage.fillAmount = fillRatio;
    }

    private void CalculateFillRatio(float fillAmount, float baseAmount) {
        fillRatio = fillAmount / baseAmount;
    }
}