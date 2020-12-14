using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        if (bulletPrefab.name == "Bullet")
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (bulletPrefab.name == "Bullet2")
        {
            var bullet2Pos = Quaternion.Euler(0f, 0f, -15f) * firePoint.position;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, bullet2Pos, firePoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if (bulletPrefab.name == "Bullet3")
        {
            var bullet2Pos = Quaternion.Euler(0f, 0f, -15f) * firePoint.position;
            var bullet3Pos = Quaternion.Euler(0f, 0f, 15f) * firePoint.position;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, bullet2Pos, firePoint.rotation);
            GameObject bullet3 = Instantiate(bulletPrefab, bullet3Pos, firePoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            rb3.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    private Vector3 GetRotatedVectorFromAngle(float angle)
    {
        var x = 1 * Mathf.Cos(angle * Mathf.Deg2Rad);
        var y = 1 * Mathf.Sin(angle * Mathf.Deg2Rad);
        var newPosition = firePoint.position;
        newPosition.x += x;
        newPosition.y += y;
        return newPosition;
    }
}
