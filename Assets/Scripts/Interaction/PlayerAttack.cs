using UnityEngine;

public class PlayerAttack : AttackBase
{
    private StatusManager playerStatusManager;

    private void Start()
    {
        playerStatusManager = GetComponent<StatusManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    protected override void HandleAttackHit(GameObject gameObject)
    {
        base.HandleAttackHit(gameObject);

        EnemyStatusManager enemyStatusManager = gameObject.GetComponent<EnemyStatusManager>();

        if (enemyStatusManager != null)
        {
            enemyStatusManager.Hit(10);
            playerStatusManager.AddScore(10.0f);
        }

        
    }
}
