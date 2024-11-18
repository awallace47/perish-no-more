using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackBase
{
    protected override void HandleAttackHit(GameObject gameObject)
    {
        base.HandleAttackHit(gameObject);

        PlayerStatusManager playerStatusManager = gameObject.GetComponent<PlayerStatusManager>();

        if (playerStatusManager != null)
        {
            playerStatusManager.SubtractHealth(5);
        }
    }
}
