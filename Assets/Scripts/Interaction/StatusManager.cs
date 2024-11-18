using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public int health = 100;
    public SpriteRenderer spriteRenderer;
    public float deathAnimScale = 0.85f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleOnCollisionEnter2D(collision);
    }

    protected virtual void HandleOnCollisionEnter2D(Collision2D collision) { }


    protected IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    protected virtual IEnumerator Die()
    {
        Vector3 startScale = gameObject.transform.localScale;
        float startYScale = startScale.y;
        float currentYScale = startYScale;

        while (currentYScale >= 0.01)
        {
            currentYScale *= deathAnimScale;
            gameObject.transform.localScale = new Vector3(startScale.x, currentYScale, startScale.z);
            yield return null;
        }
    }
}
