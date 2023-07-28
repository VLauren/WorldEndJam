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
        if (InputDir == Vector2.zero)
            Velocity = Vector3.MoveTowards(Velocity, Vector2.zero, Time.deltaTime * Deceleration);
        else
            Velocity = Vector3.MoveTowards(Velocity, MaxSpeed * new Vector3(InputDir.x, 0, InputDir.y), Time.deltaTime * Acceleration);

        transform.position += Velocity * Time.deltaTime;

        // ================
        // DEBUG

        Keyboard kb = Keyboard.current;
        if (kb.qKey.wasPressedThisFrame)
        {
            AddImpulse(new Vector3(10, 0, 0));
        }
    }

    void OnMove(InputValue value)
    {
        InputDir = value.Get<Vector2>();
    }

    public void AddImpulse(Vector3 _impulse)
    {
        Velocity = _impulse;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Vector3 dir = other.transform.position - transform.position;
            dir.Normalize();

            other.GetComponent<Player>().AddImpulse(dir * 15);
            AddImpulse(-dir * 15);
        }
    }
}
