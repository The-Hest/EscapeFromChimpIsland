using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
   
    private Transform _target;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("bossShooting", 1f, 1f);
    }

    // Update is called once per frame
  

    private void bossShooting()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        print($"{_target} BULLET{firePoint.position} {firePoint.rotation}");
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
