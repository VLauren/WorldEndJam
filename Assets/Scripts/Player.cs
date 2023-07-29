using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MaxSpeed;
    public float Acceleration;
    public float Deceleration;

    public int ReceivedDamage = 0;

    [Space()]
    public Vector2 XMovLimits;
    public Vector2 ZMovLimits;

    [Space()]
    public float DashCooldown = 1;
    public float DashTime = 0.2f;
    public float DashSpeed = 20;

    Vector3 Velocity;
    Vector2 InputDir;
    bool Dead, Winner;
    int PlayerNumber;

    float DashCDCounter;
    bool Dashing;

    void Awake()
    {
    }

    private void Start()
    {
        PlayerNumber = Game.Instance.OnPlayerJoined(this);
        transform.position = new Vector3(15 + PlayerNumber * 6, 2.85f, -27.55f);
        transform.rotation = Quaternion.Euler(0, 90, 0);

        transform.GetChild(PlayerNumber).gameObject.SetActive(true);
    }

    void Update()
    {
        // Si estoy iniciando la partida, no hago nada
        if (Game.Instance.Joining)
        {
            return;
        }

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

            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, XMovLimits.x, XMovLimits.y);
            pos.z = Mathf.Clamp(pos.z, ZMovLimits.x, ZMovLimits.y);
            transform.position = pos;

            if(Game.Instance.GameEnd && !Winner)
            {
                Winner = true;
                Debug.Log("PLAYER " + PlayerNumber + " WINS!!!");
            }

            if (transform.position.x > 47.5f)
            {
                Dead = true;
                Game.Instance.PlayerDead(PlayerNumber);
            }
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

    void OnStart(InputValue value)
    {
        Game.Instance.StartPressed();
    }


    void OnDash(InputValue value)
    {
        if(!Dead && !Game.Instance.Joining && DashCDCounter <= 0 && InputDir != Vector2.zero)
        {
            StartCoroutine(DashRoutine());
        }
    }

    IEnumerator DashRoutine()
    {
        DashCDCounter = DashCooldown;
        float dashTimeCount = 0;
        Vector3 dashDir = new Vector3(InputDir.x, 0, InputDir.y);

        while (DashCDCounter > 0)
        {
            DashCDCounter -= Time.deltaTime;
            dashTimeCount += Time.deltaTime;

            if (dashTimeCount < DashTime)
            {
                Dashing = true;
                transform.position += dashDir * DashSpeed * Time.deltaTime;
            }
            else
                Dashing = false;

            yield return null;
        }
    }

    public void ApplyDamage(int _damage)
    {
        ReceivedDamage += _damage;
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

            if(!other.GetComponent<Player>().Dashing)
            {
                other.GetComponent<Player>().AddImpulse(dir * Game.BoatCollisionPush);
                other.GetComponent<Player>().AddScaledImpulse(dir * Game.BoatCollisionScaledPush);
                other.GetComponent<Player>().ApplyDamage(Game.BoatCollisionDamage);
            }

            if (!Dashing)
            {
                AddImpulse(-dir * Game.BoatCollisionPush);
                AddScaledImpulse(-dir * Game.BoatCollisionScaledPush);
                ApplyDamage(Game.BoatCollisionDamage);
            }
        }
    }

    public void AddScaledImpulse(Vector3 _impulse)
    {
        Velocity = _impulse * ReceivedDamage;
    }
}
