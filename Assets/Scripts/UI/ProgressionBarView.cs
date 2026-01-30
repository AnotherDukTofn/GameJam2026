using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionBarView : MonoBehaviour {
    [SerializeField] private Image fillImage;

    public void ModifyFillAmount(float fillAmount, float baseAmount) {
        float fillRatio = fillAmount/baseAmount;
        fillImage.fillAmount = fillRatio;
    }
}