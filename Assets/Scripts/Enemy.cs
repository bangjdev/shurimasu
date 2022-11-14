using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody rigidBody;
    private float enemySpeed = 5;
    void Start()
    {
        player = GameObject.Find("Player");       
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.rigidBody.useGravity) {
            this.rigidBody.transform.position = Vector3.MoveTowards(this.rigidBody.transform.position, player.transform.position, Time.fixedDeltaTime * enemySpeed);
            var vectorTowardPlayer = player.transform.position - this.rigidBody.transform.position;
            this.rigidBody.transform.rotation = Quaternion.RotateTowards(this.rigidBody.transform.rotation, Quaternion.LookRotation(vectorTowardPlayer), enemySpeed);
        } else {
            this.rigidBody.transform.Rotate(new Vector3(0, 1, 0) * enemySpeed * 2, Space.World);
        }
    }
}
