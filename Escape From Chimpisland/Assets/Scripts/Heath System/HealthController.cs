using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool dead;

    public void HealingReceived(int healing)
    {
        // Update health as long as its less than max
        if (health + healing <= maxHealth)
        {
            health += healing;
        }
        else if(health < maxHealth && health + healing >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void DamageTaken(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            dead = true;
        }
    }

    public int GetHealthAsPercent()
    {
        return (int)(((float)health / (float)maxHealth) * 100);
    }
}
