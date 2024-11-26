using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Vector3 button1;
    public Vector3 button2;
    public Vector3 button3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            LaunchProjectile(button1);
        }
    }

    public void LaunchProjectile(Vector3 button)
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.transform.position = transform.position;
        StartCoroutine(MoveProjectile(button, newProjectile));
    }

    private IEnumerator MoveProjectile(Vector3 button, GameObject currentProjectile)
    {
        Vector3 projectilePos = currentProjectile.transform.position;
        Vector3 direction = button - projectilePos;
        float distSqr = Vector3.SqrMagnitude(direction);
        Vector3 directionNorm = direction.normalized;
        Rigidbody2D rb = currentProjectile.GetComponent<Rigidbody2D>();

        while (distSqr >= 0.01f)
        {
            rb.MovePosition(new Vector3(rb.position.x, rb.position.y, 0) + directionNorm * 0.1f );
            projectilePos = currentProjectile.transform.position;
            direction = button - projectilePos;
            distSqr = Vector3.SqrMagnitude(direction);
            yield return null;
        }
        Destroy(currentProjectile);
    }
}
