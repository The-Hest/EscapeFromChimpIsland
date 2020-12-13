using UnityEngine;

public class UseHealthPotion : MonoBehaviour
{

    public GameObject effect;
    public ParticleSystem usePotion;
    public AudioSource audioSource;

    private Transform _playerPos;
    private HealthController _healthController;

    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Use()
    {
        _healthController = _playerPos.GetComponent<HealthController>();
        if (_healthController.health == 100)
            return;

        //Evt tilføj lyd her hvis det er sådan man gør
        audioSource.Play();
        _healthController.HealingReceived(10);
        _playerPos.GetComponent<PlayerHealthController>().UpdateHealthUI();

        Instantiate(effect, _playerPos.position, Quaternion.identity);
        Instantiate(usePotion, _playerPos.transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
}
