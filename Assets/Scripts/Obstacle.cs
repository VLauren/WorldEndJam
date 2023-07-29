//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 movementDirection;
    public Vector3 impulse;
    public int Damage;

    void Start()
    {

    }

    void Update()
    {
        transform.position += movementDirection * Time.deltaTime;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().ApplyDamage(Damage);

            other.GetComponent<Player>().AddImpulse(impulse);

            other.GetComponent<Player>().AddScaledImpulse(impulse);
        }

    }
}