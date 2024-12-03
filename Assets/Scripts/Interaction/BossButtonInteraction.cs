using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButtonInteraction : ButtonInteraction
{
    public GameObject fireballPrefab;
    private GameObject boss;

    private void Start()
    {
        boss = GameObject.Find("Boss");
    }
    public override void Interact()
    {
        base.Interact();

        StartCoroutine(LaunchFireball());
    }

    private IEnumerator LaunchFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab);
        fireball.transform.position = transform.position;
        Vector3 projectilePos = fireball.transform.position;
        Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
        Vector3 direction = boss.transform.position - projectilePos;
        float distSqr = Vector3.SqrMagnitude(direction);
        Vector3 directionNorm = direction.normalized;

        while (distSqr >= 0.01f)
        {
            fireballRb.MoveRotation(fireballRb.rotation + 10f);
            fireballRb.MovePosition(new Vector3(fireballRb.position.x, fireballRb.position.y, 0) + directionNorm * 0.1f);
            projectilePos = fireball.transform.position;
            direction = boss.transform.position - projectilePos;
            directionNorm = direction.normalized;
            distSqr = Vector3.SqrMagnitude(direction);
            yield return null;
        }
        Destroy(fireball);
    }
}
