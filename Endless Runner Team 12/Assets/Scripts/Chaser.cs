using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public static Chaser instance;

    private void Awake() //singleton
    {
        instance = this;
    }

    public void ChaserApproach(GameObject chaser) //if called will move chaser to player
    {
        chaser.transform.position = new Vector3(0, -3, -1.5f);
        //sfx alien sound
    }

    public void ChaserLeave(GameObject chaser) //if called will move chaser away from player
    {
        chaser.transform.position = new Vector3(0, -3, -3);
    }
}
