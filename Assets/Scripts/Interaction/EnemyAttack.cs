using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackBase
{
    public AudioSource hit1;
    private PlayerStatusManager playerStatusManager;
    private void Start()
    {
        playerStatusManager = GameObject.Find("Player").GetComponent<PlayerStatusManager>();
    }

    protected override void HandleAttackHit(GameObject gameObject)
    {
        base.HandleAttackHit(gameObject);

        if (playerStatusManager != null)
        {
            playerStatusManager.SubtractHealth(damage);
            hit1.Play();

        }
    }
}
