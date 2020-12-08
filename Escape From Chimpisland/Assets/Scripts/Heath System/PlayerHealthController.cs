using UnityEngine;

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
        var collisionObj = collision.gameObject; 
        int dmg;
        if (collisionObj.tag.Equals("Enemy"))
        {
            switch (collisionObj.name.Replace("(Clone)", ""))
            {
                case "Enemy":
                    dmg = collisionObj.GetComponent<Enemy>().damageController.damage;
                    Debug.Log($"hej {collisionObj.name.Replace("(Clone)", "")}");
                    break;
                case "FirstEnemy":
                    dmg = collisionObj.GetComponent<BabyOrge>().damageController.damage;
                    Debug.Log($"hej {collisionObj.name.Replace("(Clone)", "")}");
                    break;
                default:
                    dmg = 1;
                    break;
            }
            healthController.DamageTaken(dmg);
        }
    }
}
