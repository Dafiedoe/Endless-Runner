using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public static Chaser instance;
    public static PlayerManager playerManager;
    private GenericHealth playerHealth;

    private void Awake() //singleton
    {
        instance = this;
    }

    private void Start()
    {
        playerHealth = PlayerManager.instance.GetComponent<GenericHealth>();
    }

    private void Update()
    {
        if (playerHealth.startingHealth > playerHealth.Health)
        {
            ChaserApproach();
        }

        if (playerHealth.Health >= playerHealth.startingHealth)
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
