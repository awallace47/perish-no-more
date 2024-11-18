using System.Collections;
using UnityEngine;

public class EnemyStatusManager : MonoBehaviour
{
    public int enemyHealth = 20;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int damage)
    {
        enemyHealth -= damage;

        StartCoroutine(FlashRed());

        if (enemyHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    private IEnumerator Die()
    {
        Vector3 startScale = gameObject.transform.localScale;
        float startYScale = startScale.y;
        float currentYScale = startYScale;

        while (currentYScale >= 0)
        {
            currentYScale *= 0.9f;
            gameObject.transform.localScale = new Vector3(startScale.x, currentYScale, startScale.z);
            yield return null;
        }

        Destroy(gameObject);
    }
}
