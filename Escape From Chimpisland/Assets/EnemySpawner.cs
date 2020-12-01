using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemieList;

    private float randX;
    private float randY;
    private Vector2 spawnPoint;
    private System.Random rand;
    private int enemiesToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        enemiesToSpawn = rand.Next(1, 3);
        Debug.Log(transform.position);

        for (int i = 0; i <= enemiesToSpawn; i++)
        {
            randX = Random.Range(8.5f, -8.5f); //Et rums bredde i unity units
            randY = Random.Range(2.5f, -3.5f); //Et rums højde i unity units

            spawnPoint = new Vector2(randX + transform.position.x, randY + transform.position.y);
            Instantiate(enemieList, spawnPoint, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
