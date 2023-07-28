//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2;

    Vector3 movementDirection = new Vector3();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
        };

        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Time.deltaTime * speed;

        transform.position += movementDirection * Time.deltaTime;

        if (transform.position.y < 3)
        {
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);

            movementDirection.y = 3;
        }
    }
}