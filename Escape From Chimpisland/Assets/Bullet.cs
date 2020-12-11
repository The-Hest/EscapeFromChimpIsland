using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem bulletSplash;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(bulletSplash, rb.position, Quaternion.identity);

        Destroy(gameObject);        
    }
    
}
