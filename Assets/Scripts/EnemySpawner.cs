using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemy_Target;
    [SerializeField] float enemy_SpawnRadius;
    [SerializeField] float enemy_SpawnRate;
    [SerializeField] List<GameObject> enemy_Prefabs = new();

    List<Enemy> spawnedEnemies = new();

    float current_EnemySpawn;

    public void UpdateEnemySpawner()
    {
        enemy_SpawnRate = Player.PlayerLevel + 1;
        
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            spawnedEnemies[i].UpdateEnemy(enemy_Target.position);
        }
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i].Alive == false)
            {
                Destroy(spawnedEnemies[i].gameObject);
                spawnedEnemies.RemoveAt(i);
            }
        }
        current_EnemySpawn += enemy_SpawnRate * Time.deltaTime;

        if (current_EnemySpawn >= 1 && spawnedEnemies.Count < 50 * Player.PlayerLevel)
        {
            SpawnEnemy();
            current_EnemySpawn = 0;
        }

    }
    public void SpawnEnemy()
    {
        Vector3 randomPosition = Random.insideUnitCircle.normalized * enemy_SpawnRadius;
        int rand = Random.Range(0, enemy_Prefabs.Count);
        GameObject newEnemy = Instantiate(enemy_Prefabs[rand], randomPosition, Quaternion.identity);

        Enemy newEnemyComponent = newEnemy.GetComponent<Enemy>();
        newEnemyComponent.Initialized(enemy_Target);
        spawnedEnemies.Add(newEnemyComponent);
    }
}