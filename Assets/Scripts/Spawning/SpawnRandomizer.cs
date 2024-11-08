using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomizer : MonoBehaviour
{
    public SpawnData spawnData;

    void Start()
    {
        if (spawnData == null) return;

        int enemyRange = spawnData.enemyPrefabs.Length;

        foreach (Vector3 point in spawnData.enemyPositions)
        {
            int enemyType = Random.Range(0, enemyRange);
            GameObject newEnemy = Instantiate(spawnData.enemyPrefabs[enemyType]);
            newEnemy.transform.position = point;
        }
    }


    private void SpawnEnemies()
    {

    }

    private void SpawnButtons()
    {

    }
}
