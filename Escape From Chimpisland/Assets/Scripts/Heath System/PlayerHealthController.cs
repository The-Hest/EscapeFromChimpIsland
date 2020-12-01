using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealthController : MonoBehaviour
{
    public HealthController healthController;
    public DamageController damageController;
    public HealingController healingController;

    // Start is called before the first frame update
    public void Start()
    {
        healthController.playerHealth = 100;
        healthController.UpdateHealthUI();

    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log($"{healthController.playerHealth} {healthController.dead}");
        if (healthController.dead)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Healing"))
        {
            healthController.HealingReceived(healingController.healing);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            healthController.DamageTaken(damageController.damage);
        }
    }
}
