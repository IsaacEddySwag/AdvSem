using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class S_AudioManager : MonoBehaviour
{
    //These clips each hold one sound effect that can be called via a function.
    public AudioClip Chomp;
    public AudioClip TongueLaunch;
    public AudioClip TongueHit;
    public AudioClip TongueRetract;
    public AudioClip Bonk;
    public AudioClip menuHover;
    public AudioClip menuClick;
    public AudioClip Croak;
    public AudioClip oxygenBeep;
    public AudioClip ForceField;
    public AudioClip poison;

    public float randomChoice = 0;
    public GameObject jetSource;

    public float playerMagni;


    //Creates an audiomanager instance and and audiosurce
    public AudioSource source;
    public AudioSource croakSource;
    public AudioSource chompSource;
    public AudioSource bonkSource;
    public AudioSource oxygenSource;
    public AudioSource forceSource;
    public AudioSource poisonSource;
    private static S_AudioManager instance;

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

        randomChoice = UnityEngine.Random.Range(0.8f, 3f);
    }

    void Update()
    {
        if(GameObject.Find("Frog") != null)
        {
            playerMagni = GameObject.Find("Frog").GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }

    //Each one of these is an individual sound effect player. When you call one of these functions you can play its respective sound effect.

    public void ChompSFX()
    {
        if (instance != null)
        {
            if (instance.chompSource != null)
            {
                instance.chompSource.Stop();
                instance.chompSource.clip = instance.Chomp;
                instance.chompSource.Play();
            }
        }
    }

    public void TongueLaunchSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                randomChoice = UnityEngine.Random.Range(0.8f, 3f);

                instance.source.Stop();
                instance.source.clip = instance.TongueLaunch;
                source.pitch = randomChoice;
                instance.source.Play();
            }
        }
    }

    public void TongueHitSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.TongueHit;
                instance.source.Play();
            }
        }
    }

    public void TongueRetractSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                randomChoice = UnityEngine.Random.Range(0.8f, 3f);

                instance.source.Stop();
                instance.source.clip = instance.TongueRetract;
                source.pitch = randomChoice;
                instance.source.Play();
            }
        }
    }

    public void BonkSFX()
    {
        if (instance != null)
        {
            if (instance.bonkSource != null)
            {
                source.pitch = 1.0f;
                instance.bonkSource.Stop();
                instance.bonkSource.clip = instance.Bonk;
                instance.bonkSource.volume = playerMagni / 30f;
                instance.bonkSource.Play();
            }
        }
    }

    public void HoverSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                source.pitch = 1.0f;
                instance.source.Stop();
                instance.source.clip = instance.menuHover;
                instance.source.Play();
            }
        }
    }

    public void ClickSFX()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                source.pitch = 1.0f;
                instance.source.Stop();
                instance.source.clip = instance.menuClick;
                source.pitch = 1.0f;
                instance.source.Play();
            }
        }
    }

    public void CroakSFX()
    {
        if (instance != null)
        {
            if (instance.croakSource != null)
            {
                source.pitch = 1.0f;
                instance.croakSource.Stop();
                instance.croakSource.clip = instance.Croak;
                instance.croakSource.Play();
            }
        }
    }

    public void OxygenBeepSFX()
    {
        if (instance != null)
        {
            if (instance.oxygenSource != null)
            {
                source.pitch = 1.0f;
                instance.oxygenSource.Stop();
                instance.oxygenSource.clip = instance.oxygenBeep;
                instance.oxygenSource.Play();
            }
        }
    }

    public void ForceFieldSFX()
    {
        if (instance != null)
        {
            if (instance.forceSource != null)
            {
                source.pitch = 1.0f;
                instance.forceSource.Stop();
                instance.forceSource.clip = instance.ForceField;
                instance.forceSource.Play();
            }
        }
    }

    public void PoisonSFX()
    {
        if (instance != null)
        {
            if (instance.poisonSource != null)
            {
                source.pitch = 1.0f;
                instance.poisonSource.Stop();
                instance.poisonSource.clip = instance.poison;
                instance.poisonSource.Play();
            }
        }
    }

    public void JetSFXOn()
    {
        jetSource.SetActive(true);
    }

    public void JetSFXOff()
    {
        jetSource.SetActive(false);    
    }
}
