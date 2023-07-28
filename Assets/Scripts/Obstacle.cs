//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 movementDirection;

    public Vector3 impulse;

    void Start()
    {

    }

    void Update()
    {
        transform.position += movementDirection * Time.deltaTime;


    }

    private void OnTriggerEnter(Collider other)
    {
        print("ES BLEYBLAAAADEEEEE");

        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().AddImpulse(impulse);
        }

    }
}