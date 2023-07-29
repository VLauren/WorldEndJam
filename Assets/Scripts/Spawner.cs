using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.color = new Color(0.0f, 0.75f, 0.0f, 0.75f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.75f);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
