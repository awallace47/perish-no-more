using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    private EnemyStatusManager enemyStatusManager; 
    public LayerMask enemyLayers; 
    public int damage = 20; 

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
        enemyStatusManager = gameObject.GetComponent<EnemyStatusManager>();
        if (enemyStatusManager != null)
        {
            enemyStatusManager.Hit(damage);
        }
        Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
