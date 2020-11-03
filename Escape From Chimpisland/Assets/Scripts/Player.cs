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

    private void Start()
    {
        dashTime = dashDuration;
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

        Move();
       
        

    }

    public void ProcessInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        

        if (moveDirection.x > 0 && !playerSprite.flipX) playerSprite.flipX = true;
        else if (moveDirection.x < 0 && playerSprite)   playerSprite.flipX = false;


        if (Input.GetKeyDown(KeyCode.C))
        {
            Dash();
        }
        else
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
        rigidgebody.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        //if (dashTime <= 0)
        //{
        //    dashTime = dashDuration;
        //    rigidgebody.velocity = Vector2.zero;
        //}
        //else if (dashTime >= 0)
        //{
        //    dashTime -= Time.deltaTime;
        //    Debug.Log($"Dash {dashTime}");
        //    rigidgebody.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        //}
    }

}
