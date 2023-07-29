using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Vector3 movementDirection;
    public Vector3 impulse;
    public Vector3 scaledImpulse;

    public int HealedDamage;

    public bool Immunity;

    // Update is called once per frame
    void Update()
    {
        transform.position += movementDirection * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Game.AudioSource.SetIntVar("ui_krillvar", 1);
            Game.AudioSource.Play("ui_krill");

            other.GetComponent<Player>().HealDamage(HealedDamage);
            Destroy(gameObject);
        }
    }
}
