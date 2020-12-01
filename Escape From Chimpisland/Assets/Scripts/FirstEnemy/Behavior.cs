using UnityEngine;

public class Behavior : MonoBehaviour
{
    public float fleeRange;
    public float attackRange;
    public float speed;
    public float fleeDistanceY;

    private Transform player;
    private bool fled;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // First encounter flee
        if (!fled)
        {
            if (Vector2.Distance(transform.position, player.position) < fleeRange)
            {
                transform.Translate(0, transform.position.y + fleeDistanceY, 0);
                fled = true;
            }
        }
        else
        {
            // In if player in range go for attack
            if (Vector2.Distance(transform.position, player.position) < attackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }
}
