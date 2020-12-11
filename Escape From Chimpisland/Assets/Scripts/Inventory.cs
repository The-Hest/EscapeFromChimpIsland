using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public bool[] isSelected;



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

}

