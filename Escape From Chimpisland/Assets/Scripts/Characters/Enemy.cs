using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float attackingDistance;
    public Rigidbody2D enemyrigidgebody;
    public DamageController damageController;

    private float _contact = 0.95f;
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        //Sætter target til at være lig player og GetComponent<Transform>() finder player position
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemymovement();
    }

    void Enemymovement()
    {
        var distToPlayer = Vector2.Distance(transform.position, _target.position);
        if (distToPlayer > 15f)
            return;

        var ray = Physics2D.Raycast(transform.position, _target.position, 15f);
        print(ray);

        //follow player hvis enemy er indenfor attackingDistance
        if (distToPlayer < attackingDistance && distToPlayer > _contact)
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            return;
        }
    }

}
