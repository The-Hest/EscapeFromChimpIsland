using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D bossrigidgebody;
    public DamageController damageController;

    private Vector2 _standardPos;
    private Vector2 _leftPos;
    private Vector2 _rightPos;
    private Vector2 _beforedownPos;
    private Vector2 _downPos;
    private int moveToPos;

    // Start is called before the first frame update
    void Start()
    {
        _standardPos = new Vector2(0.57f, 6.34f);
        _leftPos = new Vector2(-7.55f, 6.34f);
        _rightPos = new Vector2(8.55f, 6.34f);
        _beforedownPos = new Vector2(0.54f, 6.35f);
        _downPos = new Vector2(0.54f, -4.35f);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x == 0.57f && transform.position.y == 6.34f)
        {
            moveToPos = 1;
        }

        if (transform.position.x == -7.55f && transform.position.y == 6.34f)
        {
            moveToPos = 2;
        }
        if (transform.position.x == 8.55f && transform.position.y == 6.34f)
        {
            moveToPos = 5;
        }

       /* if (transform.position.x == 0.54f && transform.position.y == 6.35f)
        {
            moveToPos = 4;
        }

        if (transform.position.x == 0.54f && transform.position.y == -4.35f)
        {
            moveToPos = 5;
        } */

        if (moveToPos == 1) { 
            bossMovementLeft();
        }
        if (moveToPos == 2) { 
        bossMovementRight();
        }
        if (moveToPos == 3)
        {
            bossMovementBeforeDown();
        }

        if (moveToPos == 4)
        {
            bossMovementDown();
        }

        if (moveToPos == 5)
        {
            bossMovementStandard();
        }
    }

    void bossMovementLeft()
    {

        transform.position = Vector2.MoveTowards(transform.position, _leftPos, speed * Time.deltaTime);
       
    }
    void bossMovementRight()
    {

       
        transform.position = Vector2.MoveTowards(transform.position, _rightPos, speed * Time.deltaTime);
    }

    void bossMovementStandard()
    {

        transform.position = Vector2.MoveTowards(transform.position, _standardPos, speed * Time.deltaTime);

    }
    void bossMovementBeforeDown()
    {

        transform.position = Vector2.MoveTowards(transform.position, _beforedownPos, speed * Time.deltaTime);

    }
    void bossMovementDown()
    {

        transform.position = Vector2.MoveTowards(transform.position, _downPos, speed * Time.deltaTime);

    }

}
