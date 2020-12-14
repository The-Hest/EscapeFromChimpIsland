using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public HealthController healthController;
    public DamageController damageController;
    public HealingController healingController;

    private Text _healthUIText;
    private healthBar _healthBar;

    // Start is called before the first frame update
    public void Start()
    {
        LoadUIHealthBar();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Boss") || collision.collider.CompareTag("EnemyBullet"))
        {
            var dmg = collision.collider.GetComponent<DamageController>().damage;
            healthController.DamageTaken(dmg);
            UpdateHealthUI();
        }

        // If hit by a none hostile object do nothing
    }

    /// <summary>
    /// Updates the Canvas with the Health Text element 
    /// </summary>
    public void UpdateHealthUI()
    {
        _healthUIText.text = healthController.health.ToString();
        _healthBar.SetHealth(healthController.health);
    }

    public void LoadUIHealthBar()
    {
        _healthUIText = GameObject.Find("Health Display").GetComponent<Text>();
        _healthBar = GameObject.Find("Health bar").GetComponent<healthBar>();
        UpdateHealthUI();
    }
}
