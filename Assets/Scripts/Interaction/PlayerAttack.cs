using UnityEngine;

public class PlayerAttack : AttackBase
{
    private StatusManager statusManager;
    public AudioSource hit1;


    private void Start()
    {
        playerStatusManager = GetComponent<PlayerStatusManager>();
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
            enemyStatusManager.Hit(damage);
            playerStatusManager.AddScore(10.0f);
        }

        hit1.Play();
    }
}
