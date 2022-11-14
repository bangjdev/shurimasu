using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = .3f;
    public GameObject enemyPrefab;
    public Transform spawnLocation;

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
            Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
        }
    }
}
