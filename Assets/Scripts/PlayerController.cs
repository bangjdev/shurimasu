using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    public float MaxHealth {get; set;} = 100f;
    public float CurrentHealth {get; set;}
    // Start is called before the first frame update
    void Start()
    {
        playerInput.ActivateInput();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable() {
        playerInput.onActionTriggered += PlayerActionTriggered;
    }

    void OnDisable() {
        playerInput.onActionTriggered -= PlayerActionTriggered;
    }
    private void PlayerActionTriggered(InputAction.CallbackContext callback)
    {
        switch (callback.action.name) {
            case "Move":
                playerMovement.SetMovementVector(callback.ReadValue<Vector2>());
            break;
            case "Throw":
                StartCoroutine(playerAttack.Throw());
            break;
        }
    }

    public void TakeDamage(float damage) {
        this.CurrentHealth -= damage;
        if (this.CurrentHealth < 0) {
            Destroy(this.gameObject);
        }
    }
}
