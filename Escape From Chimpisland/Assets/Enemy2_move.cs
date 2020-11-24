using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_move : StateMachineBehaviour
{

    public float speed = 2f;
    public float startAttacking = 1f;
    public float stopMove = 5f;
    private Transform target;

    Transform player;
    Rigidbody2D rb;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (Vector2.Distance(rb.position, player.position) > stopMove )
        {
            animator.SetTrigger("stopMove");
        }


        if (Vector2.Distance(rb.position, player.position) <= startAttacking)
        {
            animator.SetTrigger("Attack");
        }
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("stopAttacking");
        animator.ResetTrigger("stopMove");
    }

  
}
