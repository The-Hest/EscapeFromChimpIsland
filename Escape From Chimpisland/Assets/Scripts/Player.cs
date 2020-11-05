using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float dashSpeed;
    public float dashDuration;
    public Rigidbody2D rigidgebody;
    public SpriteRenderer playerSprite;


    private Vector2 moveDirection = new Vector2();
    private Vector2 currentVelocity = new Vector2();
    private float dashTime;
    private bool dashing;

    private void Start()
    {
        dashTime = dashDuration;
        dashing = false;
    }



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
    }

    public void ProcessInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");


        if (moveDirection.x > 0 && !playerSprite.flipX) playerSprite.flipX = true;
        else if (moveDirection.x < 0 && playerSprite) playerSprite.flipX = false;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashing = true;
        }

        if (dashing)
        {
            if (dashTime > 0)
            {
                Dash();
                dashTime -= Time.deltaTime;
            }
            else
            {
                dashTime = dashDuration;
                dashing = false;
            }
        }
        else if (!dashing)
        {
            Move();
        }
    }

    public void Move()
    {
        rigidgebody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    public void Dash()
    {
        transform.Translate(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed, 0);
    }

}
