using UnityEngine;

public class SpawnRandomizer : MonoBehaviour
{
    public SpawnData spawnData;
    public GameObject zone1Gate;
    public GameObject zone2Gate;

    void Start()
    {
        if (spawnData == null) return;

        SpawnEnemies();
        SpawnButtons();
    }


    private void SpawnEnemies()
    {
        int enemyRange = spawnData.enemyPrefabs.Length;

        foreach (Vector3 point in spawnData.enemyPositions)
        {
            int enemyType = Random.Range(0, enemyRange);
            GameObject newEnemy = Instantiate(spawnData.enemyPrefabs[enemyType]);
            newEnemy.transform.position = point;
        }
    }

    private void SpawnButtons()
    {
        int zone1Range = spawnData.zone1ButtonPositions.Length;
        int zone2Range = spawnData.zone2ButtonPositions.Length;
        int zone3Range = spawnData.zone3ButtonPositions.Length;

        Vector3 zone1Position = spawnData.zone1ButtonPositions[Random.Range(0, zone1Range)];
        Vector3 zone2Position = spawnData.zone2ButtonPositions[Random.Range(0, zone2Range)];
        Vector3 zone3Position = spawnData.zone3ButtonPositions[Random.Range(0, zone3Range)];

        GameObject zone1Button = Instantiate(spawnData.buttonPrefab);
        zone1Button.transform.position = zone1Position;
        zone1Button.GetComponent<ButtonInteraction>().gate = zone1Gate;

        GameObject zone2Button = Instantiate(spawnData.buttonPrefab);
        zone2Button.transform.position = zone2Position;
        zone2Button.GetComponent<ButtonInteraction>().gate = zone2Gate;

        GameObject zone3Button = Instantiate(spawnData.buttonPrefab);
        zone3Button.transform.position = zone3Position;
    }
}
