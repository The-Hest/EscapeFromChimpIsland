using UnityEngine;

public class BabyOrge : MonoBehaviour
{

    public float speed;
    public float attackingDistance;
    public Rigidbody2D enemyrigidgebody;
    public DamageController damageController;

    private Transform _target;
    private float _contact = 0.8f;
    private SpawnRoom _spawnRoom;

    // Start is called before the first frame update
    void Start()
    {
        //Sætter target til at være lig player og GetComponent<Transform>() finder player position
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _spawnRoom = GetComponent<SpawnRoom>();
    }

    // Update is called once per frame
    void Update()
    {
        Enemymovement();
    }

    void Enemymovement()
    {
        // If player is not in the room as the mob 
        if (!CheckIfPlayerInRoom())
            return;
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, speed / 2 * Time.deltaTime);
        }

        //follow player hvis enemy er indenfor attackingDistance
        var distToPlayer = Vector2.Distance(transform.position, _target.position);
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

    private bool CheckIfPlayerInRoom()
    {
        if (_target.position.x > _spawnRoom.spawnRoomPos.x - 10.7f &&
            _target.position.x < _spawnRoom.spawnRoomPos.x + 10.7f &&
            _target.position.y > _spawnRoom.spawnRoomPos.y - 4.6f &&
            _target.position.y < _spawnRoom.spawnRoomPos.y + 4.6f)
            return true;
        else
            return false;
    }

}
