using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody rigidBody;
    private float enemySpeed = 5;
    private float maxHealth = 10f;
    private float currentHealth = 10f;
    private float attackRate = 1f;
    private float lastAttackTime;
    private float damage = 5f;
    void Start()
    {
        player = GameObject.Find("Player");       
        rigidBody = GetComponent<Rigidbody>();
        lastAttackTime = Time.time;
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

    public void TakeDamage(float damage) {
        this.currentHealth -= damage;
        if (this.currentHealth < 0) {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision obj) {
    }

    public void OnCollisionStay(Collision collision) {
        if (collision.gameObject.GetInstanceID() == player.GetInstanceID()) {
            if ((Time.time - lastAttackTime) < (1 / attackRate)) {
                return;
            }
            lastAttackTime = Time.time;
            player.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
