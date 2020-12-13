using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallFlameShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        if (facingRight)
        {
        }
        else
        {
        }
        InvokeRepeating("Shooting", 2.0f, 2.0f);
    }

    private void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
