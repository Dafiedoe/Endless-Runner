using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour //This is a temporary script, cut-paste to PlayerManager later
{
    private void OnTriggerEnter(Collider collision) //Checks for collision with tagged objects and calls two methods for player object
    {
        GenericHealth playerHealth = GetComponent<GenericHealth>();
        if (collision.gameObject.GetComponent<CollisionTag>())
        {
            playerHealth.TakeDamage(-1);
            playerHealth.RegenHealth(+1);
        }
    }
}
