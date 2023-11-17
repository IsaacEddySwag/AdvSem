using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMaterial : MonoBehaviour
{
    [SerializeField] private Material floorM;
    [SerializeField] private Material glassM
        ;

    [SerializeField] private bool isFloor = true;

    public void SwapBetween()
    {
        if(isFloor)
        {
            gameObject.GetComponent<MeshRenderer>().material = glassM;
            isFloor = false;
        }
        else if(!isFloor)
        {
            gameObject.GetComponent<MeshRenderer>().material = floorM;
            isFloor = true;
        }
    }
}
