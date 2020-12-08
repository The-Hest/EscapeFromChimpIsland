using UnityEngine;

public class Behavior : MonoBehaviour
{
    public float fov;
    public float fleeRange;
    public float moveSpeed;
    public float fleeMoveSpeed;
    public float scoutMoveSpeed;
    public float fleeDistanceY;

    private Transform player;
    private Vector2 moveTo;
    private enum Feelings
    {
        Neutral,
        Scared,
        Attack,
        Scout,
    }
    private Feelings feeling;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveTo = new Vector2(transform.position.x, transform.position.y + fleeDistanceY); // Flee Position
        feeling = Feelings.Neutral;
    }

    // Update is called once per frame
    void Update()
    {
        switch (feeling)
        {
            case Feelings.Neutral:
                // First encounter flee
                if (Vector2.Distance(transform.position, player.position) < fleeRange)
                {
                    feeling = Feelings.Scared;
                }

                break;
            case Feelings.Scared:
                // Since the character only moves upwards check if it reached the position then its ready for attack
                if (transform.position.y != moveTo.y)
                {
                    transform.position = Vector2.MoveTowards(transform.position, moveTo, fleeMoveSpeed * Time.deltaTime);
                }
                else { feeling = Feelings.Attack; }

                break;
            case Feelings.Attack:
                // In if player in range go for attack
                if (Vector2.Distance(transform.position, player.position) < fov)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                }
                else { feeling = Feelings.Scout; }

                break;
            case Feelings.Scout:
                // Try to find the player
                float displacementX = Random.Range(-0.3f, 0.3f);
                float displacementY = Random.Range(-0.3f, 0.3f);
                moveTo.x += displacementX;
                moveTo.y += displacementY;

                transform.position = Vector2.MoveTowards(transform.position, moveTo, scoutMoveSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, player.position) < fov) { feeling = Feelings.Attack; }

                break;
        }
    }
}
