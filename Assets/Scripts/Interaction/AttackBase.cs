using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Animator animator;
    protected List<GameObject> currentHitObjs = new();
    public bool IsAttacking { get; private set; }

    private void Start()
    {
        
    }

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
        if (IsAttacking) return;
        animator?.SetTrigger("Attack");
        IsAttacking = true;
    }
}
