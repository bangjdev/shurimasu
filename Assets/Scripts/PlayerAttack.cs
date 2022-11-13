using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform throwingPoint;
    public GameObject throwingWeaponPrefab;
    public GameObject inHandWeapon;
    public float pickupDelay = 0.2f;
    public bool allowPickup = true;

    private bool canThrow = true;

    public IEnumerator Throw() {
        if (canThrow) {
            StartCoroutine(Instantiate(throwingWeaponPrefab, throwingPoint.position, throwingPoint.rotation).GetComponent<WeaponScript>().Fire(transform));
            canThrow = false;
            allowPickup = false;
            yield return new WaitForSeconds(pickupDelay);
            allowPickup = true;
        }
    }

    void FixedUpdate() {
        inHandWeapon.SetActive(canThrow);
    }
    
    private void OnTriggerEnter(Collider obj)
    {
        if (!allowPickup) {
            return;
        }
        if (obj.name.StartsWith("Weapon")) {
            canThrow = true;
            Destroy(obj.gameObject);
        }
    }
}
