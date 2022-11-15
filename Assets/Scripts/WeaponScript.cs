using System.Collections;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    enum FLY_STATUS {
        NONE,
        FLY_AWAY,
        HANGING,
        FLY_BACK,

    };
    public Rigidbody rigidBody;

    private float fireSpeed = 50f;
    private float rotationSpeed = 50f;
    private float flyDuration = 1.25f;
    private float weaponDamage = 10f;

    private FLY_STATUS status = FLY_STATUS.NONE;
    private Transform player;
    private Transform gfx;
    // Start is called before the first frame update
    void Start()
    {
        gfx = this.transform.Find("Gfx");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (status) {
            case FLY_STATUS.NONE:
                return;
            case FLY_STATUS.FLY_AWAY:
                this.rigidBody.transform.Translate(new Vector3(0, 0, 1) * fireSpeed * Time.fixedDeltaTime);
            break;
            case FLY_STATUS.HANGING:
            break;
            case FLY_STATUS.FLY_BACK:
                this.rigidBody.transform.position = Vector3.MoveTowards(this.rigidBody.transform.position, player.position, Time.fixedDeltaTime * fireSpeed);
            break;
        }
        gfx.Rotate(new Vector3(0, 1, 0) * rotationSpeed, Space.World);
    }

    public IEnumerator Fire(Transform player) {
        this.player = player;
        status = FLY_STATUS.FLY_AWAY; 
        yield return new WaitForSeconds(2 * flyDuration / 5);
        status = FLY_STATUS.HANGING; 
        yield return new WaitForSeconds(flyDuration / 5);
        status = FLY_STATUS.FLY_BACK; 
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (status == FLY_STATUS.NONE) {
            return;
        }
        if (obj.name.StartsWith("Enemy")) {
            obj.gameObject.GetComponent<Enemy>().TakeDamage(weaponDamage);
        }
    }
}
