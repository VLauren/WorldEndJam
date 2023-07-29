//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 movementDirection;
    public Vector3 impulse;
    public Vector3 scaledImpulse;
    public int Damage;

    void Update()
    {
        transform.position += movementDirection * Time.deltaTime;

        if(transform.position.x > 25)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 5);
            transform.position += new Vector3(0, -6 * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().ApplyDamage(Damage);
            other.GetComponent<Player>().AddImpulse(impulse);
            other.GetComponent<Player>().AddScaledImpulse(scaledImpulse);
        }
    }
}