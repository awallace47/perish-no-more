using UnityEngine;

public class PlayerAttack : AttackBase
{
    private StatusManager statusManager;

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

    protected override void HandleAttackHit(GameObject gameObject)
    {
        Destroy(gameObject);
        statusManager.AddScore(10.0f);
    }
}
