using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput playerInput;
    public new Rigidbody rigidbody;
    public Camera mainCamera;

    public float playerSpeed = 30f;
    public float rotateSpeed = 10f;

    private Vector3 targetVector = Vector3.zero;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;

        playerInput = GetComponent<PlayerInput>();
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
    
    void FixedUpdate() {
        MoveTowardTarget(targetVector);
        RotateTowardTarget(targetVector);
    }

    private void RotateTowardTarget(Vector3 targetVector)
    {
        if (targetVector.magnitude == 0) {
            return;
        }
        var rotation = Quaternion.LookRotation(targetVector);
        rigidbody.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        targetVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * targetVector;
        rigidbody.transform.position += targetVector * playerSpeed * Time.fixedDeltaTime;
    }

    private void PlayerActionTriggered(InputAction.CallbackContext callback)
    {
        Debug.Log(callback.action);
        switch (callback.action.name) {
            case "Move":
                SetMovement(callback.ReadValue<Vector2>());
            break;
        }
    }

    private void SetMovement(Vector2 inputActionVector)
    {
        targetVector = new Vector3(inputActionVector.x, 0, inputActionVector.y);
    }
}
