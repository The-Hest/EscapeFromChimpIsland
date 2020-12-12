using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public HealthController healthController;

    private int dmg;

    private void Update()
    {
        if (healthController.dead)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObj = collision.gameObject;
        if (collisionObj.tag.Equals("Bullet"))
        {
            dmg = collisionObj.GetComponent<DamageController>().damage;
            healthController.DamageTaken(dmg);
        }
    }
}
