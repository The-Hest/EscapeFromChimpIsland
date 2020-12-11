using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHealthPotion : MonoBehaviour
{

    public GameObject effect;
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Use()
    {

        //Tilgå healthController her og + ønsket health
        //Evt tilføj lyd her hvis det er sådan man gør
        Instantiate(effect, player.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
