using KrillAudio.Krilloud;
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

    public static KLAudioSource AudioSource;

    public bool Joining = true;
    public bool GameEnd;

    public int PlayerCount = 0;


    int DeadPlayers = 0;


    private void Awake()
    {
        Instance = this;
        AudioSource = GetComponent<KLAudioSource>();
    }

    private void Start()
    {
        Game.AudioSource.SetIntVar("musicvar", 1);
        Game.AudioSource.Play("music");

        Game.AudioSource.Play("ambiente");
    }

    void Update()
    {

    }

    public int OnPlayerJoined(Player _player)
    {
        PlayerCount++;
        Debug.Log("Player " + PlayerCount + " Joined");
        return PlayerCount;

        Game.AudioSource.SetIntVar("uivar", 0);
        Game.AudioSource.Play("ui");
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
