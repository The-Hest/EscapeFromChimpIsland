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
        // Make sure not to spawn objects in entry room
        if (Vector3.Distance(transform.position, Vector3.zero) < 8)
            return;

        var obj = SpawnObjectFromDistribution();
        var objectsToSpawn = GetAmountToSpawn(obj);

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
                // Spawn potions in line
                randX = i - 1;
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
        /// |  Potion       |   15%     |
        /// -----------------------------
        /// |  Large Orge   |   40%     |  
        /// -----------------------------
        /// |  Small Orge   |   45%     |
        /// -----------------------------
        /// |  ......       |   ..%     |
        /// -----------------------------

        var rand = RandomGenerator.random.Next(0, 100);
        if (rand < 15)
        {
            // Spawn health potion
            return spawnList[2];
        }
        if (rand >= 15 && rand < 55)
        {
            return spawnList[0];
        }
        else if (rand >= 55 && rand <= 100)
        {
            return spawnList[1];
        }
        else 
        {
            return spawnList[1];
        }
    }
    private int GetAmountToSpawn(GameObject gameobject)
    {
        switch (gameobject.name)
        {
            case "Enemy":
                return RandomGenerator.random.Next(2, 4);
            case "FirstEnemy":
                return RandomGenerator.random.Next(4, 7);
            default:
                return 2;
        }
    }
}
