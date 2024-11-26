using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomButtonSpawnRandomizer : MonoBehaviour
{
    public BossRoomSpawnData spawnData;
    private List<Vector3> buttonPositions;
    public List<Vector3> bossProjectiles;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnData == null) return;

        SpawnButtons();
        SpawnBoss();
    }

    private void SpawnBoss()
    {
        GameObject boss = Instantiate(spawnData.bossPrefab);
        boss.transform.position = spawnData.bossPosition;
        BossProjectile bossProjectile = boss.GetComponent<BossProjectile>();
        bossProjectile.button1 = bossProjectiles[0];
        bossProjectile.button2 = bossProjectiles[1];
        bossProjectile.button3 = bossProjectiles[2];
        
    }

    private void SpawnButtons()
    {
        buttonPositions = new List<Vector3>(spawnData.bossRoomButtonPositions);
        bossProjectiles = new();
        
        while (true)
        {
            int buttonIndex = Random.Range(0, buttonPositions.Count);

            GameObject button = Instantiate(spawnData.BossButtonPrefab);
            button.transform.position = buttonPositions[buttonIndex];
            bossProjectiles.Add(buttonPositions[buttonIndex]);

            buttonPositions.RemoveAt(buttonIndex);
            if (buttonPositions.Count == 3) break;
        }

        return;
    }
}
