using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float dashSpeed;
    public float dashDuration;
    public Rigidbody2D rigidgebody;
    public SpriteRenderer playerSprite;
    public ParticleSystem dashParticles;
   


    private Vector2 moveDirection = new Vector2();
    private float dashTime;
    private bool dashing;

    private int numericPressed;
    private Inventory mInventory;
    private GameObject highlighter;
    private string currentItem;

    private void Start()
    {
        mInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        highlighter = GameObject.FindGameObjectWithTag("Highlighter");
        highlighter.transform.position = mInventory.slots[0].transform.position;

        dashTime = dashDuration;
        dashing = false;
    }



    // Update is called once per frame
    void Update()
    {
        ProcessInput();

    }

    public void ProcessInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        SelectInventory();

        if (moveDirection.x > 0 && !playerSprite.flipX)
        {
            playerSprite.flipX = true;
            dashParticles.transform.rotation = Quaternion.Euler(0f,0f, 180f);
        }
        else if (moveDirection.x < 0 && playerSprite)
        {
            playerSprite.flipX = false;
            dashParticles.transform.rotation = Quaternion.Euler(0f,0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
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
        FindObjectOfType<AudioManager>().Play("PlayerDash");
        transform.Translate(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed, 0);
        dashParticles.Play();
    }

    private void SelectInventory()
    {
        if (Input.GetKey("1"))
        { 
            numericPressed = 1;
        
            for (int i = 0; i < mInventory.slots.Length; i++)
            {
                mInventory.isSelected[i] = false;
            }

            int x = 0;
            mInventory.isSelected[x] = true;
            highlighter.transform.position = mInventory.slots[x].transform.position;
            currentItem = mInventory.getItem(x);
            print("Player holding " + currentItem);
        }

        if (Input.GetKey("2"))
        {
            numericPressed = 2;
        
            for (int i = 0; i < mInventory.slots.Length; i++)
            {
                mInventory.isSelected[i] = false;
            }

            int x = 1;
            mInventory.isSelected[x] = true;
            highlighter.transform.position = mInventory.slots[x].transform.position;
            currentItem = mInventory.getItem(x);
            print("Player holding " + currentItem);
        }

        if (Input.GetKey("3"))
        { 
            numericPressed = 3;
        
            for (int i = 0; i < mInventory.slots.Length; i++)
            {
                mInventory.isSelected[i] = false;
            }

            int x = 2;
            mInventory.isSelected[x] = true;
            highlighter.transform.position = mInventory.slots[x].transform.position;
            currentItem = mInventory.getItem(x);
            print("Player holding " + currentItem);
        }

        if (Input.GetKey("4"))
        { 
            numericPressed = 4;
        
            for (int i = 0; i < mInventory.slots.Length; i++)
            {
                mInventory.isSelected[i] = false;
            }

            int x = 3;
            mInventory.isSelected[x] = true;
            highlighter.transform.position = mInventory.slots[x].transform.position;
            currentItem = mInventory.getItem(x);
            print("Player holding " + currentItem);
        }

        if (Input.GetKey("5"))
        {
            numericPressed = 5;
            for (int i = 0; i < mInventory.slots.Length; i++)
            {
                mInventory.isSelected[i] = false;
            }

            int x = 4;
            mInventory.isSelected[x] = true;
            highlighter.transform.position = mInventory.slots[x].transform.position;
            currentItem = mInventory.getItem(x);
            print("Player holding " + currentItem);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            mInventory.DropItem(numericPressed-1);
        }
    }
}
