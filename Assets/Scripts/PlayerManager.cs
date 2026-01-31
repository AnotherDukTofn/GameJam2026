using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    #region Config & Ref

    [Header("Systems")]
    public MoveSystem Move { get; private set; }
    public InputHandler Input { get; private set; }
    public DamageSystem Damage { get; private set; }
    public InteractionSystem Interaction { get; private set; }

    [Header("Move Config")]
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float currentMoveSpeed;

    [Header("Health Config")]
    [SerializeField] private float baseHealth;
    [SerializeField] private float healAmount;

    [Header("Oxy Config")]
    [SerializeField] private float baseOxy;

    [Header("Status")]
    public Poison CurrentPoison;

    #endregion

    #region Unity Lifecycles

    private void Awake() {
        currentMoveSpeed = baseMoveSpeed;
        Input = GetComponent<InputHandler>();
        Interaction = GetComponentInChildren<InteractionSystem>();
        Move = new MoveSystem(GetComponent<Rigidbody2D>(), baseMoveSpeed);
        Damage = new DamageSystem();
        Damage.Init(baseHealth, healAmount, baseOxy);
        Debug.Log("[PlayerManager] Player Initialized");
    }

    private void Update() {
        if (Input.SwitchMask != 0) {
            SwitchMask(Input.SwitchMask);
            Input.ResetSwitchMask();
        }

        if (Input.Interact) {
            Interaction.TryInteract();
            Input.ResetInteract();
        }
    }

    private void FixedUpdate() {
        if (CurrentPoison != null) {
            Damage.ApplyDamage(CurrentPoison);
        }

        Move.Move(Input.MoveInput);
    }

    #endregion

    #region Modify Config 

    public void ModifyMoveSpeed(float factor) {
        currentMoveSpeed += currentMoveSpeed * factor;
        Move.SetMoveSpeed(currentMoveSpeed);
    }

    public void ResetMoveSpeed() {
        currentMoveSpeed = baseMoveSpeed;
        Move.SetMoveSpeed(currentMoveSpeed);
    }

    #endregion

    #region Logic

    private void SwitchMask(int id) {
        Damage.Mask.SetMask(id - 1);
    }

    public void RepairMask() {
        Damage.Mask.RepairMask();
    }

    #endregion
}
