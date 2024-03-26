using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public GameObject[] creatures;
    public int selectedCreature = 0;

    public void NextCreature()
    {
        creatures[selectedCreature].SetActive(false);
        selectedCreature = (selectedCreature + 1) % creatures.Length;//取余，达到数组的长度时重新回到 0
        creatures[selectedCreature].SetActive(true);
    }
    public void PreviousCreature()
    {
        creatures[selectedCreature].SetActive(false);
        selectedCreature--;
        if (selectedCreature < 0)
        {
            selectedCreature += creatures.Length;
        }
        creatures[selectedCreature].SetActive(true);
    }

}
