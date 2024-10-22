using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public bool IsAttacking { get; private set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        IsAttacking = true;
    }

    void AttackAnimCompleted(AnimationEvent evt)
    {
        IsAttacking = false;
    }
}
