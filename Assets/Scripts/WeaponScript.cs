using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float fireSpeed = 10f;
    public bool fired = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fired) {
            this.rigidBody.transform.Translate(new Vector3(1, 0, 0) * fireSpeed * Time.fixedDeltaTime);
        }
    }

    public void Fire(GameObject player) {
        fired = true;
    }
}
