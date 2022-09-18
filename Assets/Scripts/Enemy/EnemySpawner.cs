using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Enemy[] enemies;
    [SerializeField] GameObject enemySpawnPlate;

    [SerializeField] Vector2 upperLeft, bottomRight;

    [Header("Settings")]
    [SerializeField] private int enemyCount = 3;


    private float xFactor = 10.0f;
    private float safeOffset = 2.0f;


    private void Awake()
    {
        enemies = Resources.LoadAll<Enemy>("Enemies/");
    }


    void Start()
    {
        GetSpawnPlateDemenshion();
        SpawnEnemy(enemies);
    }


    public void SpawnEnemy(Enemy[] enemy)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(upperLeft.x, bottomRight.x), 0,
                                    Random.Range(bottomRight.y, upperLeft.y));

            int whatEnemySpawn = Random.Range(0, enemy.Length);
            GameObject newEnemy = Instantiate(enemy[whatEnemySpawn].model, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = transform;
        }
    }


    private void GetSpawnPlateDemenshion()
    {
        Vector3 scale = enemySpawnPlate.transform.localScale;
        upperLeft.x = enemySpawnPlate.transform.position.x - scale.x * xFactor /2 + safeOffset ;
        bottomRight.x = enemySpawnPlate.transform.position.x + scale.x * xFactor /2 - safeOffset;

        upperLeft.y = enemySpawnPlate.transform.position.z + scale.z * xFactor /2 - safeOffset;
        bottomRight.y = enemySpawnPlate.transform.position.z - scale.z * xFactor / 2 + safeOffset;
    }
}
