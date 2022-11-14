using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = .3f;
    public GameObject enemyPrefab;

    private float lastSpawnTime = 0;
    private float currentHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Time.time - lastSpawnTime) >= 1.0 / spawnRate) {
            lastSpawnTime = Time.time;
            var position = new Vector3(Random.Range(-20, 20), 4, Random.Range(-20, 20));
            StartCoroutine(Spawn(position));
        }
    }

    IEnumerator Spawn(Vector3 location) {
        var enemy = Instantiate(enemyPrefab, location, this.transform.rotation);
        enemy.GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(2);
        enemy.GetComponent<Rigidbody>().useGravity = true;
    }
}
