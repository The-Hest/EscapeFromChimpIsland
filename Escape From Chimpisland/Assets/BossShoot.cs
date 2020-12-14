using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float speed = 2f;

    private Vector3 _extendedFirepoint;
    private float _scalar = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartShooting(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void bossShooting()
    {
        // Get Vector between Boss and Player
        // _extendedFirepoint = (firePoint.position - GameObject.Find("Player").GetComponent<Transform>().position) * _scalar;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void StartShooting(float beginIn, float repeatInterval)
    {
        InvokeRepeating("bossShooting", beginIn, repeatInterval);
    }

    public void StopShooting()
    {
        CancelInvoke("bossShooting");
    }

    public void ResetShooting(float beginIn, float repeatInterval)
    {
        StopShooting();
        StartShooting(beginIn, repeatInterval);

    }
}
