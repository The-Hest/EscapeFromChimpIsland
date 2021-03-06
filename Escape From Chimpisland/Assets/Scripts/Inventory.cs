﻿using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> slots;

    public bool[] isFull;
    public bool[] isSelected;

    private void Start()
    {
        LoadUISlots();
    }

    public void DropItem(int x)
    {
        foreach (Transform child in slots[x].transform)
        {
            child.GetComponent<RespawnItem>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }

        isFull[x] = false;

    }

    public void UseAnItem(int x)
    {
        foreach (Transform child in slots[x].transform)
        {
            if (child.CompareTag("healthPotion"))
            {
                child.GetComponent<UseHealthPotion>().Use();
            }

            Destroy(child.gameObject);
            isFull[x] = false;

        }
    }


    public string getItem(int x)
    {
        string nameOfItem = "no item";

        foreach (Transform child in slots[x].transform)
        {
            if (child.tag == "healthPotion")
            {
                nameOfItem = "healthPotion";
            }
            else if (child.tag == "energyPotion")
            {
                nameOfItem = "energyPotion";
            }
            else if (child.tag == "skullArt")
            {
                nameOfItem = "skullArt";
            }

            /*
            if (slots[x].GetComponentInChildren<GameObject>().CompareTag("healthPotion"))
            {
                nameOfItem = "healthPotion";
            }else if (slots[x].GetComponentInChildren<GameObject>().CompareTag("energyPotion"))
            {
                nameOfItem = "energyPotion";
            }
            */
        }
        return nameOfItem;
    }

    public void LoadUISlots()
    {
        slots = new List<GameObject>()
        {
            GameObject.Find("Slot(1)"),
            GameObject.Find("Slot(2)"),
            GameObject.Find("Slot(3)"),
            GameObject.Find("Slot(4)"),
            GameObject.Find("Slot(5)"),
        };
    }

}

