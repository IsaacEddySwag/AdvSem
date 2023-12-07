using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicStart : MonoBehaviour
{
    void Start()
    {
        MusicPlayer.instance.MainMenuBGM();
    }
}
