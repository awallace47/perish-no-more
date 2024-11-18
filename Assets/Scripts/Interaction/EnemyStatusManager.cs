
using System.Collections;

public class EnemyStatusManager : StatusManager
{

    public void Hit(int damage)
    {
        health -= damage;

        StartCoroutine(FlashRed());

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    protected override IEnumerator Die()
    {
        yield return base.Die();

        Destroy(gameObject);
    }
}
