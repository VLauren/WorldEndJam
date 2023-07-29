using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float MaxSpeed;
    public float Acceleration;
    public float Deceleration;

    [Space()]
    public Vector2 XMovLimits;
    public Vector2 ZMovLimits;

    Vector3 Velocity;

    Vector2 InputDir;

    bool Dead;

    void Start()
    {
    }

    void Update()
    {
        if (Dead)
        {
            Velocity = Vector3.MoveTowards(Velocity, new Vector3(0, -100, 0), Time.deltaTime * Deceleration);
        }
        else
        {
            if (InputDir == Vector2.zero)
                Velocity = Vector3.MoveTowards(Velocity, Vector2.zero, Time.deltaTime * Deceleration);
            else
                Velocity = Vector3.MoveTowards(Velocity, MaxSpeed * new Vector3(InputDir.x, 0, InputDir.y), Time.deltaTime * Acceleration);

            if (transform.position.x > 44)
                Dead = true;

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, XMovLimits.x, XMovLimits.y);
            pos.z = Mathf.Clamp(pos.z, ZMovLimits.x, ZMovLimits.y);
            transform.position = pos;
        }

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

    public void ApplyDamage(int _damage)
    {

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

            other.GetComponent<Player>().AddImpulse(dir * Game.BoatCollisionPush);
            AddImpulse(-dir * Game.BoatCollisionPush);
        }
    }
}
