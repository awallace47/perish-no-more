using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileHit : MonoBehaviour
{
    public int damage = 10;
    public LayerMask enemyLayers;
    private PlayerStatusManager playerStatusManager;

    void Start()
    {
        playerStatusManager = GameObject.Find("Player").GetComponent<PlayerStatusManager>();
    }
   
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsHit(collider))
        {
            HandleAttackHit(collider.gameObject);
        }
    }

    protected bool IsHit(Collider2D collider)
    {
        return (enemyLayers & 1 << collider.gameObject.layer) != 0;
    }

    protected void HandleAttackHit(GameObject gameObject)
    {
        if (playerStatusManager != null)
        {
            playerStatusManager.SubtractHealth(damage);
        }
        Destroy(this);
    }
}
