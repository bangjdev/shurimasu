using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public Camera mainCamera;

    public float movementSpeed = 30f;
    public float rotationSpeed = 20f;

    private Vector3 targetVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    
    void FixedUpdate() {
        MoveTowardTarget(targetVector);
        RotateTowardTarget(targetVector);
    }

    public void SetMovementVector(Vector2 inputActionVector)
    {
        this.targetVector = new Vector3(inputActionVector.x, 0, inputActionVector.y);
    }

    private void RotateTowardTarget(Vector3 targetVector)
    {
        if (targetVector.magnitude == 0) {
            return;
        }
        var rotation = Quaternion.LookRotation(targetVector);
        rigidbody.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        targetVector = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * targetVector;
        rigidbody.transform.position += targetVector * movementSpeed * Time.fixedDeltaTime;
    }

}
