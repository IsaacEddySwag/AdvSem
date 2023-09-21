using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class S_MusicPlayer : MonoBehaviour
{
    //These clips each hold one sound effect that can be called via a function.
    public AudioClip mainMenuMusic;
    public AudioClip level1Music;
    public AudioClip selectMusic;
    public AudioClip victoryMusic;
    public AudioClip gameOverMusic;
    public AudioClip frogSelectMusic;
    public AudioClip level2Music;
    public AudioClip level3Music;


    //Creates an audiomanager instance and and audiosurce
    private static S_MusicPlayer instance;
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

        SceneManager.sceneLoaded += OnSceneLoaded;

        source = GameObject.Find("MusicManager").GetComponent<AudioSource>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        MusicChange();
    }

    //This function loads in a different music track if it finds an object in the scene with one of the music tags. Each level will have a music tag that this function will use to determine which music to play.
    public void MusicChange()
    {
        source = GameObject.Find("MusicManager").GetComponent<AudioSource>();

        if (GameObject.FindWithTag("MainMenuMusic"))
        {
            if (source.clip != mainMenuMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.mainMenuMusic;
                instance.source.Play();
            }
        }
        else if (GameObject.FindWithTag("Level1Music"))
        {
            if (source.clip != level1Music)
            {
                instance.source.Stop();
                instance.source.clip = instance.level1Music;
                instance.source.Play();
            }
        }
        else if (GameObject.FindWithTag("SelectMusic"))
        {
            if (source.clip != selectMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.selectMusic;
                instance.source.Play();
            }
        }
        else if (GameObject.FindWithTag("WinMusic"))
        {
            if (source.clip != victoryMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.victoryMusic;
                instance.source.Play();
            }
        }
        else if (GameObject.FindWithTag("GameoverMusic"))
        {
            if (source.clip != gameOverMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.gameOverMusic;
                instance.source.Play();
            }
        }
        else if (GameObject.FindWithTag("FrogChooseMusic"))
        {
            if (source.clip != frogSelectMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.frogSelectMusic;
                instance.source.Play();
            }
        }
        else if (GameObject.FindWithTag("Level2Music"))
        {
            if (source.clip != level2Music)
            {
                instance.source.Stop();
                instance.source.clip = instance.level2Music;
                instance.source.Play();
            }
        }
        else if (GameObject.FindWithTag("Level3Music"))
        {
            if (source.clip != level3Music)
            {
                instance.source.Stop();
                instance.source.clip = instance.level3Music;
                instance.source.Play();
            }
        }
    }
}
