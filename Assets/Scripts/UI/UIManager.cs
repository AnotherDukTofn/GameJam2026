using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField] private ProgressionBarView oxyBar;
    private OxySystem playerOxy;
    [SerializeField] private CountView oxyTank;
    [SerializeField] private PlayerManager pm;

    #region Unity Lifecycles 

    private void Awake() {
        playerOxy = pm.Damage.Oxy;
    }

    private void OnEnable() {
        pm.Damage.Oxy.OnTankChange += ModifyTankCount;
    }

    private void Update() {
        oxyBar.ModifyFillAmount(playerOxy.CurrentOxy, playerOxy.MaxOxy);
    }

    #endregion

    #region ModifyUI 

    private void ModifyTankCount(int value) {
        oxyTank.SetText(value.ToString());
    }

    private void ModifyBarView() {
        
    }

    #endregion
}
