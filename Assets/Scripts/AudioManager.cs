using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //These clips each hold one sound effect that can be called via a function.
    [SerializeField] private AudioClip jingleComplete;
    [SerializeField] private AudioClip reticleOn;

    //Creates an audiomanager instance and and audiosurce
    [SerializeField] private AudioSource jingleSource;
    [SerializeField] private AudioSource reticleSource;

    public static AudioManager instance;

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
              jingleSource.Stop();
              jingleSource.clip = jingleComplete;
              jingleSource.Play();
         }
    }

    public void ReticleSFX()
    {
        if (reticleSource != null)
        {
            reticleSource.Stop();
            reticleSource.clip = reticleOn;
            reticleSource.Play();
        }
    }
}
