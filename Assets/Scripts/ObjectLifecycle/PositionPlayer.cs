using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer : MonoBehaviour
{
    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
