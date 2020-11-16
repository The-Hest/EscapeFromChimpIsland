using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    private Inventory mInventory;
    public List<string> inventory;
    public GameObject itemButton;
    private string itemType;

    private void Start()
    {
        mInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


            if (Input.GetKey(KeyCode.E))
            {


                for (int i = 0; i < mInventory.slots.Length; i++)
                {
                    if (mInventory.isFull[i] == false)
                    {
                        //Item can now be added to inventory
                        mInventory.isFull[i] = true;
                        Instantiate(itemButton, mInventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                   
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          

            if (Input.GetKey(KeyCode.E))
            {
               
                

                for (int i = 0; i < mInventory.slots.Length; i++)
                {
                    if (mInventory.isFull[i] == false)
                    {
                        //Item can now be added to inventory
                        mInventory.isFull[i] = true;
                        Instantiate(itemButton, mInventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }

                }
            }
        }
    }
}
