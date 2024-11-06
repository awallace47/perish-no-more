using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private StatusManager statusManager;

    public bool IsAttacking { get; private set; }

    private void Start()
    {
        statusManager = GetComponent<StatusManager>();
    }

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
        StartCoroutine(HitDetection());
    }

    void AttackAnimCompleted(AnimationEvent evt)
    {
        IsAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator HitDetection()
    {
        while (IsAttacking)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            HashSet<GameObject> hits = new();

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject != null)
                    hits.Add(enemy.gameObject);
                yield return null;
            }

            foreach (GameObject go in hits)
            {
                Destroy(go);
                statusManager.AddScore(10.0f);
                yield return null;
            }

            yield return null;
        }

    }
}
