using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomButtonSpawnRandomizer : MonoBehaviour
{
    public BossRoomSpawnData spawnData;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnData == null) return;

        SpawnBoss();
        SpawnButtons();
    }

    private void SpawnBoss()
    {
        GameObject boss = Instantiate(spawnData.bossPrefab);
        boss.transform.position = spawnData.bossPosition;
    }

    private void SpawnButtons()
    {

        while (true)
        {
            List<Vector3> buttonPositions = spawnData.bossRoomButtonPositions;

            int buttonIndex = Random.Range(0, buttonPositions.Count);

            GameObject button = Instantiate(spawnData.BossButtonPrefab);
            button.transform.position = buttonPositions[buttonIndex];

            buttonPositions.RemoveAt(buttonIndex);
            if (buttonPositions.Count == 3) break;
        }

        return;
    }
}
