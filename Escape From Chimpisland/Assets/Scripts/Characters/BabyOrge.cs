using UnityEngine;

public class BabyOrge : MonoBehaviour
{

    public float speed;
    public float attackingDistance;
    public Rigidbody2D enemyrigidgebody;
    public DamageController damageController;

    private Transform target;
    private float contact = 0.8f;

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
    }

    void Enemymovement()
    {

        //follow player hvis enemy er indenfor attackingDistance
        var distToPlayer = Vector2.Distance(transform.position, target.position);
        if ( distToPlayer < attackingDistance && distToPlayer > contact)
        {
            /* if (Vector2.Distance(transform.position, target.position) <0.79)
             {

             }*/

            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

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
