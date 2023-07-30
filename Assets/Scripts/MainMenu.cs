using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GameObject HowToPlay;

    void Start()
    {
        HowToPlay = transform.Find("HowToPlay").gameObject;
        HowToPlay.SetActive(false);
    }

    void Update()
    {

    }

    void OnMenuStart(InputValue value)
    {
        HowToPlay.SetActive(true);

        if (HowToPlay.activeSelf)
        {

            SceneManager.LoadScene("GameScene");
        }
    }
}
