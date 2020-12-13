using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem bulletSplash;
    public DamageController damageController;




    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy" || col.tag == "Boss")
        {
            col.gameObject.GetComponent<HealthController>().DamageTaken(damageController.damage);
            Destroy(col.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(bulletSplash, rb.position, Quaternion.identity);
        Destroy(gameObject);        
    }
    
}
