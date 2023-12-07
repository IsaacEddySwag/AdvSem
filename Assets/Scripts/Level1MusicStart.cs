using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1MusicStart : MonoBehaviour
{
    void Start()
    {
        MusicPlayer.instance.LevelOneBGM();
    }
}
