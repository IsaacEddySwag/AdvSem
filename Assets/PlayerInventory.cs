using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool card1 = false;
    private bool card2 = false;

    public void SetCard1(bool card) => card1 = card;
    public void SetCard2(bool card) => card2 = card;
}
