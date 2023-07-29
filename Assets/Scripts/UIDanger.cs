//using System.Reflection.Metadata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIDanger : MonoBehaviour
{
    Player[] PlayerArray = { };

    public bool NotInit = true;

    public Slider sliderDanger;

    GameObject[] UIArray = new GameObject[4];
    void Start()
    {
        UIArray[0] = GameObject.Find("J1");
        UIArray[0].SetActive(false);
        UIArray[1] = GameObject.Find("J2");
        UIArray[1].SetActive(false);
        UIArray[2] = GameObject.Find("J3");
        UIArray[2].SetActive(false);
        UIArray[3] = GameObject.Find("J4");
        UIArray[3].SetActive(false);

    }

    void Update()
    {
        if (Game.Instance.Joining)
        {
            NotInit = false;
            PlayerArray = FindObjectsOfType<Player>();

            print(PlayerArray.Length);
        }

        if (PlayerArray.Length >= 1)
        {
            UIArray[0].SetActive(true);
        }

        if (PlayerArray.Length == 2)
        {
            UIArray[1].SetActive(true);
        }

        if (PlayerArray.Length == 3)
        {
            UIArray[2].SetActive(true);
        }

        if (PlayerArray.Length == 4)
        {
            UIArray[3].SetActive(true);
        }
    }
}
