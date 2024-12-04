using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float attackSpawnTime;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(LaunchProjectile());
    }

    public IEnumerator LaunchProjectile()
    {
        while (true)
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = transform.position;
            StartCoroutine(MoveProjectile(player.transform.position, newProjectile));
            yield return new WaitForSeconds(attackSpawnTime);
        }
    }

    private IEnumerator MoveProjectile(Vector3 playerPos, GameObject currentProjectile)
    {
        Vector3 projectilePos = currentProjectile.transform.position;
        Vector3 direction = playerPos - projectilePos;
        Vector3 endDir = direction * 2.0f;

        float distSqr = Vector3.SqrMagnitude(endDir);
        Vector3 directionNorm = endDir.normalized;
        Rigidbody2D rb = currentProjectile.GetComponent<Rigidbody2D>();

        Destroy(currentProjectile, 3);
        while (distSqr >= 0.1f)
        {
            if (rb == null) {break;};
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, 0) + directionNorm * 0.1f );
            projectilePos = currentProjectile.transform.position;
            distSqr = Vector3.SqrMagnitude(endDir - projectilePos);
            yield return null;
        }


    }
}
