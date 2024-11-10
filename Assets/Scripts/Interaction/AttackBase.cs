using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    protected List<GameObject> currentHitObjs = new();
    public bool IsAttacking { get; private set; }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsHit(collider))
        {
            HandleAttackHit(collider.gameObject);
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        if (IsHit(collider) && !currentHitObjs.Contains(collider.gameObject))
        {
            currentHitObjs.Add(collider.gameObject);
            HandleAttackHit(collider.gameObject);
        }
    }

    protected bool IsHit(Collider2D collider)
    {
        return IsAttacking && (enemyLayers & (1 << collider.gameObject.layer)) != 0;
    }

    protected virtual void HandleAttackHit(GameObject gameObject) { }

    void AttackAnimCompleted(AnimationEvent evt)
    {
        IsAttacking = false;
        currentHitObjs.Clear();
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
        IsAttacking = true;
    }
}
