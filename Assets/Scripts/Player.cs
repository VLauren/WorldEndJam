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
        print(gameObject.name + " " + InputDir);
        // if (InputDir != Vector2.zero && Velocity.magnitude <= MaxSpeed)
        // Velocity = Vector3.MoveTowards(Velocity, new Vector3(InputDir.x, 0, InputDir.y) * MaxSpeed, Time.deltaTime * Acceleration);

        if (InputDir == Vector2.zero)
            Velocity = Vector3.MoveTowards(Velocity, Vector2.zero, Time.deltaTime * Deceleration);
        else
            Velocity = Vector3.MoveTowards(Velocity, MaxSpeed * new Vector3(InputDir.x, 0, InputDir.y), Time.deltaTime * Acceleration);
        print("?? " + (MaxSpeed * new Vector3(InputDir.x, 0, InputDir.y)) + " v:" + Velocity + " delta:" + Time.deltaTime * Acceleration + " res:" + Vector2.MoveTowards(Velocity, MaxSpeed * new Vector3(InputDir.x, 0, InputDir.y), Time.deltaTime * Acceleration));

        /*
        else
        {
            if (InputDir.x != 0)
                Velocity.x = Mathf.MoveTowards(Velocity.x, MaxSpeed * InputDir.x, Time.deltaTime * Acceleration);
            if (InputDir.y != 0)
                Velocity.z = Mathf.MoveTowards(Velocity.z, MaxSpeed * InputDir.y, Time.deltaTime * Acceleration);

            if ((InputDir.x == 0 && InputDir.y != 0))// || Velocity.x > MaxSpeed)
                Velocity.x = Mathf.MoveTowards(Velocity.x, 0, Time.deltaTime * Deceleration);
            if ((InputDir.y == 0 && InputDir.x != 0))// || Velocity.z > MaxSpeed)
                Velocity.z = Mathf.MoveTowards(Velocity.z, 0, Time.deltaTime * Deceleration);
        }
        */

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
