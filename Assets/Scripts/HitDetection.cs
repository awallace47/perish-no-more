using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
}
