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
    [Header("SFX clips")]
    [SerializeField] private AudioClip jingleComplete;
    [SerializeField] private AudioClip reticleOn;
    [SerializeField] private AudioClip doorLocked;
    [SerializeField] private AudioClip tableBell;
    [SerializeField] private AudioClip pickUp;

    //Creates an audiomanager instance and and audiosurce
    [Header("Audio Sources")]
    [SerializeField] private AudioSource jingleSource;
    [SerializeField] private AudioSource reticleSource;
    [SerializeField] private AudioSource sfxSource;

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

    public void LockedSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
            sfxSource.clip = doorLocked;
            sfxSource.Play();
        }
    }

    public void TableBellSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
            sfxSource.clip = tableBell;
            sfxSource.Play();
        }
    }

    public void PickUpSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.Stop();
            sfxSource.clip = pickUp;
            sfxSource.Play();
        }
    }
}
