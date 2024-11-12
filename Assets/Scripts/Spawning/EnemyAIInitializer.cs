using Pathfinding;
using UnityEngine;

public class EnemyAIInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GetComponent<AIDestinationSetter>().target = player.transform;
    }
}
