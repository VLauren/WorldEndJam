//using System.Reflection.Metadata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIDanger : MonoBehaviour
{
    public List<Player> PlayerArray;

    GameObject[] UIArray = new GameObject[4];

    public Slider sliderPlayer1;

    public Slider sliderPlayer2;

    public Slider sliderPlayer3;

    public Slider sliderPlayer4;

    public GameObject PressToJoin;

    public GameObject PressToStart;

    public int PlayerNumber;

    public GameObject Winner;
    void Start()
    {
        UIArray[0] = GameObject.Find("J1");
        UIArray[0].SetActive(false);
        sliderPlayer1 = UIArray[0].transform.GetChild(0).GetComponent<Slider>();

        UIArray[1] = GameObject.Find("J2");
        UIArray[1].SetActive(false);
        sliderPlayer2 = UIArray[1].transform.GetChild(0).GetComponent<Slider>();

        UIArray[2] = GameObject.Find("J3");
        UIArray[2].SetActive(false);
        sliderPlayer3 = UIArray[2].transform.GetChild(0).GetComponent<Slider>();

        UIArray[3] = GameObject.Find("J4");
        UIArray[3].SetActive(false);
        sliderPlayer4 = UIArray[3].transform.GetChild(0).GetComponent<Slider>();

        PlayerArray = new List<Player>();

        PressToJoin = transform.Find("Join").gameObject;
        PressToJoin.SetActive(false);
        PressToStart = transform.Find("Start").gameObject;
        PressToStart.SetActive(false);
        Winner = transform.Find("Winner").gameObject;
        Winner.SetActive(false);
    }

    void Update()
    {
        if (Game.Instance.Joining)
        {
            foreach (var player in FindObjectsOfType<Player>())
                if (!PlayerArray.Contains(player))
                    PlayerArray.Add(player);

            PressToJoin.SetActive(true);

            transform.Find("Join/Player1").gameObject.SetActive(PlayerArray.Count < 1);
            transform.Find("Join/Player2").gameObject.SetActive(PlayerArray.Count < 2);
            transform.Find("Join/Player3").gameObject.SetActive(PlayerArray.Count < 3);
            transform.Find("Join/Player4").gameObject.SetActive(PlayerArray.Count < 4);
        }

        if (!Game.Instance.Joining)
        {
            PressToJoin.SetActive(false);
            PressToStart.SetActive(false);
        }

        if (Game.Instance.GameEnd)
        {
            Winner.SetActive(true);
        }
        else
        {
            Winner.SetActive(false);
        }

        if (PlayerArray.Count >= 1)
        {
            UIArray[0].SetActive(true);
            sliderPlayer1.value = PlayerArray[0].ReceivedDamage;

            if (PressToJoin.activeSelf)
            {
                PressToStart.SetActive(true);
            }
        }

        if (PlayerArray.Count >= 2)
        {
            UIArray[1].SetActive(true);
            sliderPlayer2.value = PlayerArray[1].ReceivedDamage;
        }

        if (PlayerArray.Count >= 3)
        {
            UIArray[2].SetActive(true);
            sliderPlayer3.value = PlayerArray[2].ReceivedDamage;
        }

        if (PlayerArray.Count >= 4)
        {
            UIArray[3].SetActive(true);
            sliderPlayer4.value = PlayerArray[3].ReceivedDamage;

            PressToJoin.SetActive(false);
        }

        foreach (Player player in PlayerArray)
        {
            if (player.Winner == true)
            {
                PlayerNumber = player.PlayerNumber;
                transform.Find("Winner/VictoryText").GetComponent<Text>().text = "Player " + PlayerNumber + " Wins!";
            }
        }
    }
}
