using UnityEngine;

public class PlayerManager : MonoBehaviour {
    #region Config & Ref

    [Header("Systems")]
    public MoveSystem Move { get; private set; }
    public InputHandler Input { get; private set; }
    public DamageSystem Damage { get; private set; }
    public InteractionSystem Interaction { get; private set; }
    public AnimationSystem Anim { get; private set; }
    private Rigidbody2D _rb;
    [SerializeField] private AudioManager audio;

    [Header("Move Config")]
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float currentMoveSpeed;

    [Header("Health Config")]
    [SerializeField] private float baseHealth;
    [SerializeField] private float healAmount;

    [Header("Oxy Config")]
    [SerializeField] private float baseOxy;

    [Header("Status")]
    public bool IsInvincible;
    public Poison CurrentPoison;
    [SerializeField] private bool _hasKey;

    public bool HasKey => _hasKey;

    #endregion

    #region Unity Lifecycles

    private void Awake() {
        currentMoveSpeed = baseMoveSpeed;
        Input = GetComponent<InputHandler>();
        Anim = GetComponent<AnimationSystem>();
        Interaction = GetComponentInChildren<InteractionSystem>();
        Move = new MoveSystem(GetComponent<Rigidbody2D>(), baseMoveSpeed);
        Damage = new DamageSystem();
        Damage.Init(baseHealth, healAmount, baseOxy);
        Debug.Log("[PlayerManager] Player Initialized");
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (_rb.linearVelocityX < 0) {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (_rb.linearVelocityX > 0) {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }

        if (Input.SwitchMask != 0) {
            SwitchMask(Input.SwitchMask);
            Input.ResetSwitchMask();
        }

        if (Input.Interact) {
            bool success = Interaction.TryInteract();
            if (success) {
                audio.PlayAudioClip(audio.FixClip);
            }
            Input.ResetInteract();
        }

        if (Input.Heal && !Anim.IsHealing && Damage.Health.AidSprayLeft > 0) {
            Move.Stop();
            Damage.Health.Heal();
            Anim.PlayHeal();
            audio.PlayAudioClip(audio.HealClip);
            Input.ResetHeal();
        }

        Anim.UpdateMovement(Input.MoveInput);
    }

    private void FixedUpdate() {
        if (CurrentPoison != null && !IsInvincible) {
            Damage.ApplyDamage(CurrentPoison);
        }

        if (!Anim.IsHealing) {
            Move.Move(Input.MoveInput);
        }
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
