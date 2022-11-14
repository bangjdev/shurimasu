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
        this.rigidBody.transform.position = Vector3.MoveTowards(this.rigidBody.transform.position, player.transform.position, Time.fixedDeltaTime * enemySpeed);
    }
}
