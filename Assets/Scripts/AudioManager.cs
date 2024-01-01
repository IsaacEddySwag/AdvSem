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
    [SerializeField] private AudioClip doorOpen;
    [SerializeField] private AudioClip doorClose;
    [SerializeField] private AudioClip enterGame;

    //Creates an audiomanager instance and and audiosurce
    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    public static AudioManager instance;

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
    }

    //Each one of these is an individual sound effect player. When you call one of these functions you can play its respective sound effect.

    public void CompleteJingle()
    {
         if (sfxSource != null)
         {
              sfxSource.PlayOneShot(jingleComplete);
         }
    }

    public void ReticleSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(reticleOn);
        }
    }

    public void LockedSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(doorLocked);
        }
    }

    public void TableBellSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(tableBell);
        }
    }

    public void PickUpSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(pickUp);
        }
    }

    public void DoorOpenSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(doorOpen, 0.8f);
        }
    }

    public void DoorExitSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(doorClose, 0.8f);
        }
    }

    public void StartGameSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(enterGame);
        }
    }
}
