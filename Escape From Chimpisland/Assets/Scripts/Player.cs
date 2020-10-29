using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rigidgebody;

    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
    }

    /// <summary>
    /// Used for physics calculation as this is consitent 
    /// </summary>
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rigidgebody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
}
