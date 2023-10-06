using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    //These clips each hold one sound effect that can be called via a function.
    public AudioClip mainMenuMusic;
    public AudioClip westernMusic;

    //Creates an audiomanager instance and and audiosurce
    private static MusicPlayer instance;
    private AudioSource source;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }

        source = gameObject.GetComponent<AudioSource>();
    }

    //This function loads in a different music track if it finds an object in the scene with one of the music tags. Each level will have a music tag that this function will use to determine which music to play.
    public void MusicChange(int selection)
    {
        source = gameObject.GetComponent<AudioSource>();

        switch(selection)
        {
            case 0:
                instance.source.Stop();
                instance.source.clip = instance.mainMenuMusic;
                instance.source.Play();
            break;
            case 1:
                instance.source.Stop();
                instance.source.clip = instance.westernMusic;
                instance.source.Play();
            break;
        }
    }
}
