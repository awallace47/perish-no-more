using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackBase
{
    public AudioSource hit1;

    protected override void HandleAttackHit(GameObject gameObject)
    {
        base.HandleAttackHit(gameObject);

        PlayerStatusManager playerStatusManager = gameObject.GetComponent<PlayerStatusManager>();

        if (playerStatusManager != null)
        {
            playerStatusManager.SubtractHealth(damage);
            hit1.Play();

        }
    }
}
