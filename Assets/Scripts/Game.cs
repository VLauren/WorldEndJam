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
        Game.AudioSource.SetIntVar("musicvar", 0);
        Game.AudioSource.Play("music");

        Game.AudioSource.Play("ambiente");
    }

    void Update()
    {

    }

    public int OnPlayerJoined(Player _player)
    {
        Game.AudioSource.SetIntVar("ui_krillvar", 0);
        Game.AudioSource.Play("ui_krill");

        PlayerCount++;
        Debug.Log("Player " + PlayerCount + " Joined");
        return PlayerCount;
    }

    public void StartPressed()
    {
        if (Joining)
        {
            Joining = false;
            Game.AudioSource.StopTag("music");
            StartCoroutine(PlayGameMusic());
        }
    }

    IEnumerator PlayGameMusic()
    {
        yield return null;
        Game.AudioSource.SetIntVar("musicvar", 1);
        Game.AudioSource.Play("music");
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

        SceneManager.LoadScene("GameScene");
    }

}
