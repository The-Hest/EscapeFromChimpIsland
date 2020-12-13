using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHealthPotion : MonoBehaviour
{

    public GameObject effect;
    public GameObject healthController;
    private Transform player;
    public ParticleSystem usePotion;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Use()
    {

        //Evt tilføj lyd her hvis det er sådan man gør
        player.GetComponent<HealthController>().HealingReceived(50);
        print("Fcuk");
        audioSource.Play();
        print("Fcuko");
        Instantiate(effect, player.position, Quaternion.identity);
        Instantiate(usePotion, player.transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        
    }
}
