using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    public HealthController healthController;
    public GameObject boss;
    public GameObject flameBlob1;
    public GameObject flameBlob2;
    public GameObject flameBlob3;
    public GameObject flameBlob4;
    public GameObject ladder;

    public ParticleSystem deathSplash;
    public List<GameObject> weapons;

    public void Initiate() 
    {
        // Destroy Flames
        Instantiate(deathSplash, flameBlob1.transform.position, Quaternion.identity);
        Destroy(flameBlob1);
        Instantiate(deathSplash, flameBlob2.transform.position, Quaternion.identity);
        Destroy(flameBlob2);
        Instantiate(deathSplash, flameBlob3.transform.position, Quaternion.identity);
        Destroy(flameBlob3);
        Instantiate(deathSplash, flameBlob4.transform.position, Quaternion.identity);
        Destroy(flameBlob4);

        // Destroy Boss
        Instantiate(deathSplash, boss.transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Destroy(boss);

        // Spawn new Weapon
        var rand = RandomGenerator.random.Next(1, 10);
        if (rand < 7)
            Instantiate(weapons[0], boss.transform.position, Quaternion.identity);
        else
            Instantiate(weapons[1], boss.transform.position, Quaternion.identity);

        // Spawn ladder
        Instantiate(ladder, new Vector3(-0.53f, 10.16f, 0f), Quaternion.identity);
    }
}
