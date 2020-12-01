using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float attackingDistance;
    public Rigidbody2D enemyrigidgebody;
    public DamageController damageController;
    Collider2D collision;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //Sætter target til at være lig player og GetComponent<Transform>() finder player position
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Enemymovement();
        OnTriggerEnter2D(collision);
    }

    void Enemymovement()
    {

        //follow player hvis enemy er indenfor attackingDistance
        if (Vector2.Distance(transform.position, target.position) < attackingDistance)
        {

           /* if (Vector2.Distance(transform.position, target.position) <0.79)
            {
             
            }*/
            
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

        }
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            return;
        }
    }

}
