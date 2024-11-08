

using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObject/ButtonSpawnRandomizer", order = 1)]
public class SpawnData : ScriptableObject
{
    public Vector3[] enemyPositions;
    public GameObject[] enemyPrefabs;
    public GameObject buttonPrefab;

    [Space, Header("Zone 1")]
    public Vector3[] zone1ButtonPositions;

    [Space, Header("Zone 2")]
    public Vector3[] zone2ButtonPositions;

    [Space, Header("Zone 3")]
    public Vector3[] zone3ButtonPositions;
}
