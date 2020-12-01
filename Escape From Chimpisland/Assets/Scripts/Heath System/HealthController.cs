using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Text healthUIText;
    public int playerHealth;

    public healthBar healthBar;

    public void HealingReceived(int healing)
    {
        playerHealth += healing;
        UpdateHealthUI();

        healthBar.SetHealth(playerHealth);

    }

    public void DamageTaken(int damage)
    {
        playerHealth -= damage;
        UpdateHealthUI();
        
        healthBar.SetHealth(playerHealth);

    }

    /// <summary>
    /// Updates the Canvas with the Health Text element 
    /// </summary>
    public void UpdateHealthUI()
    {
        healthUIText.text = playerHealth.ToString();
    }
}
