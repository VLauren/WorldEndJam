//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 movementDirection;

    void Start()
    {

    }

    void Update()
    {
        transform.position += movementDirection * Time.deltaTime;
    }
}