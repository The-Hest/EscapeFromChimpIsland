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
            var test = Instantiate(obj, spawnPoint, Quaternion.identity);

            if (test.CompareTag("Enemy"))
            {
                // Set location of the room the enemy has been spawned in
                var spawnRoom = test.AddComponent<SpawnRoom>();
                spawnRoom.spawnRoomPos = transform.position;
            }
        }
    }

    private GameObject SpawnObjectFromDistribution()
    {
        /// -----------------------------
        /// |  Object       |  Chance   |
        /// -----------------------------
        /// |  Potion       |   15%     |
        /// -----------------------------
        /// |  Large Orge   |   30%     |  
        /// -----------------------------
        /// |  Small Orge   |   30%     |
        /// -----------------------------
        /// |  Blue Shooter |   10%     |
        /// -----------------------------
        /// |  Red Shooter  |   15%     |
        /// -----------------------------


        var rand = RandomGenerator.random.Next(0, 100);
        if (rand < 15)
        {
            // Spawn health potion
            return spawnList[4];
        }
        if (rand >= 15 && rand < 45)
        {
            return spawnList[0];
        }
        else if (rand >= 45 && rand < 75)
        {
            return spawnList[1];
        }
        else if (rand >= 75 && rand < 85)
        {
            return spawnList[2];
        }
        else
        {
            return spawnList[3];
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
            case "EnemyShootboi Variant":
                return 1;
            case "RedEnemyShootboi Variant":
                return 3;

            default:
                return 2;
        }
    }
}
