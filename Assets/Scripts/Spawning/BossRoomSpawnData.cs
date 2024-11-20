using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossRoomSpawnData", menuName = "ScriptableObject/BossRoomSpawnData", order = 1)]
public class BossRoomSpawnData : ScriptableObject
{
    public Vector3 bossPosition;
    public GameObject bossPrefab;
    public GameObject BossButtonPrefab;

    [Space, Header("Boss Room")]
    public List<Vector3> bossRoomButtonPositions;
}
