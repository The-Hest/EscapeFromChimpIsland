using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem bulletSplash;
    public DamageController damageController;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthController>().DamageTaken(5);
            collision.gameObject.GetComponent<PlayerHealthController>().UpdateHealthUI();
            Instantiate(bulletSplash, rb.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    /*
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
       
            Instantiate(bulletSplash, rb.position, Quaternion.identity);
            Destroy(gameObject);
        
    }
    */
}
