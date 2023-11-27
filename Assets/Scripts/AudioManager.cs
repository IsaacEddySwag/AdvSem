using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //These clips each hold one sound effect that can be called via a function.
    public AudioClip JingleComplete;

    //Creates an audiomanager instance and and audiosurce
    public AudioSource jingleSource;

    private static AudioManager instance;

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
    }

    //Each one of these is an individual sound effect player. When you call one of these functions you can play its respective sound effect.

    public void CompleteJingle()
    {
         if (instance.jingleSource != null)
         {
              instance.jingleSource.Stop();
              instance.jingleSource.clip = instance.JingleComplete;
              instance.jingleSource.Play();
         }
    }
}
