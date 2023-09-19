using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color newColor;

    public void ChangeColor()
    {
        GetComponent<Light>().color = newColor;
    }
}
