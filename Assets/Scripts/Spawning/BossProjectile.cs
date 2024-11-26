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
        Rigidbody2D rb = currentProjectile.GetComponent<Rigidbody2D>();

        while (projectilePos != button)
        {
            rb.MovePosition(direction * 0.01f);
            yield return null;
        }

        Debug.Log("EXIT");
    }
}
