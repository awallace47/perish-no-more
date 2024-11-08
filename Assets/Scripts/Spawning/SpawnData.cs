

using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObject/ButtonSpawnRandomizer", order = 1)]
public class SpawnData : ScriptableObject
{
    public Vector3[] enemyPositions;
    public GameObject[] enemyPrefabs;
}
