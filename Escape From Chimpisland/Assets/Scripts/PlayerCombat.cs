using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform attackPointLeft;
    public Transform attackPointRight;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 1f;
    float attackDelayTime = 0f;
    float keyPressed = 0f;
    

    // Update is called once per frame
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyPressed = 1;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyPressed = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(Time.time >= attackDelayTime)
            {

               Attack();
               attackDelayTime = Time.time + 1f / attackRate;

            }
            
        }
    }
    void Attack()
    {
        // MANGLER ANIMATION
        FindObjectOfType<AudioManager>().Play("FastSwordSwing");

        if (keyPressed == 1)
        {
            Collider2D[] hitEnemyRight = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);


            foreach (Collider2D Enemy in hitEnemyRight)
            {
                Destroy(Enemy.gameObject);
            }


        }

        if (keyPressed == 2)
        {

            Collider2D[] hitEnemyLeft = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);


            foreach (Collider2D Enemy in hitEnemyLeft)
            {
                Destroy(Enemy.gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (keyPressed == 2)
        {
            if (attackPointLeft == null)
            {
                return;
            }


            Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
        }

        if (keyPressed == 1)
        {
            if (attackPointRight == null)
            {
                return;
            }

            Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        }
    }
}
