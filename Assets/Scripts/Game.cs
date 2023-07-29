using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public const float BoatCollisionPush = 10;
    public const float BoatCollisionScaledPush = 3;
    public const int BoatCollisionDamage = 1;

    public bool Joining = true;
    public bool GameEnd;

    public int PlayerCount = 0;

    int DeadPlayers = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }

    void Update()
    {

    }

    public int OnPlayerJoined(Player _player)
    {
        PlayerCount++;
        Debug.Log("Player " + PlayerCount + " Joined");
        return PlayerCount;
    }

    public void StartPressed()
    {
        if (Joining)
            Joining = false;
    }

    public void PlayerDead(int _playerNumber)
    {
        print("Player " + _playerNumber + " is out!");
        DeadPlayers++;

        if (DeadPlayers >= PlayerCount - 1)
            StartCoroutine(GameEndRoutine());
    }

    IEnumerator GameEndRoutine()
    {
        GameEnd = true;
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);
    }

}
