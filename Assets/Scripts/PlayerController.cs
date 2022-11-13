using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerInput.ActivateInput();
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
}
