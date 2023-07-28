using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float MaxSpeed;
    public float Acceleration;
    public float Deceleration;

    Vector3 Velocity;

    Vector2 InputDir;

    void Start()
    {
    }

    void Update()
    {
        if (InputDir != Vector2.zero && Velocity.magnitude <= MaxSpeed)
            Velocity = Vector3.MoveTowards(Velocity, new Vector3(MaxSpeed * InputDir.x, 0, MaxSpeed * InputDir.y), Time.deltaTime * Acceleration);

        if (InputDir.x == 0)
            Velocity.x = Mathf.MoveTowards(Velocity.x, 0, Time.deltaTime * Deceleration);
        if (InputDir.y == 0)
            Velocity.z = Mathf.MoveTowards(Velocity.z, 0, Time.deltaTime * Deceleration);

        transform.position += Velocity * Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        InputDir = value.Get<Vector2>();
    }
}
