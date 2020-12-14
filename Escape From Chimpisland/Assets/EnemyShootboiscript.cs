using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootboiscript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float speed;

    private Transform _target;
    private SpawnRoom _spawnRoom;
    private bool _shooting;

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _spawnRoom = GetComponent<SpawnRoom>();
        _shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIfPlayerInRoom() && !_shooting)
            StartShooting(1f, speed);

        else if (!CheckIfPlayerInRoom() && _shooting)
            StopShooting();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void StartShooting(float beginIn, float repeatInterval)
    {
        InvokeRepeating("Shoot", beginIn, repeatInterval);
        _shooting = true;
    }

    public void StopShooting()
    {
        CancelInvoke("Shoot");
        _shooting = false;
    }

    public void ResetShooting(float beginIn, float repeatInterval)
    {
        StopShooting();
        StartShooting(beginIn, repeatInterval);

    }

    private bool CheckIfPlayerInRoom()
    {
        if (_target.position.x > _spawnRoom.spawnRoomPos.x - 11f &&
            _target.position.x < _spawnRoom.spawnRoomPos.x + 11f &&
            _target.position.y > _spawnRoom.spawnRoomPos.y - 5f &&
            _target.position.y < _spawnRoom.spawnRoomPos.y + 5f)
            return true;
        else
            return false;
    }
}
