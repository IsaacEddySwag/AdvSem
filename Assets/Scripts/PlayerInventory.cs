using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool card1 = false;
    public bool card2 = false;

    public void SetCard1(bool card) => card1 = card;
    public void SetCard2(bool card) => card2 = card;
}
