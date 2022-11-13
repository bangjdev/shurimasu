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

    public float fireSpeed;
    public float rotationSpeed;
    public float flyDuration;
    public bool fired = false;

    private FLY_STATUS status = FLY_STATUS.NONE;
    

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (status) {
            case FLY_STATUS.NONE:
                return;
            case FLY_STATUS.FLY_AWAY:
                this.rigidBody.transform.Translate(new Vector3(1, 0, 0) * fireSpeed * Time.fixedDeltaTime);
            break;
            case FLY_STATUS.HANGING:
            break;
            case FLY_STATUS.FLY_BACK:
                this.rigidBody.transform.position = Vector3.MoveTowards(this.rigidBody.transform.position, player.position, Time.fixedDeltaTime * fireSpeed);
            break;
        }
    }

    public IEnumerator Fire(Transform player) {
        this.player = player;
        status = FLY_STATUS.FLY_AWAY; 
        yield return new WaitForSeconds(2 * flyDuration / 5);
        status = FLY_STATUS.HANGING; 
        yield return new WaitForSeconds(flyDuration / 5);
        status = FLY_STATUS.FLY_BACK; 
    }
}
