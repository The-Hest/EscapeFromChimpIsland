using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float moveSpeed;
    public float chargeSpeed;
    public float scoutMoveSpeed;
    public float chargeTime;
    public bool slowed;
    public BossShoot shootMechanic;
    public HealthController healthController;
    public DamageController damageController;

    private Transform _player;
    private Vector3 _targetPosition;
    private bool _isCharging;
    private float _chargeTimeRemaining;
    private enum Phase
    {
        Normal,
        Hurt,
        Rage,
    }
    private enum AttackType
    {
        Charge,
        Homing,
    }

    private Phase _phase;
    private AttackType _attackType;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _isCharging = false;
        _phase = Phase.Normal;
        _attackType = AttackType.Charge;
        _chargeTimeRemaining = chargeTime;

        InvokeRepeating("ShouldChargeAttack", 5f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_phase)
        {
            case Phase.Normal:
                if (healthController.health < 65)
                {
                    _phase = Phase.Hurt;
                    _attackType = AttackType.Homing;
                    shootMechanic.StartShooting(1f, 2f);
                }
                else
                {
                    if (!_isCharging)
                        transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                    else
                        ChargeAttack();
                }
                break;
            case Phase.Hurt:
                if (healthController.health < 25)
                {
                    _phase = Phase.Rage;
                    StopCoroutine("ShouldChargeAttack");
                    InvokeRepeating("ShouldChargeAttack", 0f, 1f);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);

                }
                break;
            case Phase.Rage:
                transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                break;
        }
    }

    private void ChargeAttack()
    {
        switch (_attackType)
        {
            case AttackType.Charge:
                if (_chargeTimeRemaining > 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _player.position, chargeSpeed * Time.deltaTime);
                    _chargeTimeRemaining -= Time.deltaTime;
                }
                else
                {
                    _isCharging = false;
                    _chargeTimeRemaining = chargeTime;
                }
                break;
            case AttackType.Homing:
                break;
        }


    }

    private void ShouldChargeAttack()
    {
        var rand = Random.value;
        print(rand);
        switch (_attackType)
        {
            case AttackType.Charge:
                if (healthController.health > 90)
                {
                    if (rand <= 0.2)
                        _isCharging = true;
                }
                else if (healthController.health <= 90 && healthController.health > 80)
                {
                    if (rand <= 0.5)
                        _isCharging = true;
                }
                else if (healthController.health <= 80 && healthController.health > 65)
                {
                    if (rand <= 0.9)
                        _isCharging = true;
                }
                return;
            case AttackType.Homing:
                return;
        }
        _isCharging = false;
    }
}
