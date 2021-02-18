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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ChaserApproach();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ChaserLeave();
        }
    }

    public void ChaserApproach() //if called will move chaser to player
    {
        transform.position = new Vector3(0, -3, -1.5f);
        //sfx alien sound
    }

    public void ChaserLeave() //if called will move chaser away from player
    {
        transform.position = new Vector3(0, -3, -3);
    }
}
