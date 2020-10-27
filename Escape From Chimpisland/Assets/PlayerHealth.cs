using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthController healthController;
    public DamageController damageController;

    // Start is called before the first frame update
    public void Start()
    {
        healthController.playerHealth = 100;
        healthController.UpdateHealthUI();
        
    }

    // Update is called once per frame
    public void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        healthController.DamageTaken(damageController.damage);
    }
}
