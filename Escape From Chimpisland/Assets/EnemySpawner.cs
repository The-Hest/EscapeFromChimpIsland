using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> spawnList;

    private float randX;
    private float randY;
    private Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        var obj = SpawnObjectFromDistribution();
        var objectsToSpawn = GetAmountOfEnemiesToSpawn(obj);

        for (int i = 0; i <= objectsToSpawn; i++)
        {
            if (obj.CompareTag("Enemy"))    
            {
                // Enemies spawn random in room
                randX = Random.Range(5.5f, -5.5f); //Et rums bredde i unity units
                randY = Random.Range(1.5f, -1.5f); //Et rums højde i unity units
            }
            else
            {
                // Chest spawn in center
                randX = 0;
                randY = 0;
            }
            spawnPoint = new Vector2(randX + transform.position.x, randY + transform.position.y);
            Instantiate(obj, spawnPoint, Quaternion.identity);
        }
    }

    private GameObject SpawnObjectFromDistribution()
    {
        /// -----------------------------
        /// |  Object       |  Chance   |
        /// -----------------------------
        /// |  Chest        |    5%     |
        /// -----------------------------
        /// |  Enemy1       |   10%     |  
        /// -----------------------------
        /// |  Enemy2       |   15%     |
        /// -----------------------------
        /// |  ......       |   ..%     |
        /// -----------------------------

        var rand = new System.Random().Next(0, 100);
        if (rand < 5)
        {
            // Spawn chest
            return spawnList[0];
        }
        if (rand > 5 && rand < 15)
        {
            return spawnList[0];
        }
        else if (rand >= 15 && rand < 30)
        {
            return spawnList[1];
        }
        else
        {
            return spawnList[0];
        }
    }
    private int GetAmountOfEnemiesToSpawn(GameObject enemy)
    {
        switch (enemy.name)
        {
            case "Enemy":
                return new System.Random().Next(2, 4);
            case "FirstEnemy":
                return new System.Random().Next(4, 7);
            default:
                return 2;
        }
    }
}
