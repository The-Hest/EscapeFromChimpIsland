using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    public List<string> inventory;
    public GameObject itemButton;
    
    private Inventory mInventory;
    private GameObject _weapon;

    private void Start()
    {
        mInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _weapon = GameObject.Find("Gun");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "Collectibles")
        {
            if (Input.GetKey(KeyCode.E))
            {
                for (int i = 0; i < mInventory.slots.Count; i++)
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
        else if (collision.CompareTag("Player") && gameObject.tag == "Weapon")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _weapon.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                _weapon.GetComponent<Shoot>().bulletPrefab = gameObject.GetComponent<Shoot>().bulletPrefab;
                _weapon.GetComponent<Shoot>().bulletForce = gameObject.GetComponent<Shoot>().bulletForce;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.tag == "Collectibles")
        {
            if (Input.GetKey(KeyCode.E))
            {
                for (int i = 0; i < mInventory.slots.Count; i++)
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
        else if (collision.CompareTag("Player") && gameObject.tag == "Weapon")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _weapon.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                _weapon.GetComponent<Shoot>().bulletPrefab = gameObject.GetComponent<WeaponHandler>().bulletPrefab;
                _weapon.GetComponent<Shoot>().bulletForce = gameObject.GetComponent<WeaponHandler>().bulletForce;
            }
        }
    }
}
