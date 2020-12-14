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
        Hurt2,
        Hurt3,
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
            // Normal Phase
            case Phase.Normal:
                if (healthController.GetHealthAsPercent() < 75)
                {
                    _phase = Phase.Hurt;
                    _attackType = AttackType.Charge;
                    shootMechanic.StartShooting(0f, 3f);
                    break;
                }

                if (!_isCharging)
                    transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                else
                    ChargeAttack();
                break;
            
            // Hurt Phase
            case Phase.Hurt:
                if (healthController.GetHealthAsPercent() < 60)
                    _phase = Phase.Hurt2;

                if (!_isCharging)
                    transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                else
                    ChargeAttack();
                break;
            case Phase.Hurt2:
                if (healthController.GetHealthAsPercent() < 35)
                    _phase = Phase.Hurt3;

                if (!_isCharging)
                    transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                else
                    ChargeAttack();
                break;
            case Phase.Hurt3:
                if (healthController.GetHealthAsPercent() < 10)
                {
                    _phase = Phase.Rage;
                    shootMechanic.ResetShooting(0f, 0.3f);
                    break;
                }

                if (!_isCharging)
                    transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                else
                    ChargeAttack();
                break;
            
            // Rage Phase
            case Phase.Rage:
                if (!_isCharging)
                    transform.position = Vector2.MoveTowards(transform.position, _player.position, moveSpeed * Time.deltaTime);
                else
                    ChargeAttack();
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
                if (healthController.GetHealthAsPercent() > 90)
                {
                    if (rand <= 0.2)
                        _isCharging = true;
                }
                else if (healthController.health <= 90 && healthController.GetHealthAsPercent() > 80)
                {
                    if (rand <= 0.45)
                        _isCharging = true;
                }
                else if (healthController.GetHealthAsPercent() < 80)
                {
                    if (rand <= 0.6)
                        _isCharging = true;
                }
                return;
            case AttackType.Homing:
                return;
        }
        _isCharging = false;
    }
}
