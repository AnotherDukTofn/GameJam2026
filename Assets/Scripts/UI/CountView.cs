using UnityEngine;
using TMPro;

public class CountView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI countText;

    public void SetText(string value) {
        countText.text = value;
    }
}