using System;
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
    public AudioClip level1Music;
    public AudioClip endOfLevel;

    //Creates an audiomanager instance and and audiosurce
    public static MusicPlayer instance;
    private AudioSource source;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this);
        }
        else
        {
            //Destroy(this);
            //return;
        }

        source = gameObject.GetComponent<AudioSource>();
    }

    public void MainMenuBGM()
    {
        if(source != null) 
        { 
            if(source.clip != mainMenuMusic)
            {
                source.Stop();
                source.clip = mainMenuMusic;
                source.Play();
            }
        }
    }

    public void LevelOneBGM()
    {
        if (source != null)
        {
            if (source.clip != level1Music)
            {
                source.Stop();
                source.clip = level1Music;
                source.Play();
            }
        }
    }

    public void EndOfLevelBGM()
    {
        if (source != null)
        {
            if (source.clip != endOfLevel)
            {
                source.Stop();
                source.clip = endOfLevel;
                source.Play();
            }
        }
    }
}
