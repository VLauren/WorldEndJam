using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        print(value.Get<Vector2>());
    }
}
