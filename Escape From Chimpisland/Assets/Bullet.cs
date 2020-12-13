using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem bulletSplash;
    public DamageController damageController;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
            return;

        Instantiate(bulletSplash, rb.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
