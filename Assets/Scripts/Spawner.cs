using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Prefabs;

    public float ObstacleSpawnRate = 0.3f;

    bool Started;

    void Update()
    {
        if(!Started && !Game.Instance.Joining)
        {
            Started = true;
            InvokeRepeating("SpawnObstacle", 2, 1f / ObstacleSpawnRate);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.color = new Color(0.0f, 0.75f, 0.0f, 0.75f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.75f);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }

    void SpawnObstacle()
    {
        float RandomX = Random.Range((transform.localScale.x * -1) / 2, transform.localScale.x / 2);

        float RandomZ = Random.Range((transform.localScale.z * -1) / 2, transform.localScale.z / 2);

        Instantiate(Prefabs[Random.Range(0, Prefabs.Count)], transform.position + new Vector3(RandomX, 0, RandomZ), Quaternion.identity);
    }
}
