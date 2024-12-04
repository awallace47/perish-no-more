using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    // Start is called before the first frame update
    void Start()
    {
        IsAttacking = true;
    }

    protected override void HandleAttackHit(GameObject gameObject)
    {
        base.HandleAttackHit(gameObject);
        isHitting = false;
    }
}
