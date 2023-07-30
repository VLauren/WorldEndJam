using KrillAudio.Krilloud;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    void Start()
    {
        KLAudioSource klas = GetComponent<KLAudioSource>();
        // klas.SetIntVar("musicvar", 0);
        // klas.Play("music");
    }

    void BeepSound()
    {
        Game.AudioSource.SetIntVar("ui_krillvar", 0);
        Game.AudioSource.Play("ui_krill");
    }
}
