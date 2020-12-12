using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem bulletSplash;

    private Transform _target;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
   
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
